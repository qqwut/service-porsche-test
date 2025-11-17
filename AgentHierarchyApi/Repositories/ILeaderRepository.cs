using AgentHierarchyApi.Models;

namespace AgentHierarchyApi.Repositories;

public interface ILeaderRepository
{
    Task<IEnumerable<Leader>> GetAllLeadersAsync();
    Task<Leader?> GetLeaderByIdAsync(int id);
    Task<Leader?> GetLeaderByRefIdAsync(string refId);
    Task<IEnumerable<Leader>> GetLeadersByPromoteTypeAsync(string promoteType);
    Task<IEnumerable<Leader>> GetLeadersByLastRankAsync(string lastRank);
    Task<Leader> CreateLeaderAsync(Leader leader);
    Task<Leader> UpdateLeaderAsync(Leader leader);
    Task<bool> DeleteLeaderAsync(int id);
    Task<bool> RefIdExistsAsync(string refId);
}
