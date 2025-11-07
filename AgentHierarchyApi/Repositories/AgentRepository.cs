using Microsoft.EntityFrameworkCore;
using AgentHierarchyApi.Data;
using AgentHierarchyApi.Models;

namespace AgentHierarchyApi.Repositories;

public class AgentRepository : IAgentRepository
{
    private readonly ApplicationDbContext _context;

    public AgentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Agent>> GetAllAgentsAsync()
    {
        return await _context.Agents
            .Include(a => a.Rank)
            .Include(a => a.Hierarchy)
            .Include(a => a.ParentAgent)
            .Where(a => a.IsActive)
            .OrderBy(a => a.AgentCode)
            .ToListAsync();
    }

    public async Task<Agent?> GetAgentByIdAsync(int id)
    {
        return await _context.Agents
            .Include(a => a.Rank)
            .Include(a => a.Hierarchy)
            .Include(a => a.ParentAgent)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Agent?> GetAgentByCodeAsync(string agentCode)
    {
        return await _context.Agents
            .Include(a => a.Rank)
            .Include(a => a.Hierarchy)
            .Include(a => a.ParentAgent)
            .FirstOrDefaultAsync(a => a.AgentCode == agentCode);
    }

    public async Task<IEnumerable<Agent>> GetAgentsByRankAsync(string rankCode)
    {
        return await _context.Agents
            .Include(a => a.Rank)
            .Include(a => a.Hierarchy)
            .Include(a => a.ParentAgent)
            .Where(a => a.Rank.RankCode == rankCode && a.IsActive)
            .OrderBy(a => a.AgentCode)
            .ToListAsync();
    }

    public async Task<IEnumerable<Agent>> GetAgentsByHierarchyAsync(string hierarchyCode)
    {
        return await _context.Agents
            .Include(a => a.Rank)
            .Include(a => a.Hierarchy)
            .Include(a => a.ParentAgent)
            .Where(a => a.Hierarchy.HierarchyCode == hierarchyCode && a.IsActive)
            .OrderBy(a => a.AgentCode)
            .ToListAsync();
    }

    public async Task<IEnumerable<Agent>> GetChildAgentsAsync(int parentAgentId)
    {
        return await _context.Agents
            .Include(a => a.Rank)
            .Include(a => a.Hierarchy)
            .Where(a => a.ParentAgentId == parentAgentId && a.IsActive)
            .OrderBy(a => a.AgentCode)
            .ToListAsync();
    }

    public async Task<IEnumerable<Agent>> GetTopLevelAgentsAsync()
    {
        return await _context.Agents
            .Include(a => a.Rank)
            .Include(a => a.Hierarchy)
            .Where(a => a.ParentAgentId == null && a.IsActive)
            .OrderBy(a => a.AgentCode)
            .ToListAsync();
    }

    public async Task<Agent> CreateAgentAsync(Agent agent)
    {
        agent.CreatedDate = DateTime.UtcNow;
        agent.UpdatedDate = DateTime.UtcNow;
        _context.Agents.Add(agent);
        await _context.SaveChangesAsync();
        return agent;
    }

    public async Task<Agent> UpdateAgentAsync(Agent agent)
    {
        agent.UpdatedDate = DateTime.UtcNow;
        _context.Agents.Update(agent);
        await _context.SaveChangesAsync();
        return agent;
    }

    public async Task<bool> DeleteAgentAsync(int id)
    {
        var agent = await _context.Agents.FindAsync(id);
        if (agent == null)
            return false;

        agent.IsActive = false;
        agent.UpdatedDate = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AgentCodeExistsAsync(string agentCode)
    {
        return await _context.Agents.AnyAsync(a => a.AgentCode == agentCode);
    }
}
