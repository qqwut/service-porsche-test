using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgentHierarchyApi.Data;
using AgentHierarchyApi.Models;

namespace AgentHierarchyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RanksController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RanksController> _logger;

    public RanksController(ApplicationDbContext context, ILogger<RanksController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Get all ranks
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rank>>> GetAllRanks()
    {
        try
        {
            var ranks = await _context.Ranks
                .OrderBy(r => r.Level)
                .ToListAsync();
            return Ok(ranks);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all ranks");
            return StatusCode(500, "An error occurred while retrieving ranks");
        }
    }

    /// <summary>
    /// Get rank by code
    /// </summary>
    [HttpGet("{rankCode}")]
    public async Task<ActionResult<Rank>> GetRankByCode(string rankCode)
    {
        try
        {
            var rank = await _context.Ranks
                .FirstOrDefaultAsync(r => r.RankCode == rankCode);

            if (rank == null)
                return NotFound($"Rank {rankCode} not found");

            return Ok(rank);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting rank by code {RankCode}", rankCode);
            return StatusCode(500, "An error occurred while retrieving the rank");
        }
    }
}
