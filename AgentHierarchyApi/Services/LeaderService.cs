using AgentHierarchyApi.DTOs;
using AgentHierarchyApi.Models;
using AgentHierarchyApi.Repositories;

namespace AgentHierarchyApi.Services;

public class LeaderService : ILeaderService
{
    private readonly ILeaderRepository _leaderRepository;
    private readonly IAgentRepository _agentRepository;

    public LeaderService(ILeaderRepository leaderRepository, IAgentRepository agentRepository)
    {
        _leaderRepository = leaderRepository;
        _agentRepository = agentRepository;
    }

    public async Task<IEnumerable<LeaderDto>> GetAllLeadersAsync()
    {
        var leaders = await _leaderRepository.GetAllLeadersAsync();
        return leaders.Select(MapToDto);
    }

    public async Task<LeaderDto?> GetLeaderByIdAsync(int id)
    {
        var leader = await _leaderRepository.GetLeaderByIdAsync(id);
        return leader != null ? MapToDto(leader) : null;
    }

    public async Task<LeaderDto?> GetLeaderByRefIdAsync(string refId)
    {
        var leader = await _leaderRepository.GetLeaderByRefIdAsync(refId);
        return leader != null ? MapToDto(leader) : null;
    }

    public async Task<IEnumerable<LeaderDto>> GetLeadersByPromoteTypeAsync(string promoteType)
    {
        var leaders = await _leaderRepository.GetLeadersByPromoteTypeAsync(promoteType);
        return leaders.Select(MapToDto);
    }

    public async Task<IEnumerable<LeaderDto>> GetLeadersByLastRankAsync(string lastRank)
    {
        var leaders = await _leaderRepository.GetLeadersByLastRankAsync(lastRank);
        return leaders.Select(MapToDto);
    }

    public async Task<LeaderDto> CreateLeaderAsync(LeaderCreateDto leaderDto)
    {
        // Validate RefId (AgentCode) exists
        var agent = await _agentRepository.GetAgentByCodeAsync(leaderDto.RefId);
        if (agent == null)
        {
            throw new InvalidOperationException($"Agent with code {leaderDto.RefId} not found.");
        }

        // Validate RefId doesn't already exist as a leader
        if (await _leaderRepository.RefIdExistsAsync(leaderDto.RefId))
        {
            throw new InvalidOperationException($"Leader with RefId {leaderDto.RefId} already exists.");
        }

        // Validate PromoteType
        var validPromoteTypes = new[] { "GM", "AVP", "VP", "SVP" };
        if (!validPromoteTypes.Contains(leaderDto.PromoteType))
        {
            throw new InvalidOperationException($"Invalid PromoteType. Must be one of: {string.Join(", ", validPromoteTypes)}");
        }

        var leader = new Leader
        {
            RefId = leaderDto.RefId,
            PromoteType = leaderDto.PromoteType,
            Affiliation = leaderDto.Affiliation,
            Branch = leaderDto.Branch,
            RefLicense = leaderDto.RefLicense,
            RefCompany = leaderDto.RefCompany,
            LastRank = leaderDto.LastRank,
            CreatedBy = leaderDto.CreatedBy
        };

        var createdLeader = await _leaderRepository.CreateLeaderAsync(leader);
        var result = await _leaderRepository.GetLeaderByIdAsync(createdLeader.Id);
        return MapToDto(result!);
    }

    public async Task<LeaderDto?> UpdateLeaderAsync(int id, LeaderUpdateDto leaderDto)
    {
        var leader = await _leaderRepository.GetLeaderByIdAsync(id);
        if (leader == null)
            return null;

        // Validate PromoteType
        var validPromoteTypes = new[] { "GM", "AVP", "VP", "SVP" };
        if (!validPromoteTypes.Contains(leaderDto.PromoteType))
        {
            throw new InvalidOperationException($"Invalid PromoteType. Must be one of: {string.Join(", ", validPromoteTypes)}");
        }

        leader.PromoteType = leaderDto.PromoteType;
        leader.Affiliation = leaderDto.Affiliation;
        leader.Branch = leaderDto.Branch;
        leader.RefLicense = leaderDto.RefLicense;
        leader.RefCompany = leaderDto.RefCompany;
        leader.LastRank = leaderDto.LastRank;
        leader.UpdatedBy = leaderDto.UpdatedBy;

        var updatedLeader = await _leaderRepository.UpdateLeaderAsync(leader);
        var result = await _leaderRepository.GetLeaderByIdAsync(updatedLeader.Id);
        return MapToDto(result!);
    }

    public async Task<bool> DeleteLeaderAsync(int id)
    {
        return await _leaderRepository.DeleteLeaderAsync(id);
    }

    private LeaderDto MapToDto(Leader leader)
    {
        return new LeaderDto
        {
            Id = leader.Id,
            RefId = leader.RefId,
            PromoteType = leader.PromoteType,
            Affiliation = leader.Affiliation,
            Branch = leader.Branch,
            RefLicense = leader.RefLicense,
            RefCompany = leader.RefCompany,
            LastRank = leader.LastRank,
            CreatedDate = leader.CreatedDate,
            UpdatedDate = leader.UpdatedDate,
            CreatedBy = leader.CreatedBy,
            UpdatedBy = leader.UpdatedBy
        };
    }
}
