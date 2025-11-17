using AgentHierarchyApi.DTOs;
using AgentHierarchyApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgentHierarchyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeadersController : ControllerBase
{
    private readonly ILeaderService _leaderService;

    public LeadersController(ILeaderService leaderService)
    {
        _leaderService = leaderService;
    }

    /// <summary>
    /// Get all leaders
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeaderDto>>> GetAllLeaders()
    {
        var leaders = await _leaderService.GetAllLeadersAsync();
        return Ok(leaders);
    }

    /// <summary>
    /// Get leader by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaderDto>> GetLeaderById(int id)
    {
        var leader = await _leaderService.GetLeaderByIdAsync(id);
        if (leader == null)
            return NotFound($"Leader with ID {id} not found.");

        return Ok(leader);
    }

    /// <summary>
    /// Get leader by RefId (Agent Code)
    /// </summary>
    [HttpGet("ref/{refId}")]
    public async Task<ActionResult<LeaderDto>> GetLeaderByRefId(string refId)
    {
        var leader = await _leaderService.GetLeaderByRefIdAsync(refId);
        if (leader == null)
            return NotFound($"Leader with RefId {refId} not found.");

        return Ok(leader);
    }

    /// <summary>
    /// Get leaders by promote type (GM, AVP, VP, SVP)
    /// </summary>
    [HttpGet("promote-type/{promoteType}")]
    public async Task<ActionResult<IEnumerable<LeaderDto>>> GetLeadersByPromoteType(string promoteType)
    {
        var leaders = await _leaderService.GetLeadersByPromoteTypeAsync(promoteType);
        return Ok(leaders);
    }

    /// <summary>
    /// Get leaders by last rank (A1-A9)
    /// </summary>
    [HttpGet("last-rank/{lastRank}")]
    public async Task<ActionResult<IEnumerable<LeaderDto>>> GetLeadersByLastRank(string lastRank)
    {
        var leaders = await _leaderService.GetLeadersByLastRankAsync(lastRank);
        return Ok(leaders);
    }

    /// <summary>
    /// Create a new leader
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<LeaderDto>> CreateLeader([FromBody] LeaderCreateDto leaderDto)
    {
        try
        {
            var leader = await _leaderService.CreateLeaderAsync(leaderDto);
            return CreatedAtAction(nameof(GetLeaderById), new { id = leader.Id }, leader);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Update an existing leader
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<LeaderDto>> UpdateLeader(int id, [FromBody] LeaderUpdateDto leaderDto)
    {
        try
        {
            var leader = await _leaderService.UpdateLeaderAsync(id, leaderDto);
            if (leader == null)
                return NotFound($"Leader with ID {id} not found.");

            return Ok(leader);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delete a leader
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLeader(int id)
    {
        var result = await _leaderService.DeleteLeaderAsync(id);
        if (!result)
            return NotFound($"Leader with ID {id} not found.");

        return NoContent();
    }
}
