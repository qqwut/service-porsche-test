using AgentHierarchyApi.Models;

namespace AgentHierarchyApi.Repositories;

public interface IAgentRepository
{
    Task<IEnumerable<Agent>> GetAllAgentsAsync();
    Task<Agent?> GetAgentByIdAsync(int id);
    Task<Agent?> GetAgentByCodeAsync(string agentCode);
    Task<IEnumerable<Agent>> GetAgentsByRankAsync(string rankCode);
    Task<IEnumerable<Agent>> GetAgentsByHierarchyAsync(string hierarchyCode);
    Task<IEnumerable<Agent>> GetChildAgentsAsync(int parentAgentId);
    Task<IEnumerable<Agent>> GetTopLevelAgentsAsync();
    Task<Agent> CreateAgentAsync(Agent agent);
    Task<Agent> UpdateAgentAsync(Agent agent);
    Task<bool> DeleteAgentAsync(int id);
    Task<bool> AgentCodeExistsAsync(string agentCode);
}
