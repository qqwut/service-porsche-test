using System.Text.Json.Serialization;

namespace AgentHierarchyApi.Models;

public class Client
{
    public int Id { get; set; }
    public Guid Uuid { get; set; } = Guid.NewGuid();
    public string ClientCode { get; set; } = string.Empty;
    public string? ClientTypeCode { get; set; }
    public string? IdentityType { get; set; }
    public byte[]? IdentityNo { get; set; }
    public bool? IdentityPermanent { get; set; }
    public DateTime? IdentityExpiryDate { get; set; }
    public string? TitleCode { get; set; }
    public string? OrganizationName { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? SuffixName { get; set; }
    public string? OrganizationNameEn { get; set; }
    public string? FirstNameEn { get; set; }
    public string? MiddleNameEn { get; set; }
    public string? LastNameEn { get; set; }
    public string? SuffixNameEn { get; set; }
    public string? NationalityCode { get; set; }
    public string? PlaceOfBirthCountryCode { get; set; }
    public string? PlaceOfBirthCity { get; set; }
    public DateTime? OrganizationRegistrationDate { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? GenderCode { get; set; }
    public byte[]? ReligionCode { get; set; }
    public string? MaritalStatusCode { get; set; }
    public byte[]? EducationLevelCode { get; set; }
    public byte[]? PrimaryOccupationCode { get; set; }
    public byte[]? PrimaryOccupationPositionCode { get; set; }
    public string? PrimaryOccupationBusinessType { get; set; }
    public string? PrimaryOccupationOrganizationName { get; set; }
    public byte[]? PrimaryIncomeLevelCode { get; set; }
    public byte[]? PrimaryIncomePerYear { get; set; }
    public byte[]? SecondaryOccupationCode { get; set; }
    public byte[]? SecondaryOccupationPositionCode { get; set; }
    public string? SecondaryOccupationBusinessType { get; set; }
    public string? SecondaryOccupationOrganizationName { get; set; }
    public byte[]? SecondaryIncomeLevelCode { get; set; }
    public byte[]? SecondaryIncomePerYear { get; set; }
    public decimal? PremiumCapacity { get; set; }
    public string? LanguagePreferenceCode { get; set; }
    public string? ReceivesEmailNews { get; set; }
    public string? OrganizationBusinessType { get; set; }
    public byte[]? TaxId { get; set; }
    public bool? TerminatedFlag { get; set; }
    public DateTime? TerminatedDate { get; set; }
    public string? TerminatedReason { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Remark { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    public string? UpdatedBy { get; set; }

    // Foreign Key to Agent (RefId = AgentCode)
    public string? RefId { get; set; } // เชื่อมกับ Agent.AgentCode

    // Navigation properties
    [JsonIgnore]
    public Agent? ReferenceAgent { get; set; }
    
    [JsonIgnore]
    public ICollection<ClientAddress> Addresses { get; set; } = new List<ClientAddress>();
    
    [JsonIgnore]
    public ICollection<ClientContact> Contacts { get; set; } = new List<ClientContact>();
    
    [JsonIgnore]
    public ICollection<ClientRole> Roles { get; set; } = new List<ClientRole>();
    
    [JsonIgnore]
    public ICollection<Image> Images { get; set; } = new List<Image>();
}
