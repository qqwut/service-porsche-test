using AgentHierarchyApi.Data;
using AgentHierarchyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgentHierarchyApi.Repositories;

public class LicenseRepository : ILicenseRepository
{
    private readonly ApplicationDbContext _context;
    public LicenseRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<License>> GetAllAsync()
    {
        return await _context.Licenses
            .Include(l => l.Agent)
            .Where(l => l.IsActive)
            .OrderBy(l => l.LicenseNumber)
            .ToListAsync();
    }

    public async Task<License?> GetByIdAsync(int id)
    {
        return await _context.Licenses.Include(l => l.Agent).FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<IEnumerable<License>> GetByAgentIdAsync(int agentId)
    {
        return await _context.Licenses
            .Include(l => l.Agent)
            .Where(l => l.AgentId == agentId && l.IsActive)
            .OrderBy(l => l.LicenseNumber)
            .ToListAsync();
    }

    public async Task<License?> GetByLicenseNumberAsync(string licenseNumber)
    {
        return await _context.Licenses.Include(l => l.Agent).FirstOrDefaultAsync(l => l.LicenseNumber == licenseNumber);
    }

    public async Task<License> CreateAsync(License license)
    {
        license.CreatedDate = DateTime.UtcNow;
        license.UpdatedDate = DateTime.UtcNow;
        _context.Licenses.Add(license);
        await _context.SaveChangesAsync();
        return license;
    }

    public async Task<License> UpdateAsync(License license)
    {
        license.UpdatedDate = DateTime.UtcNow;
        _context.Licenses.Update(license);
        await _context.SaveChangesAsync();
        return license;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var license = await _context.Licenses.FindAsync(id);
        if (license == null) return false;
        license.IsActive = false;
        license.UpdatedDate = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> LicenseNumberExistsAsync(string licenseNumber)
    {
        return await _context.Licenses.AnyAsync(l => l.LicenseNumber == licenseNumber);
    }
}