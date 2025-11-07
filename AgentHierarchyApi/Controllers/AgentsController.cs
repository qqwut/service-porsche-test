using Microsoft.AspNetCore.Mvc;
using AgentHierarchyApi.DTOs;
using AgentHierarchyApi.Services;

namespace AgentHierarchyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgentsController : ControllerBase
{
    private readonly IAgentService _agentService;
    private readonly ILogger<AgentsController> _logger;

    public AgentsController(IAgentService agentService, ILogger<AgentsController> logger)
    {
        _agentService = agentService;
        _logger = logger;
    }

    /// <summary>
    /// Get all agents
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AgentDto>>> GetAllAgents()
    {
        try
        {
            var agents = await _agentService.GetAllAgentsAsync();
            return Ok(agents);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all agents");
            return StatusCode(500, "An error occurred while retrieving agents");
        }
    }

    /// <summary>
    /// Get agent by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<AgentDto>> GetAgentById(int id)
    {
        try
        {
            var agent = await _agentService.GetAgentByIdAsync(id);
            if (agent == null)
                return NotFound($"Agent with ID {id} not found");

            return Ok(agent);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting agent by ID {Id}", id);
            return StatusCode(500, "An error occurred while retrieving the agent");
        }
    }

    /// <summary>
    /// Get agent by code
    /// </summary>
    [HttpGet("code/{agentCode}")]
    public async Task<ActionResult<AgentDto>> GetAgentByCode(string agentCode)
    {
        try
        {
            var agent = await _agentService.GetAgentByCodeAsync(agentCode);
            if (agent == null)
                return NotFound($"Agent with code {agentCode} not found");

            return Ok(agent);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting agent by code {AgentCode}", agentCode);
            return StatusCode(500, "An error occurred while retrieving the agent");
        }
    }

    /// <summary>
    /// Get agents by rank (AG, AL, AE)
    /// </summary>
    [HttpGet("rank/{rankCode}")]
    public async Task<ActionResult<IEnumerable<AgentDto>>> GetAgentsByRank(string rankCode)
    {
        try
        {
            var agents = await _agentService.GetAgentsByRankAsync(rankCode);
            return Ok(agents);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting agents by rank {RankCode}", rankCode);
            return StatusCode(500, "An error occurred while retrieving agents");
        }
    }

    /// <summary>
    /// Get agents by hierarchy (A1-A9)
    /// </summary>
    [HttpGet("hierarchy/{hierarchyCode}")]
    public async Task<ActionResult<IEnumerable<AgentDto>>> GetAgentsByHierarchy(string hierarchyCode)
    {
        try
        {
            var agents = await _agentService.GetAgentsByHierarchyAsync(hierarchyCode);
            return Ok(agents);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting agents by hierarchy {HierarchyCode}", hierarchyCode);
            return StatusCode(500, "An error occurred while retrieving agents");
        }
    }

    /// <summary>
    /// Get agent hierarchy tree (AE -> AL -> AG)
    /// </summary>
    [HttpGet("hierarchy-tree")]
    public async Task<ActionResult<AgentHierarchyTreeDto>> GetAgentHierarchyTree([FromQuery] int? rootAgentId = null)
    {
        try
        {
            var tree = await _agentService.GetAgentHierarchyTreeAsync(rootAgentId);
            if (tree == null)
                return NotFound(rootAgentId.HasValue 
                    ? $"Agent with ID {rootAgentId} not found" 
                    : "No agents found");

            return Ok(tree);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting agent hierarchy tree");
            return StatusCode(500, "An error occurred while retrieving the hierarchy tree");
        }
    }

    /// <summary>
    /// Get agent hierarchy tree by agent code (AG -> AL -> AE)
    /// </summary>
    [HttpGet("hierarchy-tree/code/{agentCode}")]
    public async Task<ActionResult<AgentHierarchyTreeDto>> GetAgentHierarchyTreeByCode(string agentCode)
    {
        try
        {
            var tree = await _agentService.GetAgentHierarchyTreeByCodeAsync(agentCode);
            if (tree == null)
                return NotFound($"Agent with code {agentCode} not found");

            return Ok(tree);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting agent hierarchy tree by code {AgentCode}", agentCode);
            return StatusCode(500, "An error occurred while retrieving the hierarchy tree");
        }
    }

    /// <summary>
    /// Create a new agent
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<AgentDto>> CreateAgent([FromBody] AgentCreateDto agentDto)
    {
        try
        {
            var agent = await _agentService.CreateAgentAsync(agentDto);
            return CreatedAtAction(nameof(GetAgentById), new { id = agent.Id }, agent);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Validation error creating agent");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating agent");
            return StatusCode(500, "An error occurred while creating the agent");
        }
    }

    /// <summary>
    /// Update an existing agent
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<AgentDto>> UpdateAgent(int id, [FromBody] AgentUpdateDto agentDto)
    {
        try
        {
            var agent = await _agentService.UpdateAgentAsync(id, agentDto);
            if (agent == null)
                return NotFound($"Agent with ID {id} not found");

            return Ok(agent);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Validation error updating agent");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating agent {Id}", id);
            return StatusCode(500, "An error occurred while updating the agent");
        }
    }

    /// <summary>
    /// Delete an agent (soft delete)
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAgent(int id)
    {
        try
        {
            var result = await _agentService.DeleteAgentAsync(id);
            if (!result)
                return NotFound($"Agent with ID {id} not found");

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting agent {Id}", id);
            return StatusCode(500, "An error occurred while deleting the agent");
        }
    }
}
