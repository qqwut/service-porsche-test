using AgentHierarchyApi.Data;
using AgentHierarchyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgentHierarchyApi.Repositories;

public class LeaderRepository : ILeaderRepository
{
    private readonly ApplicationDbContext _context;

    public LeaderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Leader>> GetAllLeadersAsync()
    {
        return await _context.Leaders
            .Include(l => l.Agent)
            .ToListAsync();
    }

    public async Task<Leader?> GetLeaderByIdAsync(int id)
    {
        return await _context.Leaders
            .Include(l => l.Agent)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<Leader?> GetLeaderByRefIdAsync(string refId)
    {
        return await _context.Leaders
            .Include(l => l.Agent)
            .FirstOrDefaultAsync(l => l.RefId == refId);
    }

    public async Task<IEnumerable<Leader>> GetLeadersByPromoteTypeAsync(string promoteType)
    {
        return await _context.Leaders
            .Include(l => l.Agent)
            .Where(l => l.PromoteType == promoteType)
            .ToListAsync();
    }

    public async Task<IEnumerable<Leader>> GetLeadersByLastRankAsync(string lastRank)
    {
        return await _context.Leaders
            .Include(l => l.Agent)
            .Where(l => l.LastRank == lastRank)
            .ToListAsync();
    }

    public async Task<Leader> CreateLeaderAsync(Leader leader)
    {
        leader.CreatedDate = DateTime.UtcNow;
        leader.UpdatedDate = DateTime.UtcNow;
        _context.Leaders.Add(leader);
        await _context.SaveChangesAsync();
        return leader;
    }

    public async Task<Leader> UpdateLeaderAsync(Leader leader)
    {
        leader.UpdatedDate = DateTime.UtcNow;
        _context.Leaders.Update(leader);
        await _context.SaveChangesAsync();
        return leader;
    }

    public async Task<bool> DeleteLeaderAsync(int id)
    {
        var leader = await _context.Leaders.FindAsync(id);
        if (leader == null)
            return false;

        _context.Leaders.Remove(leader);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RefIdExistsAsync(string refId)
    {
        return await _context.Leaders.AnyAsync(l => l.RefId == refId);
    }
}
