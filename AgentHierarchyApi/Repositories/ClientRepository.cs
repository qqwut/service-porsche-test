using AgentHierarchyApi.Data;
using AgentHierarchyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgentHierarchyApi.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        return await _context.Clients
            .Include(c => c.Addresses)
            .Include(c => c.Contacts)
            .Include(c => c.Roles)
            .Include(c => c.ReferenceAgent)
            .ToListAsync();
    }

    public async Task<Client?> GetClientByIdAsync(int id)
    {
        return await _context.Clients
            .Include(c => c.Addresses)
            .Include(c => c.Contacts)
            .Include(c => c.Roles)
            .Include(c => c.ReferenceAgent)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Client?> GetClientByCodeAsync(string clientCode)
    {
        return await _context.Clients
            .Include(c => c.Addresses)
            .Include(c => c.Contacts)
            .Include(c => c.Roles)
            .Include(c => c.ReferenceAgent)
            .FirstOrDefaultAsync(c => c.ClientCode == clientCode);
    }

    public async Task<IEnumerable<Client>> GetClientsByAgentCodeAsync(string agentCode)
    {
        return await _context.Clients
            .Include(c => c.Addresses)
            .Include(c => c.Contacts)
            .Include(c => c.Roles)
            .Include(c => c.ReferenceAgent)
            .Where(c => c.RefId == agentCode)
            .ToListAsync();
    }

    public async Task<Client> CreateClientAsync(Client client)
    {
        client.CreatedDate = DateTime.UtcNow;
        client.UpdatedDate = DateTime.UtcNow;
        
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        
        return client;
    }

    public async Task<Client> UpdateClientAsync(Client client)
    {
        client.UpdatedDate = DateTime.UtcNow;
        
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
        
        return client;
    }

    public async Task<bool> DeleteClientAsync(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
            return false;

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> ClientCodeExistsAsync(string clientCode)
    {
        return await _context.Clients.AnyAsync(c => c.ClientCode == clientCode);
    }
}
