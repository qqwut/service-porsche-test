using AgentHierarchyApi.Models;

namespace AgentHierarchyApi.Repositories;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAllClientsAsync();
    Task<Client?> GetClientByIdAsync(int id);
    Task<Client?> GetClientByCodeAsync(string clientCode);
    Task<IEnumerable<Client>> GetClientsByAgentCodeAsync(string agentCode);
    Task<Client> CreateClientAsync(Client client);
    Task<Client> UpdateClientAsync(Client client);
    Task<bool> DeleteClientAsync(int id);
    Task<bool> ClientCodeExistsAsync(string clientCode);
}
