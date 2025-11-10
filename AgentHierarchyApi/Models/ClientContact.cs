using System.Text.Json.Serialization;

namespace AgentHierarchyApi.Models;

public class ClientContact
{
    public int Id { get; set; }
    public Guid Uuid { get; set; } = Guid.NewGuid();
    public string ClientCode { get; set; } = string.Empty;
    public string? ContactTypeCode { get; set; }
    public string ContactValue { get; set; } = string.Empty;
    public bool IsPrimary { get; set; } = false;
    public string? Remark { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    public string UpdatedBy { get; set; } = string.Empty;

    // Navigation property
    [JsonIgnore]
    public Client Client { get; set; } = null!;
}
