using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgentHierarchyApi.Data;
using AgentHierarchyApi.Models;

namespace AgentHierarchyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HierarchiesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<HierarchiesController> _logger;

    public HierarchiesController(ApplicationDbContext context, ILogger<HierarchiesController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Get all hierarchies
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hierarchy>>> GetAllHierarchies()
    {
        try
        {
            var hierarchies = await _context.Hierarchies
                .Include(h => h.Rank)
                .OrderBy(h => h.Level)
                .ToListAsync();
            return Ok(hierarchies);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all hierarchies");
            return StatusCode(500, "An error occurred while retrieving hierarchies");
        }
    }

    /// <summary>
    /// Get hierarchy by code
    /// </summary>
    [HttpGet("{hierarchyCode}")]
    public async Task<ActionResult<Hierarchy>> GetHierarchyByCode(string hierarchyCode)
    {
        try
        {
            var hierarchy = await _context.Hierarchies
                .Include(h => h.Rank)
                .FirstOrDefaultAsync(h => h.HierarchyCode == hierarchyCode);

            if (hierarchy == null)
                return NotFound($"Hierarchy {hierarchyCode} not found");

            return Ok(hierarchy);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting hierarchy by code {HierarchyCode}", hierarchyCode);
            return StatusCode(500, "An error occurred while retrieving the hierarchy");
        }
    }

    /// <summary>
    /// Get hierarchies by rank
    /// </summary>
    [HttpGet("rank/{rankCode}")]
    public async Task<ActionResult<IEnumerable<Hierarchy>>> GetHierarchiesByRank(string rankCode)
    {
        try
        {
            var hierarchies = await _context.Hierarchies
                .Include(h => h.Rank)
                .Where(h => h.Rank.RankCode == rankCode)
                .OrderBy(h => h.Level)
                .ToListAsync();

            return Ok(hierarchies);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting hierarchies by rank {RankCode}", rankCode);
            return StatusCode(500, "An error occurred while retrieving hierarchies");
        }
    }
}
