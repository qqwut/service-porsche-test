using System.Text.Json.Serialization;

namespace AgentHierarchyApi.Models;

public class ClientAddress
{
    public int Id { get; set; }
    public Guid Uuid { get; set; } = Guid.NewGuid();
    public string ClientCode { get; set; } = string.Empty;
    public string? AddressTypeCode { get; set; }
    public string? AddressWorkplaceName { get; set; }
    public string? AddressNo { get; set; }
    public string? AddressMoo { get; set; }
    public string? AddressDetail { get; set; }
    public string? AddressVillageBuilding { get; set; }
    public string? AddressAlley { get; set; }
    public string? AddressRoad { get; set; }
    public string SubdistrictCode { get; set; } = string.Empty;
    public string DistrictCode { get; set; } = string.Empty;
    public string ProvinceCode { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string CountryCode { get; set; } = "THA";
    public bool IsPrimary { get; set; } = false;
    public string? Remark { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    public string? UpdatedBy { get; set; }

    // Navigation property
    [JsonIgnore]
    public Client Client { get; set; } = null!;
}
