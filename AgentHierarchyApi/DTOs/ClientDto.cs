namespace AgentHierarchyApi.DTOs;

public class ClientDto
{
    public int Id { get; set; }
    public string ClientCode { get; set; } = string.Empty;
    public string? ClientTypeCode { get; set; }
    public string? IdentityType { get; set; }
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
    public string? MaritalStatusCode { get; set; }
    public string? PrimaryOccupationBusinessType { get; set; }
    public string? PrimaryOccupationOrganizationName { get; set; }
    public string? SecondaryOccupationBusinessType { get; set; }
    public string? SecondaryOccupationOrganizationName { get; set; }
    public decimal? PremiumCapacity { get; set; }
    public string? LanguagePreferenceCode { get; set; }
    public string? ReceivesEmailNews { get; set; }
    public string? OrganizationBusinessType { get; set; }
    public bool? TerminatedFlag { get; set; }
    public DateTime? TerminatedDate { get; set; }
    public string? TerminatedReason { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Remark { get; set; }
    public string? RefId { get; set; } // Agent Reference (AgentCode)
    
    // Related data
    public List<ClientAddressDto>? Addresses { get; set; }
    public List<ClientContactDto>? Contacts { get; set; }
    public List<ClientRoleDto>? Roles { get; set; }
    public List<ImageDto>? Images { get; set; } // Images with base64 data
}

public class ClientAddressDto
{
    public int Id { get; set; }
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
}

public class ClientContactDto
{
    public int Id { get; set; }
    public string ClientCode { get; set; } = string.Empty;
    public string? ContactTypeCode { get; set; }
    public string ContactValue { get; set; } = string.Empty;
    public bool IsPrimary { get; set; } = false;
    public string? Remark { get; set; }
}

public class ClientRoleDto
{
    public int Id { get; set; }
    public string ClientCode { get; set; } = string.Empty;
    public string? RoleCode { get; set; }
    public string? ReferenceNo { get; set; }
    public string? PolicyNo { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public int? RoleSeqNo { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Remark { get; set; }
}

public class CreateClientDto
{
    public string ClientCode { get; set; } = string.Empty;
    public string? ClientTypeCode { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? OrganizationName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? GenderCode { get; set; }
    public string? NationalityCode { get; set; }
    public string? RefId { get; set; } // Agent Reference
    public List<CreateClientAddressDto>? Addresses { get; set; }
    public List<CreateClientContactDto>? Contacts { get; set; }
}

public class CreateClientAddressDto
{
    public string? AddressTypeCode { get; set; }
    public string? AddressNo { get; set; }
    public string SubdistrictCode { get; set; } = string.Empty;
    public string DistrictCode { get; set; } = string.Empty;
    public string ProvinceCode { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public bool IsPrimary { get; set; } = false;
}

public class CreateClientContactDto
{
    public string? ContactTypeCode { get; set; }
    public string ContactValue { get; set; } = string.Empty;
    public bool IsPrimary { get; set; } = false;
}

public class UpdateClientDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? OrganizationName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? GenderCode { get; set; }
    public string? NationalityCode { get; set; }
    public string? RefId { get; set; }
    public bool IsActive { get; set; } = true;
}
