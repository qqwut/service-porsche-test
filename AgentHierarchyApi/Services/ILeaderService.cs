using AgentHierarchyApi.DTOs;

namespace AgentHierarchyApi.Services;

public interface ILeaderService
{
    Task<IEnumerable<LeaderDto>> GetAllLeadersAsync();
    Task<LeaderDto?> GetLeaderByIdAsync(int id);
    Task<LeaderDto?> GetLeaderByRefIdAsync(string refId);
    Task<IEnumerable<LeaderDto>> GetLeadersByPromoteTypeAsync(string promoteType);
    Task<IEnumerable<LeaderDto>> GetLeadersByLastRankAsync(string lastRank);
    Task<LeaderDto> CreateLeaderAsync(LeaderCreateDto leaderDto);
    Task<LeaderDto?> UpdateLeaderAsync(int id, LeaderUpdateDto leaderDto);
    Task<bool> DeleteLeaderAsync(int id);
}
