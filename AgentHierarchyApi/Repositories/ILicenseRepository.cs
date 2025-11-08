using AgentHierarchyApi.Models;

namespace AgentHierarchyApi.Repositories;

public interface ILicenseRepository
{
    Task<IEnumerable<License>> GetAllAsync();
    Task<License?> GetByIdAsync(int id);
    Task<IEnumerable<License>> GetByAgentIdAsync(int agentId);
    Task<License?> GetByLicenseNumberAsync(string licenseNumber);
    Task<License> CreateAsync(License license);
    Task<License> UpdateAsync(License license);
    Task<bool> DeleteAsync(int id); // soft delete
    Task<bool> LicenseNumberExistsAsync(string licenseNumber);
}