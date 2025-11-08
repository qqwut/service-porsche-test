using AgentHierarchyApi.DTOs;
using AgentHierarchyApi.Models;
using AgentHierarchyApi.Repositories;

namespace AgentHierarchyApi.Services;

public class LicenseService : ILicenseService
{
    private readonly ILicenseRepository _licenseRepository;
    private readonly IAgentRepository _agentRepository;

    public LicenseService(ILicenseRepository licenseRepository, IAgentRepository agentRepository)
    {
        _licenseRepository = licenseRepository;
        _agentRepository = agentRepository;
    }

    public async Task<IEnumerable<LicenseDto>> GetAllAsync()
    {
        var licenses = await _licenseRepository.GetAllAsync();
        return licenses.Select(MapToDto);
    }

    public async Task<LicenseDto?> GetByIdAsync(int id)
    {
        var license = await _licenseRepository.GetByIdAsync(id);
        return license != null ? MapToDto(license) : null;
    }

    public async Task<IEnumerable<LicenseDto>> GetByAgentIdAsync(int agentId)
    {
        var licenses = await _licenseRepository.GetByAgentIdAsync(agentId);
        return licenses.Select(MapToDto);
    }

    public async Task<LicenseDto> CreateAsync(LicenseCreateDto dto)
    {
        if (await _licenseRepository.LicenseNumberExistsAsync(dto.LicenseNumber))
            throw new InvalidOperationException($"License number {dto.LicenseNumber} already exists.");

        var agent = await _agentRepository.GetAgentByIdAsync(dto.AgentId);
        if (agent == null) throw new InvalidOperationException($"Agent with ID {dto.AgentId} not found.");

        // Normalize dates to UTC (incoming JSON dates without timezone are Unspecified)
        var issueDateUtc = NormalizeToUtc(dto.IssueDate);
        DateTime? expiryDateUtc = dto.ExpiryDate.HasValue ? NormalizeToUtc(dto.ExpiryDate.Value) : null;

        if (expiryDateUtc.HasValue && expiryDateUtc < issueDateUtc)
            throw new InvalidOperationException("ExpiryDate cannot be earlier than IssueDate.");

        var license = new License
        {
            AgentId = dto.AgentId,
            LicenseNumber = dto.LicenseNumber,
            IssueDate = issueDateUtc,
            ExpiryDate = expiryDateUtc,
            IsActive = true
        };

        var created = await _licenseRepository.CreateAsync(license);
        var result = await _licenseRepository.GetByIdAsync(created.Id);
        return MapToDto(result!);
    }

    public async Task<LicenseDto?> UpdateAsync(int id, LicenseUpdateDto dto)
    {
        var license = await _licenseRepository.GetByIdAsync(id);
        if (license == null) return null;
        var issueDateUtc = NormalizeToUtc(dto.IssueDate);
        DateTime? expiryDateUtc = dto.ExpiryDate.HasValue ? NormalizeToUtc(dto.ExpiryDate.Value) : null;
        if (expiryDateUtc.HasValue && expiryDateUtc < issueDateUtc)
            throw new InvalidOperationException("ExpiryDate cannot be earlier than IssueDate.");

        // If license number changed, ensure uniqueness
        if (!string.Equals(license.LicenseNumber, dto.LicenseNumber, StringComparison.OrdinalIgnoreCase) &&
            await _licenseRepository.LicenseNumberExistsAsync(dto.LicenseNumber))
        {
            throw new InvalidOperationException($"License number {dto.LicenseNumber} already exists.");
        }

    license.LicenseNumber = dto.LicenseNumber;
    license.IssueDate = issueDateUtc;
    license.ExpiryDate = expiryDateUtc;
        license.IsActive = dto.IsActive;

        var updated = await _licenseRepository.UpdateAsync(license);
        var result = await _licenseRepository.GetByIdAsync(updated.Id);
        return MapToDto(result!);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _licenseRepository.DeleteAsync(id);
    }

    private LicenseDto MapToDto(License license)
    {
        return new LicenseDto
        {
            Id = license.Id,
            AgentId = license.AgentId,
            AgentCode = license.Agent.AgentCode,
            LicenseNumber = license.LicenseNumber,
            IssueDate = license.IssueDate,
            ExpiryDate = license.ExpiryDate,
            IsActive = license.IsActive
        };
    }

    private static DateTime NormalizeToUtc(DateTime value)
    {
        return value.Kind switch
        {
            DateTimeKind.Utc => value,
            DateTimeKind.Local => value.ToUniversalTime(),
            _ => DateTime.SpecifyKind(value, DateTimeKind.Utc)
        };
    }
}