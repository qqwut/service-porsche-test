using AgentHierarchyApi.DTOs;
using AgentHierarchyApi.Models;
using AgentHierarchyApi.Repositories;
using Microsoft.EntityFrameworkCore;
using AgentHierarchyApi.Data;

namespace AgentHierarchyApi.Services;

public class AgentService : IAgentService
{
    private readonly IAgentRepository _agentRepository;
    private readonly ApplicationDbContext _context;

    public AgentService(IAgentRepository agentRepository, ApplicationDbContext context)
    {
        _agentRepository = agentRepository;
        _context = context;
    }

    public async Task<IEnumerable<AgentDto>> GetAllAgentsAsync()
    {
        var agents = await _agentRepository.GetAllAgentsAsync();
        return agents.Select(MapToDto);
    }

    public async Task<AgentDto?> GetAgentByIdAsync(int id)
    {
        var agent = await _agentRepository.GetAgentByIdAsync(id);
        return agent != null ? MapToDto(agent) : null;
    }

    public async Task<AgentDto?> GetAgentByCodeAsync(string agentCode)
    {
        var agent = await _agentRepository.GetAgentByCodeAsync(agentCode);
        return agent != null ? MapToDto(agent) : null;
    }

    public async Task<IEnumerable<AgentDto>> GetAgentsByRankAsync(string rankCode)
    {
        var agents = await _agentRepository.GetAgentsByRankAsync(rankCode);
        return agents.Select(MapToDto);
    }

    public async Task<IEnumerable<AgentDto>> GetAgentsByHierarchyAsync(string hierarchyCode)
    {
        var agents = await _agentRepository.GetAgentsByHierarchyAsync(hierarchyCode);
        return agents.Select(MapToDto);
    }

    public async Task<AgentHierarchyTreeDto?> GetAgentHierarchyTreeAsync(int? rootAgentId = null)
    {
        IEnumerable<Agent> rootAgents;

        if (rootAgentId.HasValue)
        {
            var rootAgent = await _agentRepository.GetAgentByIdAsync(rootAgentId.Value);
            if (rootAgent == null)
                return null;
            
            rootAgents = new[] { rootAgent };
        }
        else
        {
            rootAgents = await _agentRepository.GetTopLevelAgentsAsync();
        }

        var allAgents = await _agentRepository.GetAllAgentsAsync();
        var agentDict = allAgents.ToDictionary(a => a.Id);

        var trees = new List<AgentHierarchyTreeDto>();
        foreach (var root in rootAgents)
        {
            trees.Add(BuildHierarchyTree(root, agentDict));
        }

        // If no root specified and multiple top-level agents, return a virtual root
        if (!rootAgentId.HasValue && trees.Count > 1)
        {
            return new AgentHierarchyTreeDto
            {
                Id = 0,
                AgentCode = "ROOT",
                AgentName = "Root",
                HierarchyCode = "",
                RankCode = "",
                Children = trees
            };
        }

        return trees.FirstOrDefault();
    }

    public async Task<AgentHierarchyTreeDto?> GetAgentHierarchyTreeByCodeAsync(string agentCode)
    {
        var rootAgent = await _agentRepository.GetAgentByCodeAsync(agentCode);
        if (rootAgent == null)
            return null;

        var allAgents = await _agentRepository.GetAllAgentsAsync();
        var agentDict = allAgents.ToDictionary(a => a.Id);

        return BuildHierarchyTree(rootAgent, agentDict);
    }

    public async Task<AgentUpwardTreeDto?> GetAgentUpwardTreeByCodeAsync(string agentCode)
    {
        var agent = await _agentRepository.GetAgentByCodeAsync(agentCode);
        if (agent == null)
            return null;

        return await BuildUpwardTreeAsync(agent);
    }

    private async Task<AgentUpwardTreeDto> BuildUpwardTreeAsync(Agent agent)
    {
        var node = new AgentUpwardTreeDto
        {
            Id = agent.Id,
            AgentCode = agent.AgentCode,
            AgentName = agent.AgentName,
            HierarchyCode = agent.Hierarchy.HierarchyCode,
            RankCode = agent.Rank.RankCode,
            ParentAgentId = agent.ParentAgentId,
            Parent = null
        };

        if (agent.ParentAgentId.HasValue)
        {
            var parentAgent = await _agentRepository.GetAgentByIdAsync(agent.ParentAgentId.Value);
            if (parentAgent != null)
            {
                node.Parent = await BuildUpwardTreeAsync(parentAgent);
            }
        }

        return node;
    }

    private AgentHierarchyTreeDto BuildHierarchyTree(Agent agent, Dictionary<int, Agent> allAgents)
    {
        var node = new AgentHierarchyTreeDto
        {
            Id = agent.Id,
            AgentCode = agent.AgentCode,
            AgentName = agent.AgentName,
            HierarchyCode = agent.Hierarchy.HierarchyCode,
            RankCode = agent.Rank.RankCode,
            Children = new List<AgentHierarchyTreeDto>()
        };

        var children = allAgents.Values.Where(a => a.ParentAgentId == agent.Id).ToList();
        foreach (var child in children)
        {
            node.Children.Add(BuildHierarchyTree(child, allAgents));
        }

        return node;
    }

    public async Task<AgentDto> CreateAgentAsync(AgentCreateDto agentDto)
    {
        // Validate agent code doesn't exist
        if (await _agentRepository.AgentCodeExistsAsync(agentDto.AgentCode))
        {
            throw new InvalidOperationException($"Agent code {agentDto.AgentCode} already exists.");
        }

        // Get hierarchy
        var hierarchy = await _context.Hierarchies
            .Include(h => h.Rank)
            .FirstOrDefaultAsync(h => h.HierarchyCode == agentDto.HierarchyCode);

        if (hierarchy == null)
        {
            throw new InvalidOperationException($"Hierarchy {agentDto.HierarchyCode} not found.");
        }

        // Validate parent agent if specified
        if (agentDto.ParentAgentId.HasValue)
        {
            var parentAgent = await _agentRepository.GetAgentByIdAsync(agentDto.ParentAgentId.Value);
            if (parentAgent == null)
            {
                throw new InvalidOperationException($"Parent agent with ID {agentDto.ParentAgentId} not found.");
            }

            // Validate hierarchy rules: AG < AL < AE
            if (hierarchy.Rank.Level >= parentAgent.Rank.Level)
            {
                throw new InvalidOperationException(
                    $"Invalid hierarchy: {hierarchy.Rank.RankCode} (level {hierarchy.Rank.Level}) " +
                    $"cannot be under {parentAgent.Rank.RankCode} (level {parentAgent.Rank.Level}). " +
                    $"Hierarchy must be: AG < AL < AE");
            }
        }

        var agent = new Agent
        {
            AgentCode = agentDto.AgentCode,
            AgentName = agentDto.AgentName,
            HierarchyId = hierarchy.Id,
            RankId = hierarchy.RankId,
            ParentAgentId = agentDto.ParentAgentId,
            IsActive = true
        };

        var createdAgent = await _agentRepository.CreateAgentAsync(agent);
        var result = await _agentRepository.GetAgentByIdAsync(createdAgent.Id);
        return MapToDto(result!);
    }

    public async Task<AgentDto?> UpdateAgentAsync(int id, AgentUpdateDto agentDto)
    {
        var agent = await _agentRepository.GetAgentByIdAsync(id);
        if (agent == null)
            return null;

        // Get hierarchy
        var hierarchy = await _context.Hierarchies
            .Include(h => h.Rank)
            .FirstOrDefaultAsync(h => h.HierarchyCode == agentDto.HierarchyCode);

        if (hierarchy == null)
        {
            throw new InvalidOperationException($"Hierarchy {agentDto.HierarchyCode} not found.");
        }

        // Validate parent agent if specified
        if (agentDto.ParentAgentId.HasValue && agentDto.ParentAgentId != agent.ParentAgentId)
        {
            var parentAgent = await _agentRepository.GetAgentByIdAsync(agentDto.ParentAgentId.Value);
            if (parentAgent == null)
            {
                throw new InvalidOperationException($"Parent agent with ID {agentDto.ParentAgentId} not found.");
            }

            // Validate hierarchy rules
            if (hierarchy.Rank.Level >= parentAgent.Rank.Level)
            {
                throw new InvalidOperationException(
                    $"Invalid hierarchy: {hierarchy.Rank.RankCode} (level {hierarchy.Rank.Level}) " +
                    $"cannot be under {parentAgent.Rank.RankCode} (level {parentAgent.Rank.Level}). " +
                    $"Hierarchy must be: AG < AL < AE");
            }
        }

        agent.AgentName = agentDto.AgentName;
        agent.HierarchyId = hierarchy.Id;
        agent.RankId = hierarchy.RankId;
        agent.ParentAgentId = agentDto.ParentAgentId;
        agent.IsActive = agentDto.IsActive;

        var updatedAgent = await _agentRepository.UpdateAgentAsync(agent);
        var result = await _agentRepository.GetAgentByIdAsync(updatedAgent.Id);
        return MapToDto(result!);
    }

    public async Task<bool> DeleteAgentAsync(int id)
    {
        return await _agentRepository.DeleteAgentAsync(id);
    }

    private AgentDto MapToDto(Agent agent)
    {
        return new AgentDto
        {
            Id = agent.Id,
            AgentCode = agent.AgentCode,
            AgentName = agent.AgentName,
            HierarchyCode = agent.Hierarchy.HierarchyCode,
            RankCode = agent.Rank.RankCode,
            ParentAgentId = agent.ParentAgentId,
            ParentAgentCode = agent.ParentAgent?.AgentCode,
            IsActive = agent.IsActive
        };
    }
}
