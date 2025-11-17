namespace AgentHierarchyApi.DTOs;

public class LeaderDto
{
    public int Id { get; set; }
    public string RefId { get; set; } = string.Empty;
    public string PromoteType { get; set; } = string.Empty; // GM, AVP, VP, SVP
    public string? Affiliation { get; set; } // สังกัด
    public string? Branch { get; set; }
    public string? RefLicense { get; set; }
    public string? RefCompany { get; set; }
    public string? LastRank { get; set; } // A1-A9
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
}

public class LeaderCreateDto
{
    public string RefId { get; set; } = string.Empty;
    public string PromoteType { get; set; } = string.Empty; // GM, AVP, VP, SVP
    public string? Affiliation { get; set; }
    public string? Branch { get; set; }
    public string? RefLicense { get; set; }
    public string? RefCompany { get; set; }
    public string? LastRank { get; set; } // A1-A9
    public string? CreatedBy { get; set; }
}

public class LeaderUpdateDto
{
    public string PromoteType { get; set; } = string.Empty;
    public string? Affiliation { get; set; }
    public string? Branch { get; set; }
    public string? RefLicense { get; set; }
    public string? RefCompany { get; set; }
    public string? LastRank { get; set; }
    public string? UpdatedBy { get; set; }
}
