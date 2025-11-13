namespace AgentHierarchyApi.DTOs;

public class AgentDto
{
    public int Id { get; set; }
    public string AgentCode { get; set; } = string.Empty;
    public string AgentName { get; set; } = string.Empty;
    public string AgentType { get; set; } = "Agent";
    public string? LeaderCode { get; set; }
    public string HierarchyCode { get; set; } = string.Empty;
    public string RankCode { get; set; } = string.Empty;
    public int? ParentAgentId { get; set; }
    public string? ParentAgentCode { get; set; }
    public bool IsActive { get; set; }
}

public class AgentCreateDto
{
    public string AgentCode { get; set; } = string.Empty;
    public string AgentName { get; set; } = string.Empty;
    public string AgentType { get; set; } = "Agent";
    public string? LeaderCode { get; set; }
    public string HierarchyCode { get; set; } = string.Empty;
    public int? ParentAgentId { get; set; }
}

public class AgentUpdateDto
{
    public string AgentName { get; set; } = string.Empty;
    public string AgentType { get; set; } = "Agent";
    public string? LeaderCode { get; set; }
    public string HierarchyCode { get; set; } = string.Empty;
    public int? ParentAgentId { get; set; }
    public bool IsActive { get; set; }
}

public class AgentHierarchyTreeDto
{
    public int Id { get; set; }
    public string AgentCode { get; set; } = string.Empty;
    public string AgentName { get; set; } = string.Empty;
    public string AgentType { get; set; } = "Agent";
    public string? LeaderCode { get; set; }
    public string HierarchyCode { get; set; } = string.Empty;
    public string RankCode { get; set; } = string.Empty;
    public List<AgentHierarchyTreeDto> Children { get; set; } = new();
}

public class AgentUpwardTreeDto
{
    public int Id { get; set; }
    public string AgentCode { get; set; } = string.Empty;
    public string AgentName { get; set; } = string.Empty;
    public string AgentType { get; set; } = "Agent";
    public string? LeaderCode { get; set; }
    public string HierarchyCode { get; set; } = string.Empty;
    public string RankCode { get; set; } = string.Empty;
    public int? ParentAgentId { get; set; }
    public AgentUpwardTreeDto? Parent { get; set; }
}
