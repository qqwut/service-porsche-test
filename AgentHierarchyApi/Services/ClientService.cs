using AgentHierarchyApi.DTOs;
using AgentHierarchyApi.Models;
using AgentHierarchyApi.Repositories;

namespace AgentHierarchyApi.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IImageRepository _imageRepository;

    public ClientService(IClientRepository clientRepository, IImageRepository imageRepository)
    {
        _clientRepository = clientRepository;
        _imageRepository = imageRepository;
    }

    public async Task<IEnumerable<ClientDto>> GetAllClientsAsync()
    {
        var clients = await _clientRepository.GetAllClientsAsync();
        return clients.Select(MapToDto);
    }

    public async Task<ClientDto?> GetClientByIdAsync(int id)
    {
        var client = await _clientRepository.GetClientByIdAsync(id);
        return client == null ? null : MapToDto(client);
    }

    public async Task<ClientDto?> GetClientByCodeAsync(string clientCode)
    {
        var client = await _clientRepository.GetClientByCodeAsync(clientCode);
        if (client == null)
            return null;

        var clientDto = MapToDto(client);
        
        // Load images for this client
        var images = await _imageRepository.GetByRefIdAsync(clientCode);
        clientDto.Images = images.Select(img => new ImageDto
        {
            Id = img.Id,
            ImageCode = img.ImageCode,
            RefId = img.RefId ?? string.Empty,
            ImageTypeCode = img.ImageTypeCode,
            ImageCategory = img.ImageCategory,
            FileName = img.FileName,
            ImageBase64 = img.ImageData != null ? Convert.ToBase64String(img.ImageData) : null,
            ContentType = img.ContentType,
            FileSize = img.FileSize,
            Width = img.Width,
            Height = img.Height,
            ThumbnailBase64 = img.ThumbnailData != null ? Convert.ToBase64String(img.ThumbnailData) : null,
            IsPrimary = img.IsPrimary,
            DisplayOrder = img.DisplayOrder,
            IsActive = img.IsActive,
            Remark = img.Remark,
            CreatedDate = img.CreatedDate,
            UpdatedDate = img.UpdatedDate
        }).ToList();

        return clientDto;
    }

    public async Task<ClientDto?> GetClientByAgentCodeAsync(string agentCode)
    {
        var clients = await _clientRepository.GetClientsByAgentCodeAsync(agentCode);
        var client = clients.FirstOrDefault();
        
        if (client == null)
            return null;

        var clientDto = MapToDto(client);
        
        // Load images for this client
        var images = await _imageRepository.GetByRefIdAsync(client.ClientCode);
        clientDto.Images = images.Select(img => new ImageDto
        {
            Id = img.Id,
            ImageCode = img.ImageCode,
            RefId = img.RefId ?? string.Empty,
            ImageTypeCode = img.ImageTypeCode,
            ImageCategory = img.ImageCategory,
            FileName = img.FileName,
            ImageBase64 = img.ImageData != null ? Convert.ToBase64String(img.ImageData) : null,
            ContentType = img.ContentType,
            FileSize = img.FileSize,
            Width = img.Width,
            Height = img.Height,
            ThumbnailBase64 = img.ThumbnailData != null ? Convert.ToBase64String(img.ThumbnailData) : null,
            IsPrimary = img.IsPrimary,
            DisplayOrder = img.DisplayOrder,
            IsActive = img.IsActive,
            Remark = img.Remark,
            CreatedDate = img.CreatedDate,
            UpdatedDate = img.UpdatedDate
        }).ToList();

        return clientDto;
    }

    public async Task<ClientDto> CreateClientAsync(CreateClientDto createClientDto)
    {
        // Check if client code already exists
        if (await _clientRepository.ClientCodeExistsAsync(createClientDto.ClientCode))
        {
            throw new InvalidOperationException($"Client with code '{createClientDto.ClientCode}' already exists.");
        }

        var client = new Client
        {
            ClientCode = createClientDto.ClientCode,
            ClientTypeCode = createClientDto.ClientTypeCode,
            FirstName = createClientDto.FirstName,
            LastName = createClientDto.LastName,
            OrganizationName = createClientDto.OrganizationName,
            DateOfBirth = createClientDto.DateOfBirth,
            GenderCode = createClientDto.GenderCode,
            NationalityCode = createClientDto.NationalityCode,
            RefId = createClientDto.RefId,
            IsActive = true,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        };

        // Add addresses if provided
        if (createClientDto.Addresses != null && createClientDto.Addresses.Any())
        {
            foreach (var addressDto in createClientDto.Addresses)
            {
                client.Addresses.Add(new ClientAddress
                {
                    ClientCode = createClientDto.ClientCode,
                    AddressTypeCode = addressDto.AddressTypeCode,
                    AddressNo = addressDto.AddressNo,
                    SubdistrictCode = addressDto.SubdistrictCode,
                    DistrictCode = addressDto.DistrictCode,
                    ProvinceCode = addressDto.ProvinceCode,
                    PostalCode = addressDto.PostalCode,
                    IsPrimary = addressDto.IsPrimary,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                });
            }
        }

        // Add contacts if provided
        if (createClientDto.Contacts != null && createClientDto.Contacts.Any())
        {
            foreach (var contactDto in createClientDto.Contacts)
            {
                client.Contacts.Add(new ClientContact
                {
                    ClientCode = createClientDto.ClientCode,
                    ContactTypeCode = contactDto.ContactTypeCode,
                    ContactValue = contactDto.ContactValue,
                    IsPrimary = contactDto.IsPrimary,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                });
            }
        }

        var createdClient = await _clientRepository.CreateClientAsync(client);
        return MapToDto(createdClient);
    }

    public async Task<ClientDto?> UpdateClientAsync(int id, UpdateClientDto updateClientDto)
    {
        var client = await _clientRepository.GetClientByIdAsync(id);
        if (client == null)
            return null;

        // Update fields
        if (updateClientDto.FirstName != null)
            client.FirstName = updateClientDto.FirstName;
        
        if (updateClientDto.LastName != null)
            client.LastName = updateClientDto.LastName;
        
        if (updateClientDto.OrganizationName != null)
            client.OrganizationName = updateClientDto.OrganizationName;
        
        if (updateClientDto.DateOfBirth.HasValue)
            client.DateOfBirth = updateClientDto.DateOfBirth;
        
        if (updateClientDto.GenderCode != null)
            client.GenderCode = updateClientDto.GenderCode;
        
        if (updateClientDto.NationalityCode != null)
            client.NationalityCode = updateClientDto.NationalityCode;
        
        if (updateClientDto.RefId != null)
            client.RefId = updateClientDto.RefId;
        
        client.IsActive = updateClientDto.IsActive;
        client.UpdatedDate = DateTime.UtcNow;

        var updatedClient = await _clientRepository.UpdateClientAsync(client);
        return MapToDto(updatedClient);
    }

    public async Task<bool> DeleteClientAsync(int id)
    {
        return await _clientRepository.DeleteClientAsync(id);
    }

    private static ClientDto MapToDto(Client client)
    {
        return new ClientDto
        {
            Id = client.Id,
            ClientCode = client.ClientCode,
            ClientTypeCode = client.ClientTypeCode,
            IdentityType = client.IdentityType,
            IdentityPermanent = client.IdentityPermanent,
            IdentityExpiryDate = client.IdentityExpiryDate,
            TitleCode = client.TitleCode,
            OrganizationName = client.OrganizationName,
            FirstName = client.FirstName,
            MiddleName = client.MiddleName,
            LastName = client.LastName,
            SuffixName = client.SuffixName,
            OrganizationNameEn = client.OrganizationNameEn,
            FirstNameEn = client.FirstNameEn,
            MiddleNameEn = client.MiddleNameEn,
            LastNameEn = client.LastNameEn,
            SuffixNameEn = client.SuffixNameEn,
            NationalityCode = client.NationalityCode,
            PlaceOfBirthCountryCode = client.PlaceOfBirthCountryCode,
            PlaceOfBirthCity = client.PlaceOfBirthCity,
            OrganizationRegistrationDate = client.OrganizationRegistrationDate,
            DateOfBirth = client.DateOfBirth,
            GenderCode = client.GenderCode,
            MaritalStatusCode = client.MaritalStatusCode,
            PrimaryOccupationBusinessType = client.PrimaryOccupationBusinessType,
            PrimaryOccupationOrganizationName = client.PrimaryOccupationOrganizationName,
            SecondaryOccupationBusinessType = client.SecondaryOccupationBusinessType,
            SecondaryOccupationOrganizationName = client.SecondaryOccupationOrganizationName,
            PremiumCapacity = client.PremiumCapacity,
            LanguagePreferenceCode = client.LanguagePreferenceCode,
            ReceivesEmailNews = client.ReceivesEmailNews,
            OrganizationBusinessType = client.OrganizationBusinessType,
            TerminatedFlag = client.TerminatedFlag,
            TerminatedDate = client.TerminatedDate,
            TerminatedReason = client.TerminatedReason,
            IsActive = client.IsActive,
            Remark = client.Remark,
            RefId = client.RefId,
            Addresses = client.Addresses?.Select(a => new ClientAddressDto
            {
                Id = a.Id,
                ClientCode = a.ClientCode,
                AddressTypeCode = a.AddressTypeCode,
                AddressWorkplaceName = a.AddressWorkplaceName,
                AddressNo = a.AddressNo,
                AddressMoo = a.AddressMoo,
                AddressDetail = a.AddressDetail,
                AddressVillageBuilding = a.AddressVillageBuilding,
                AddressAlley = a.AddressAlley,
                AddressRoad = a.AddressRoad,
                SubdistrictCode = a.SubdistrictCode,
                DistrictCode = a.DistrictCode,
                ProvinceCode = a.ProvinceCode,
                PostalCode = a.PostalCode,
                CountryCode = a.CountryCode,
                IsPrimary = a.IsPrimary,
                Remark = a.Remark
            }).ToList(),
            Contacts = client.Contacts?.Select(c => new ClientContactDto
            {
                Id = c.Id,
                ClientCode = c.ClientCode,
                ContactTypeCode = c.ContactTypeCode,
                ContactValue = c.ContactValue,
                IsPrimary = c.IsPrimary,
                Remark = c.Remark
            }).ToList(),
            Roles = client.Roles?.Select(r => new ClientRoleDto
            {
                Id = r.Id,
                ClientCode = r.ClientCode,
                RoleCode = r.RoleCode,
                ReferenceNo = r.ReferenceNo,
                PolicyNo = r.PolicyNo,
                EffectiveDate = r.EffectiveDate,
                ExpiryDate = r.ExpiryDate,
                RoleSeqNo = r.RoleSeqNo,
                IsActive = r.IsActive,
                Remark = r.Remark
            }).ToList()
        };
    }
}
