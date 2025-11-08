using Microsoft.AspNetCore.Mvc;
using AgentHierarchyApi.DTOs;
using AgentHierarchyApi.Services;

namespace AgentHierarchyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LicensesController : ControllerBase
{
    private readonly ILicenseService _licenseService;
    private readonly ILogger<LicensesController> _logger;

    public LicensesController(ILicenseService licenseService, ILogger<LicensesController> logger)
    {
        _licenseService = licenseService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LicenseDto>>> GetAll()
    {
        try
        {
            var items = await _licenseService.GetAllAsync();
            return Ok(items);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting licenses");
            return StatusCode(500, "An error occurred while retrieving licenses");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LicenseDto>> GetById(int id)
    {
        try
        {
            var item = await _licenseService.GetByIdAsync(id);
            if (item == null) return NotFound($"License with ID {id} not found");
            return Ok(item);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting license by ID {Id}", id);
            return StatusCode(500, "An error occurred while retrieving the license");
        }
    }

    [HttpGet("agent/{agentId}")]
    public async Task<ActionResult<IEnumerable<LicenseDto>>> GetByAgentId(int agentId)
    {
        try
        {
            var items = await _licenseService.GetByAgentIdAsync(agentId);
            return Ok(items);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting licenses for agent {AgentId}", agentId);
            return StatusCode(500, "An error occurred while retrieving licenses");
        }
    }

    [HttpPost]
    public async Task<ActionResult<LicenseDto>> Create([FromBody] LicenseCreateDto dto)
    {
        try
        {
            var created = await _licenseService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Validation error creating license");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating license");
            return StatusCode(500, "An error occurred while creating the license");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<LicenseDto>> Update(int id, [FromBody] LicenseUpdateDto dto)
    {
        try
        {
            var updated = await _licenseService.UpdateAsync(id, dto);
            if (updated == null) return NotFound($"License with ID {id} not found");
            return Ok(updated);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Validation error updating license");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating license {Id}", id);
            return StatusCode(500, "An error occurred while updating the license");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var deleted = await _licenseService.DeleteAsync(id);
            if (!deleted) return NotFound($"License with ID {id} not found");
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting license {Id}", id);
            return StatusCode(500, "An error occurred while deleting the license");
        }
    }
}