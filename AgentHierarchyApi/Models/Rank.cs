using System.Text.Json.Serialization;

namespace AgentHierarchyApi.Models;

public class Rank
{
    public int Id { get; set; }
    public string RankCode { get; set; } = string.Empty;
    public string RankName { get; set; } = string.Empty;
    public int Level { get; set; }

    // Navigation properties
    [JsonIgnore]
    public ICollection<Hierarchy> Hierarchies { get; set; } = new List<Hierarchy>();

    [JsonIgnore]
    public ICollection<Agent> Agents { get; set; } = new List<Agent>();
}
