using AgentHierarchyApi.DTOs;

namespace AgentHierarchyApi.Services;

public interface IClientService
{
    Task<IEnumerable<ClientDto>> GetAllClientsAsync();
    Task<ClientDto?> GetClientByIdAsync(int id);
    Task<ClientDto?> GetClientByCodeAsync(string clientCode);
    Task<ClientDto?> GetClientByAgentCodeAsync(string agentCode);
    Task<ClientDto> CreateClientAsync(CreateClientDto createClientDto);
    Task<ClientDto?> UpdateClientAsync(int id, UpdateClientDto updateClientDto);
    Task<bool> DeleteClientAsync(int id);
}
