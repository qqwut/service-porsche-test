using AgentHierarchyApi.DTOs;

namespace AgentHierarchyApi.Services;

public interface ILicenseService
{
    Task<IEnumerable<LicenseDto>> GetAllAsync();
    Task<LicenseDto?> GetByIdAsync(int id);
    Task<IEnumerable<LicenseDto>> GetByAgentIdAsync(int agentId);
    Task<LicenseDto> CreateAsync(LicenseCreateDto dto);
    Task<LicenseDto?> UpdateAsync(int id, LicenseUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}