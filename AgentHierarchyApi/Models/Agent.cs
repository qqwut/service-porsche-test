using System.Text.Json.Serialization;

namespace AgentHierarchyApi.Models;

public class Agent
{
    public int Id { get; set; }
    public string AgentCode { get; set; } = string.Empty;
    public string AgentName { get; set; } = string.Empty;
    public string AgentType { get; set; } = "Agent"; // Broker | Agent | Direct
    public string? LeaderCode { get; set; }
    public int HierarchyId { get; set; }
    public int? ParentAgentId { get; set; }
    public int RankId { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public Hierarchy Hierarchy { get; set; } = null!;
    public Rank Rank { get; set; } = null!;
    [JsonIgnore]
    public Agent? ParentAgent { get; set; }
    [JsonIgnore]
    public ICollection<Agent> ChildAgents { get; set; } = new List<Agent>();
    public ICollection<License> Licenses { get; set; } = new List<License>();
}
