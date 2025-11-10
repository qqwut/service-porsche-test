using System.Text.Json.Serialization;

namespace AgentHierarchyApi.Models;

public class ClientRole
{
    public int Id { get; set; }
    public Guid Uuid { get; set; } = Guid.NewGuid();
    public string ClientCode { get; set; } = string.Empty;
    public string? RoleCode { get; set; } // รหัสบทบาท (เช่น POLICYHOLDER, INSURED, BENEFICIARY)
    public string? ReferenceNo { get; set; } // รหัสอ้างอิงของเอกสาร/รายการที่บทบาทนั้นเกี่ยวข้อง
    public string? PolicyNo { get; set; } // เลขที่กรมธรรม์
    public DateTime? EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public int? RoleSeqNo { get; set; } // ลำดับของบทบาท (กรณีมีหลายบทบาทในเอกสารเดียวกัน)
    public bool IsActive { get; set; } = true;
    public string? Remark { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    public string UpdatedBy { get; set; } = string.Empty;

    // Navigation property
    [JsonIgnore]
    public Client Client { get; set; } = null!;
}
