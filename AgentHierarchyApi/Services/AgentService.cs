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
        var mapped = new List<AgentDto>();
        foreach (var agent in agents)
        {
            mapped.Add(await MapToDtoAsync(agent));
        }
        return mapped;
    }

    public async Task<AgentDto?> GetAgentByIdAsync(int id)
    {
        var agent = await _agentRepository.GetAgentByIdAsync(id);
        return agent != null ? await MapToDtoAsync(agent) : null;
    }

    public async Task<AgentDto?> GetAgentByCodeAsync(string agentCode)
    {
        var agent = await _agentRepository.GetAgentByCodeAsync(agentCode);
        return agent != null ? await MapToDtoAsync(agent) : null;
    }

    public async Task<IEnumerable<AgentDto>> GetAgentsByRankAsync(string rankCode)
    {
        var agents = await _agentRepository.GetAgentsByRankAsync(rankCode);
        var mapped = new List<AgentDto>();
        foreach (var agent in agents)
        {
            mapped.Add(await MapToDtoAsync(agent));
        }
        return mapped;
    }

    public async Task<IEnumerable<AgentDto>> GetAgentsByHierarchyAsync(string hierarchyCode)
    {
        var agents = await _agentRepository.GetAgentsByHierarchyAsync(hierarchyCode);
        var mapped = new List<AgentDto>();
        foreach (var agent in agents)
        {
            mapped.Add(await MapToDtoAsync(agent));
        }
        return mapped;
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
            trees.Add(await BuildHierarchyTreeAsync(root, agentDict));
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

        return await BuildHierarchyTreeAsync(rootAgent, agentDict);
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
            AgentType = agent.AgentType,
            LeaderCode = agent.LeaderCode ?? await ComputeLeaderCodeAsync(agent),
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

    private async Task<AgentHierarchyTreeDto> BuildHierarchyTreeAsync(Agent agent, Dictionary<int, Agent> allAgents)
    {
        var node = new AgentHierarchyTreeDto
        {
            Id = agent.Id,
            AgentCode = agent.AgentCode,
            AgentName = agent.AgentName,
            AgentType = agent.AgentType,
            LeaderCode = agent.LeaderCode ?? await ComputeLeaderCodeAsync(agent),
            HierarchyCode = agent.Hierarchy.HierarchyCode,
            RankCode = agent.Rank.RankCode,
            Children = new List<AgentHierarchyTreeDto>()
        };

        var children = allAgents.Values.Where(a => a.ParentAgentId == agent.Id).ToList();
        foreach (var child in children)
        {
            node.Children.Add(await BuildHierarchyTreeAsync(child, allAgents));
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
            AgentType = agentDto.AgentType,
            HierarchyId = hierarchy.Id,
            RankId = hierarchy.RankId,
            ParentAgentId = agentDto.ParentAgentId,
            IsActive = true
        };

        // Compute and persist LeaderCode
        agent.LeaderCode = await ComputeLeaderCodeAsync(agent);

        var createdAgent = await _agentRepository.CreateAgentAsync(agent);
        var result = await _agentRepository.GetAgentByIdAsync(createdAgent.Id);
        return await MapToDtoAsync(result!);
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
        agent.AgentType = agentDto.AgentType;
        agent.HierarchyId = hierarchy.Id;
        agent.RankId = hierarchy.RankId;
        agent.ParentAgentId = agentDto.ParentAgentId;
        agent.IsActive = agentDto.IsActive;

        // Recompute LeaderCode on updates (rank/parent may change)
        agent.LeaderCode = await ComputeLeaderCodeAsync(agent);

        var updatedAgent = await _agentRepository.UpdateAgentAsync(agent);
        var result = await _agentRepository.GetAgentByIdAsync(updatedAgent.Id);
        return await MapToDtoAsync(result!);
    }

    public async Task<bool> DeleteAgentAsync(int id)
    {
        return await _agentRepository.DeleteAgentAsync(id);
    }

    private async Task<string?> ComputeLeaderCodeAsync(Agent agent)
    {
        // AE has no leader; AL is its own leader; AG looks upward for nearest AL
        var rankCode = agent.Rank?.RankCode ?? (await _context.Ranks.FindAsync(agent.RankId))?.RankCode;
        if (rankCode == "AE")
            return null;
        if (rankCode == "AL")
            return agent.AgentCode;

        // For AG, walk up the chain to find nearest AL
        var currentParentId = agent.ParentAgentId;
        while (currentParentId.HasValue)
        {
            var parent = await _agentRepository.GetAgentByIdAsync(currentParentId.Value);
            if (parent == null)
                break;
            if (parent.Rank.RankCode == "AL")
                return parent.AgentCode;
            currentParentId = parent.ParentAgentId;
        }
        return null;
    }

    private async Task<AgentDto> MapToDtoAsync(Agent agent)
    {
        var leaderCode = agent.LeaderCode;
        if (string.IsNullOrEmpty(leaderCode))
        {
            leaderCode = await ComputeLeaderCodeAsync(agent);
        }

        return new AgentDto
        {
            Id = agent.Id,
            AgentCode = agent.AgentCode,
            AgentName = agent.AgentName,
            AgentType = agent.AgentType,
            LeaderCode = leaderCode,
            HierarchyCode = agent.Hierarchy.HierarchyCode,
            RankCode = agent.Rank.RankCode,
            ParentAgentId = agent.ParentAgentId,
            ParentAgentCode = agent.ParentAgent?.AgentCode,
            IsActive = agent.IsActive
        };
    }
}
