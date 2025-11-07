using AgentHierarchyApi.DTOs;

namespace AgentHierarchyApi.Services;

public interface IAgentService
{
    Task<IEnumerable<AgentDto>> GetAllAgentsAsync();
    Task<AgentDto?> GetAgentByIdAsync(int id);
    Task<AgentDto?> GetAgentByCodeAsync(string agentCode);
    Task<IEnumerable<AgentDto>> GetAgentsByRankAsync(string rankCode);
    Task<IEnumerable<AgentDto>> GetAgentsByHierarchyAsync(string hierarchyCode);
    Task<AgentHierarchyTreeDto?> GetAgentHierarchyTreeAsync(int? rootAgentId = null);
    Task<AgentHierarchyTreeDto?> GetAgentHierarchyTreeByCodeAsync(string agentCode);
    Task<AgentUpwardTreeDto?> GetAgentUpwardTreeByCodeAsync(string agentCode);
    Task<AgentDto> CreateAgentAsync(AgentCreateDto agentDto);
    Task<AgentDto?> UpdateAgentAsync(int id, AgentUpdateDto agentDto);
    Task<bool> DeleteAgentAsync(int id);
}
