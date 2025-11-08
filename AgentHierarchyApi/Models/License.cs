namespace AgentHierarchyApi.Models;

public class License
{
    public int Id { get; set; }
    public int AgentId { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; } = DateTime.UtcNow.Date;
    public DateTime? ExpiryDate { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

    // Navigation
    public Agent Agent { get; set; } = null!;
}