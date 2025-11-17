using System.Text.Json.Serialization;

namespace AgentHierarchyApi.Models;

public class Leader
{
    public int Id { get; set; }
    public string RefId { get; set; } = string.Empty;
    public string PromoteType { get; set; } = string.Empty; // GM, AVP, VP, SVP
    public string? Affiliation { get; set; } // สังกัด
    public string? Branch { get; set; }
    public string? RefLicense { get; set; }
    public string? RefCompany { get; set; }
    public string? LastRank { get; set; } // A1-A9
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    // Navigation property
    [JsonIgnore]
    public Agent? Agent { get; set; }
}
