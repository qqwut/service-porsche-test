using System.Text.Json.Serialization;

namespace AgentHierarchyApi.Models;

public class Image
{
    public int Id { get; set; }
    public Guid Uuid { get; set; } = Guid.NewGuid();
    public string ImageCode { get; set; } = string.Empty;
    public string? RefId { get; set; } // เชื่อมกับ Client.ClientCode
    public string? ImageTypeCode { get; set; } // ประเภทรูปภาพ (PROFILE, ID_CARD, PASSPORT, etc.)
    public string? ImageCategory { get; set; } // หมวดหมู่ (PERSONAL, DOCUMENT, etc.)
    public string? FileName { get; set; }
    public string? FilePath { get; set; }
    public string? FileUrl { get; set; }
    public string? ContentType { get; set; } // MIME type (image/jpeg, image/png, etc.)
    public long? FileSize { get; set; } // ขนาดไฟล์ในหน่วย bytes
    public int? Width { get; set; }
    public int? Height { get; set; }
    public byte[]? ImageData { get; set; } // เก็บข้อมูลรูปภาพ (ถ้าต้องการเก็บใน DB)
    public string? ThumbnailUrl { get; set; }
    public byte[]? ThumbnailData { get; set; }
    public bool IsPrimary { get; set; } = false; // รูปหลัก
    public int? DisplayOrder { get; set; } // ลำดับการแสดงผล
    public bool IsActive { get; set; } = true;
    public string? Remark { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    public string? UpdatedBy { get; set; }

    // Navigation property
    [JsonIgnore]
    public Client? ReferenceClient { get; set; }
}
