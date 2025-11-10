namespace AgentHierarchyApi.DTOs
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string ImageCode { get; set; } = string.Empty;
        public string RefId { get; set; } = string.Empty;
        public string? ImageTypeCode { get; set; }
        public string? ImageCategory { get; set; }
        public string? FileName { get; set; }
        public string? ImageBase64 { get; set; } // Base64 encoded image data
        public string? ContentType { get; set; }
        public long? FileSize { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string? ThumbnailBase64 { get; set; } // Base64 encoded thumbnail
        public bool IsPrimary { get; set; }
        public int? DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public string? Remark { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class CreateImageDto
    {
        public string ImageCode { get; set; } = string.Empty;
        public string RefId { get; set; } = string.Empty;
        public string? ImageTypeCode { get; set; }
        public string? ImageCategory { get; set; }
        public string? FileName { get; set; }
        public string ImageBase64 { get; set; } = string.Empty; // Base64 encoded image data (required)
        public string? ContentType { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string? ThumbnailBase64 { get; set; }
        public bool IsPrimary { get; set; } = false;
        public int? DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Remark { get; set; }
        public string? CreatedBy { get; set; }
    }

    public class UpdateImageDto
    {
        public string? FileName { get; set; }
        public string? ImageTypeCode { get; set; }
        public string? ImageCategory { get; set; }
        public string? ImageBase64 { get; set; } // Optional: only if updating the actual image
        public string? ContentType { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string? ThumbnailBase64 { get; set; }
        public bool? IsPrimary { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }
        public string? Remark { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
