namespace AgentHierarchyApi.Models;

public class Hierarchy
{
    public int Id { get; set; }
    public string HierarchyCode { get; set; } = string.Empty;
    public string HierarchyName { get; set; } = string.Empty;
    public int RankId { get; set; }
    public int Level { get; set; }

    // Navigation properties
    public Rank Rank { get; set; } = null!;
    public ICollection<Agent> Agents { get; set; } = new List<Agent>();
}
