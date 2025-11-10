using AgentHierarchyApi.DTOs;
using AgentHierarchyApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgentHierarchyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly ILogger<ClientsController> _logger;

    public ClientsController(IClientService clientService, ILogger<ClientsController> logger)
    {
        _clientService = clientService;
        _logger = logger;
    }

    /// <summary>
    /// Get all clients
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetAllClients()
    {
        try
        {
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all clients");
            return StatusCode(500, "An error occurred while retrieving clients");
        }
    }

    /// <summary>
    /// Get client by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDto>> GetClientById(int id)
    {
        try
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
                return NotFound($"Client with ID {id} not found");

            return Ok(client);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting client with ID {Id}", id);
            return StatusCode(500, "An error occurred while retrieving the client");
        }
    }

    /// <summary>
    /// Get client by client code
    /// </summary>
    [HttpGet("code/{clientCode}")]
    public async Task<ActionResult<ClientDto>> GetClientByCode(string clientCode)
    {
        try
        {
            var client = await _clientService.GetClientByCodeAsync(clientCode);
            if (client == null)
                return NotFound($"Client with code '{clientCode}' not found");

            return Ok(client);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting client with code {ClientCode}", clientCode);
            return StatusCode(500, "An error occurred while retrieving the client");
        }
    }

    /// <summary>
    /// Get first client by agent code (since AgentCode is unique per client)
    /// </summary>
    [HttpGet("agent/{agentCode}")]
    public async Task<ActionResult<ClientDto>> GetClientByAgentCode(string agentCode)
    {
        try
        {
            var client = await _clientService.GetClientByAgentCodeAsync(agentCode);
            if (client == null)
                return NotFound($"No client found for agent code '{agentCode}'");

            return Ok(client);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting client for agent {AgentCode}", agentCode);
            return StatusCode(500, "An error occurred while retrieving the client");
        }
    }

    /// <summary>
    /// Create a new client
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ClientDto>> CreateClient([FromBody] CreateClientDto createClientDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var client = await _clientService.CreateClientAsync(createClientDto);
            return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Invalid operation while creating client");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating client");
            return StatusCode(500, "An error occurred while creating the client");
        }
    }

    /// <summary>
    /// Update an existing client
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<ClientDto>> UpdateClient(int id, [FromBody] UpdateClientDto updateClientDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var client = await _clientService.UpdateClientAsync(id, updateClientDto);
            if (client == null)
                return NotFound($"Client with ID {id} not found");

            return Ok(client);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating client with ID {Id}", id);
            return StatusCode(500, "An error occurred while updating the client");
        }
    }

    /// <summary>
    /// Delete a client
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteClient(int id)
    {
        try
        {
            var result = await _clientService.DeleteClientAsync(id);
            if (!result)
                return NotFound($"Client with ID {id} not found");

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting client with ID {Id}", id);
            return StatusCode(500, "An error occurred while deleting the client");
        }
    }
}
