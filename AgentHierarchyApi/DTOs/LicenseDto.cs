namespace AgentHierarchyApi.DTOs;

public class LicenseDto
{
    public int Id { get; set; }
    public int AgentId { get; set; }
    public string AgentCode { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public bool IsActive { get; set; }
}

public class LicenseCreateDto
{
    public int AgentId { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; } = DateTime.UtcNow.Date;
    public DateTime? ExpiryDate { get; set; }
}

public class LicenseUpdateDto
{
    public string LicenseNumber { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public bool IsActive { get; set; }
}