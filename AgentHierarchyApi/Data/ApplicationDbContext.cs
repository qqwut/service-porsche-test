using Microsoft.EntityFrameworkCore;
using AgentHierarchyApi.Models;

namespace AgentHierarchyApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Rank> Ranks { get; set; } = null!;
    public DbSet<Hierarchy> Hierarchies { get; set; } = null!;
    public DbSet<Agent> Agents { get; set; } = null!;
    public DbSet<License> Licenses { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<ClientAddress> ClientAddresses { get; set; } = null!;
    public DbSet<ClientContact> ClientContacts { get; set; } = null!;
    public DbSet<ClientRole> ClientRoles { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Rank entity
        modelBuilder.Entity<Rank>(entity =>
        {
            entity.ToTable("ranks");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.RankCode).IsRequired().HasMaxLength(10);
            entity.Property(e => e.RankName).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.RankCode).IsUnique();
        });

        // Configure Hierarchy entity
        modelBuilder.Entity<Hierarchy>(entity =>
        {
            entity.ToTable("hierarchies");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.HierarchyCode).IsRequired().HasMaxLength(10);
            entity.Property(e => e.HierarchyName).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.HierarchyCode).IsUnique();

            entity.HasOne(e => e.Rank)
                .WithMany(r => r.Hierarchies)
                .HasForeignKey(e => e.RankId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configure Agent entity
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.ToTable("agents");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.AgentCode).IsRequired().HasMaxLength(20);
            entity.Property(e => e.AgentName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.AgentType).IsRequired().HasMaxLength(20).HasDefaultValue("Agent");
            entity.Property(e => e.LeaderCode).HasMaxLength(20);
            entity.HasIndex(e => e.AgentCode).IsUnique();
            entity.HasIndex(e => e.LeaderCode);
            entity.HasIndex(e => e.HierarchyId);
            entity.HasIndex(e => e.ParentAgentId);
            entity.HasIndex(e => e.RankId);
            entity.HasIndex(e => e.AgentType);

            entity.HasOne(e => e.Hierarchy)
                .WithMany(h => h.Agents)
                .HasForeignKey(e => e.HierarchyId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Rank)
                .WithMany(r => r.Agents)
                .HasForeignKey(e => e.RankId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.ParentAgent)
                .WithMany(a => a.ChildAgents)
                .HasForeignKey(e => e.ParentAgentId)
                .OnDelete(DeleteBehavior.Restrict);
        });

    // Configure License entity
        modelBuilder.Entity<License>(entity =>
        {
            entity.ToTable("licenses");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.LicenseNumber).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.LicenseNumber).IsUnique();
            entity.HasIndex(e => e.AgentId);

            entity.HasOne(e => e.Agent)
        .WithMany(a => a.Licenses)
                .HasForeignKey(e => e.AgentId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure Client entity
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("t_client");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Uuid).HasColumnName("UUID").IsRequired();
            entity.Property(e => e.ClientCode).HasColumnName("CLIENT_CODE").IsRequired().HasMaxLength(50);
            entity.Property(e => e.ClientTypeCode).HasColumnName("CLIENT_TYPE_CODE").HasMaxLength(50);
            entity.Property(e => e.IdentityType).HasColumnName("IDENTITY_TYPE").HasMaxLength(50);
            entity.Property(e => e.IdentityNo).HasColumnName("IDENTITY_NO");
            entity.Property(e => e.IdentityPermanent).HasColumnName("IDENTITY_PERMANENT");
            entity.Property(e => e.IdentityExpiryDate).HasColumnName("IDENTITY_EXPIRY_DATE");
            entity.Property(e => e.TitleCode).HasColumnName("TITLE_CODE").HasMaxLength(50);
            entity.Property(e => e.OrganizationName).HasColumnName("ORGANIZATION_NAME").HasMaxLength(200);
            entity.Property(e => e.FirstName).HasColumnName("FIRST_NAME").HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasColumnName("MIDDLE_NAME").HasMaxLength(50);
            entity.Property(e => e.LastName).HasColumnName("LAST_NAME").HasMaxLength(100);
            entity.Property(e => e.SuffixName).HasColumnName("SUFFIX_NAME").HasMaxLength(50);
            entity.Property(e => e.OrganizationNameEn).HasColumnName("ORGANIZATION_NAME_EN").HasMaxLength(200);
            entity.Property(e => e.FirstNameEn).HasColumnName("FIRST_NAME_EN").HasMaxLength(100);
            entity.Property(e => e.MiddleNameEn).HasColumnName("MIDDLE_NAME_EN").HasMaxLength(50);
            entity.Property(e => e.LastNameEn).HasColumnName("LAST_NAME_EN").HasMaxLength(100);
            entity.Property(e => e.SuffixNameEn).HasColumnName("SUFFIX_NAME_EN").HasMaxLength(50);
            entity.Property(e => e.NationalityCode).HasColumnName("NATIONALITY_CODE").HasMaxLength(50);
            entity.Property(e => e.PlaceOfBirthCountryCode).HasColumnName("PLACE_OF_BIRTH_COUNTRY_CODE").HasMaxLength(50);
            entity.Property(e => e.PlaceOfBirthCity).HasColumnName("PLACE_OF_BIRTH_CITY").HasMaxLength(100);
            entity.Property(e => e.OrganizationRegistrationDate).HasColumnName("ORGANIZATION_REGISTRATION_DATE");
            entity.Property(e => e.DateOfBirth).HasColumnName("DATE_OF_BIRTH");
            entity.Property(e => e.GenderCode).HasColumnName("GENDER_CODE").HasMaxLength(50);
            entity.Property(e => e.ReligionCode).HasColumnName("RELIGION_CODE");
            entity.Property(e => e.MaritalStatusCode).HasColumnName("MARITAL_STATUS_CODE").HasMaxLength(50);
            entity.Property(e => e.EducationLevelCode).HasColumnName("EDUCATION_LEVEL_CODE");
            entity.Property(e => e.PrimaryOccupationCode).HasColumnName("PRIMARY_OCCUPATION_CODE");
            entity.Property(e => e.PrimaryOccupationPositionCode).HasColumnName("PRIMARY_OCCUPATION_POSITION_CODE");
            entity.Property(e => e.PrimaryOccupationBusinessType).HasColumnName("PRIMARY_OCCUPATION_BUSINESS_TYPE").HasMaxLength(50);
            entity.Property(e => e.PrimaryOccupationOrganizationName).HasColumnName("PRIMARY_OCCUPATION_ORGANIZATION_NAME").HasMaxLength(100);
            entity.Property(e => e.PrimaryIncomeLevelCode).HasColumnName("PRIMARY_INCOME_LEVEL_CODE");
            entity.Property(e => e.PrimaryIncomePerYear).HasColumnName("PRIMARY_INCOME_PER_YEAR");
            entity.Property(e => e.SecondaryOccupationCode).HasColumnName("SECONDARY_OCCUPATION_CODE");
            entity.Property(e => e.SecondaryOccupationPositionCode).HasColumnName("SECONDARY_OCCUPATION_POSITION_CODE");
            entity.Property(e => e.SecondaryOccupationBusinessType).HasColumnName("SECONDARY_OCCUPATION_BUSINESS_TYPE").HasMaxLength(50);
            entity.Property(e => e.SecondaryOccupationOrganizationName).HasColumnName("SECONDARY_OCCUPATION_ORGANIZATION_NAME").HasMaxLength(100);
            entity.Property(e => e.SecondaryIncomeLevelCode).HasColumnName("SECONDARY_INCOME_LEVEL_CODE");
            entity.Property(e => e.SecondaryIncomePerYear).HasColumnName("SECONDARY_INCOME_PER_YEAR");
            entity.Property(e => e.PremiumCapacity).HasColumnName("PREMIUM_CAPACITY").HasPrecision(15, 2);
            entity.Property(e => e.LanguagePreferenceCode).HasColumnName("LANGUAGE_PREFERENCE_CODE").HasMaxLength(50);
            entity.Property(e => e.ReceivesEmailNews).HasColumnName("RECEIVES_EMAIL_NEWS").HasMaxLength(100);
            entity.Property(e => e.OrganizationBusinessType).HasColumnName("ORGANIZATION_BUSINESS_TYPE").HasMaxLength(50);
            entity.Property(e => e.TaxId).HasColumnName("TAX_ID");
            entity.Property(e => e.TerminatedFlag).HasColumnName("TERMINATED_FLAG");
            entity.Property(e => e.TerminatedDate).HasColumnName("TERMINATED_DATE");
            entity.Property(e => e.TerminatedReason).HasColumnName("TERMINATED_REASON").HasMaxLength(100);
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE").IsRequired();
            entity.Property(e => e.Remark).HasColumnName("REMARK").HasMaxLength(200);
            entity.Property(e => e.CreatedDate).HasColumnName("CREATED_DATE").IsRequired();
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY").HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnName("UPDATED_DATE").IsRequired();
            entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY").HasMaxLength(50);
            entity.Property(e => e.RefId).HasColumnName("REF_ID").HasMaxLength(20);
            
            entity.HasIndex(e => e.ClientCode).IsUnique();
            entity.HasIndex(e => e.Uuid).IsUnique();
            entity.HasIndex(e => e.RefId);

            // Foreign key to Agent
            entity.HasOne(e => e.ReferenceAgent)
                .WithMany()
                .HasForeignKey(e => e.RefId)
                .HasPrincipalKey(a => a.AgentCode)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configure ClientAddress entity
        modelBuilder.Entity<ClientAddress>(entity =>
        {
            entity.ToTable("t_client_address");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Uuid).HasColumnName("UUID");
            entity.Property(e => e.ClientCode).HasColumnName("CLIENT_CODE").IsRequired().HasMaxLength(50);
            entity.Property(e => e.AddressTypeCode).HasColumnName("ADDRESS_TYPE_CODE").HasMaxLength(50);
            entity.Property(e => e.AddressWorkplaceName).HasColumnName("ADDRESS_WORKPLACE_NAME").HasMaxLength(100);
            entity.Property(e => e.AddressNo).HasColumnName("ADDRESS_NO").HasMaxLength(50);
            entity.Property(e => e.AddressMoo).HasColumnName("ADDRESS_MOO").HasMaxLength(10);
            entity.Property(e => e.AddressDetail).HasColumnName("ADDRESS_DETAIL").HasMaxLength(200);
            entity.Property(e => e.AddressVillageBuilding).HasColumnName("ADDRESS_VILLAGE_BUILDING").HasMaxLength(100);
            entity.Property(e => e.AddressAlley).HasColumnName("ADDRESS_ALLEY").HasMaxLength(100);
            entity.Property(e => e.AddressRoad).HasColumnName("ADDRESS_ROAD").HasMaxLength(100);
            entity.Property(e => e.SubdistrictCode).HasColumnName("SUBDISTRICT_CODE").IsRequired().HasMaxLength(50);
            entity.Property(e => e.DistrictCode).HasColumnName("DISTRICT_CODE").IsRequired().HasMaxLength(50);
            entity.Property(e => e.ProvinceCode).HasColumnName("PROVINCE_CODE").IsRequired().HasMaxLength(50);
            entity.Property(e => e.PostalCode).HasColumnName("POSTAL_CODE").IsRequired().HasMaxLength(10);
            entity.Property(e => e.CountryCode).HasColumnName("COUNTRY_CODE").HasMaxLength(50);
            entity.Property(e => e.IsPrimary).HasColumnName("IS_PRIMARY");
            entity.Property(e => e.Remark).HasColumnName("REMARK").HasMaxLength(200);
            entity.Property(e => e.CreatedDate).HasColumnName("CREATED_DATE");
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY").HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnName("UPDATED_DATE");
            entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY").HasMaxLength(50);
            
            entity.HasIndex(e => e.Uuid).IsUnique();
            entity.HasIndex(e => e.ClientCode);

            entity.HasOne(e => e.Client)
                .WithMany(c => c.Addresses)
                .HasForeignKey(e => e.ClientCode)
                .HasPrincipalKey(c => c.ClientCode)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure ClientContact entity
        modelBuilder.Entity<ClientContact>(entity =>
        {
            entity.ToTable("t_client_contact");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Uuid).HasColumnName("UUID").IsRequired();
            entity.Property(e => e.ClientCode).HasColumnName("CLIENT_CODE").IsRequired().HasMaxLength(50);
            entity.Property(e => e.ContactTypeCode).HasColumnName("CONTACT_TYPE_CODE").HasMaxLength(50);
            entity.Property(e => e.ContactValue).HasColumnName("CONTACT_VALUE").IsRequired().HasMaxLength(200);
            entity.Property(e => e.IsPrimary).HasColumnName("IS_PRIMARY").IsRequired();
            entity.Property(e => e.Remark).HasColumnName("REMARK").HasMaxLength(200);
            entity.Property(e => e.CreatedDate).HasColumnName("CREATED_DATE").IsRequired();
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY").IsRequired().HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnName("UPDATED_DATE").IsRequired();
            entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY").IsRequired().HasMaxLength(50);
            
            entity.HasIndex(e => e.Uuid).IsUnique();
            entity.HasIndex(e => e.ClientCode);

            entity.HasOne(e => e.Client)
                .WithMany(c => c.Contacts)
                .HasForeignKey(e => e.ClientCode)
                .HasPrincipalKey(c => c.ClientCode)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure ClientRole entity
        modelBuilder.Entity<ClientRole>(entity =>
        {
            entity.ToTable("t_client_role");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Uuid).HasColumnName("UUID").IsRequired();
            entity.Property(e => e.ClientCode).HasColumnName("CLIENT_CODE").IsRequired().HasMaxLength(50);
            entity.Property(e => e.RoleCode).HasColumnName("ROLE_CODE").HasMaxLength(50);
            entity.Property(e => e.ReferenceNo).HasColumnName("REFERENCE_NO").HasMaxLength(100);
            entity.Property(e => e.PolicyNo).HasColumnName("POLICY_NO").HasMaxLength(50);
            entity.Property(e => e.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
            entity.Property(e => e.ExpiryDate).HasColumnName("EXPIRY_DATE");
            entity.Property(e => e.RoleSeqNo).HasColumnName("ROLE_SEQ_NO");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE").IsRequired();
            entity.Property(e => e.Remark).HasColumnName("REMARK").HasMaxLength(200);
            entity.Property(e => e.CreatedDate).HasColumnName("CREATED_DATE").IsRequired();
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY").IsRequired().HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnName("UPDATED_DATE").IsRequired();
            entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY").IsRequired().HasMaxLength(50);
            
            entity.HasIndex(e => e.Uuid).IsUnique();
            entity.HasIndex(e => e.ClientCode);

            entity.HasOne(e => e.Client)
                .WithMany(c => c.Roles)
                .HasForeignKey(e => e.ClientCode)
                .HasPrincipalKey(c => c.ClientCode)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure Image entity
        modelBuilder.Entity<Image>(entity =>
        {
            entity.ToTable("t_image");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Uuid).HasColumnName("UUID").IsRequired();
            entity.Property(e => e.ImageCode).HasColumnName("IMAGE_CODE").IsRequired().HasMaxLength(50);
            entity.Property(e => e.RefId).HasColumnName("REF_ID").HasMaxLength(50);
            entity.Property(e => e.ImageTypeCode).HasColumnName("IMAGE_TYPE_CODE").HasMaxLength(50);
            entity.Property(e => e.ImageCategory).HasColumnName("IMAGE_CATEGORY").HasMaxLength(50);
            entity.Property(e => e.FileName).HasColumnName("FILE_NAME").HasMaxLength(255);
            entity.Property(e => e.FilePath).HasColumnName("FILE_PATH").HasMaxLength(500);
            entity.Property(e => e.FileUrl).HasColumnName("FILE_URL").HasMaxLength(500);
            entity.Property(e => e.ContentType).HasColumnName("CONTENT_TYPE").HasMaxLength(100);
            entity.Property(e => e.FileSize).HasColumnName("FILE_SIZE");
            entity.Property(e => e.Width).HasColumnName("WIDTH");
            entity.Property(e => e.Height).HasColumnName("HEIGHT");
            entity.Property(e => e.ImageData).HasColumnName("IMAGE_DATA");
            entity.Property(e => e.ThumbnailUrl).HasColumnName("THUMBNAIL_URL").HasMaxLength(500);
            entity.Property(e => e.ThumbnailData).HasColumnName("THUMBNAIL_DATA");
            entity.Property(e => e.IsPrimary).HasColumnName("IS_PRIMARY").IsRequired();
            entity.Property(e => e.DisplayOrder).HasColumnName("DISPLAY_ORDER");
            entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE").IsRequired();
            entity.Property(e => e.Remark).HasColumnName("REMARK").HasMaxLength(200);
            entity.Property(e => e.CreatedDate).HasColumnName("CREATED_DATE").IsRequired();
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY").HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnName("UPDATED_DATE").IsRequired();
            entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY").HasMaxLength(50);
            
            entity.HasIndex(e => e.ImageCode).IsUnique();
            entity.HasIndex(e => e.Uuid).IsUnique();
            entity.HasIndex(e => e.RefId);

            // Foreign key to Client
            entity.HasOne(e => e.ReferenceClient)
                .WithMany(c => c.Images)
                .HasForeignKey(e => e.RefId)
                .HasPrincipalKey(c => c.ClientCode)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Seed data
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Ranks (AE = Level 3 สูงสุด, AG = Level 1 ต่ำสุด)
        modelBuilder.Entity<Rank>().HasData(
            new Rank { Id = 1, RankCode = "AG", RankName = "Agent General", Level = 1 },
            new Rank { Id = 2, RankCode = "AL", RankName = "Agent Leader", Level = 2 },
            new Rank { Id = 3, RankCode = "AE", RankName = "Agent Executive", Level = 3 }
        );

        // Seed Hierarchies
        // โครงสร้าง: A9 (L9) > A8 (L8) > A7 (L7) > A6 (L6) > A5 (L5) > A4 (L4) > A1 (L1)
        modelBuilder.Entity<Hierarchy>().HasData(
            new Hierarchy { Id = 1, HierarchyCode = "A1", HierarchyName = "Hierarchy A1", RankId = 1, Level = 1 },  // AG - ต่ำสุด
            new Hierarchy { Id = 2, HierarchyCode = "A2", HierarchyName = "Hierarchy A2", RankId = 1, Level = 2 },  // AG (สำรอง)
            new Hierarchy { Id = 3, HierarchyCode = "A3", HierarchyName = "Hierarchy A3", RankId = 1, Level = 3 },  // AG (สำรอง)
            new Hierarchy { Id = 4, HierarchyCode = "A4", HierarchyName = "Hierarchy A4", RankId = 2, Level = 4 },  // AL
            new Hierarchy { Id = 5, HierarchyCode = "A5", HierarchyName = "Hierarchy A5", RankId = 2, Level = 5 },  // AL
            new Hierarchy { Id = 6, HierarchyCode = "A6", HierarchyName = "Hierarchy A6", RankId = 2, Level = 6 },  // AL
            new Hierarchy { Id = 7, HierarchyCode = "A7", HierarchyName = "Hierarchy A7", RankId = 3, Level = 7 },  // AE
            new Hierarchy { Id = 8, HierarchyCode = "A8", HierarchyName = "Hierarchy A8", RankId = 3, Level = 8 },  // AE
            new Hierarchy { Id = 9, HierarchyCode = "A9", HierarchyName = "Hierarchy A9", RankId = 3, Level = 9 }   // AE - สูงสุด
        );

        // Seed sample Agents - แสดงตัวอย่างโครงสร้าง A9 > A8 > A7 > A6 > A5 > A4 > A1
        var now = DateTime.UtcNow;
        modelBuilder.Entity<Agent>().HasData(
            // Top-level AE agent (A9 - Level 9)
            new Agent { Id = 1, AgentCode = "AE0001", AgentName = "Executive Agent A9", HierarchyId = 9, RankId = 3, ParentAgentId = null, IsActive = true, CreatedDate = now, UpdatedDate = now },
            
            // AE agent (A8 - Level 8) under A9
            new Agent { Id = 2, AgentCode = "AE0002", AgentName = "Executive Agent A8", HierarchyId = 8, RankId = 3, ParentAgentId = 1, IsActive = true, CreatedDate = now, UpdatedDate = now },
            
            // AE agent (A7 - Level 7) under A8
            new Agent { Id = 3, AgentCode = "AE0003", AgentName = "Executive Agent A7", HierarchyId = 7, RankId = 3, ParentAgentId = 2, IsActive = true, CreatedDate = now, UpdatedDate = now },
            
            // AL agent (A6 - Level 6) under A7
            new Agent { Id = 4, AgentCode = "AL0001", AgentName = "Leader Agent A6", HierarchyId = 6, RankId = 2, ParentAgentId = 3, IsActive = true, CreatedDate = now, UpdatedDate = now },
            
            // AL agent (A5 - Level 5) under A6
            new Agent { Id = 5, AgentCode = "AL0002", AgentName = "Leader Agent A5", HierarchyId = 5, RankId = 2, ParentAgentId = 4, IsActive = true, CreatedDate = now, UpdatedDate = now },
            
            // AL agent (A4 - Level 4) under A5
            new Agent { Id = 6, AgentCode = "AL0003", AgentName = "Leader Agent A4", HierarchyId = 4, RankId = 2, ParentAgentId = 5, IsActive = true, CreatedDate = now, UpdatedDate = now },
            
            // AG agents (A1 - Level 1) under A4
            new Agent { Id = 7, AgentCode = "AG0001", AgentName = "General Agent A1-1", HierarchyId = 1, RankId = 1, ParentAgentId = 6, IsActive = true, CreatedDate = now, UpdatedDate = now },
            new Agent { Id = 8, AgentCode = "AG0002", AgentName = "General Agent A1-2", HierarchyId = 1, RankId = 1, ParentAgentId = 6, IsActive = true, CreatedDate = now, UpdatedDate = now }
        );

        // Seed sample Clients
        modelBuilder.Entity<Client>().HasData(
            // Client ของ AG0001
            new Client 
            { 
                Id = 1, 
                ClientCode = "CLI0001", 
                ClientTypeCode = "INDIVIDUAL",
                IdentityType = "NATIONAL_ID",
                TitleCode = "MR",
                FirstName = "สมชาย",
                LastName = "ใจดี",
                FirstNameEn = "Somchai",
                LastNameEn = "Jaidee",
                DateOfBirth = new DateTime(1985, 5, 15, 0, 0, 0, DateTimeKind.Utc),
                GenderCode = "M",
                NationalityCode = "THA",
                MaritalStatusCode = "MARRIED",
                PrimaryOccupationBusinessType = "TRADING",
                PrimaryOccupationOrganizationName = "ABC Trading Co., Ltd.",
                PremiumCapacity = 50000.00m,
                LanguagePreferenceCode = "TH",
                RefId = "AG0001",
                IsActive = true,
                CreatedDate = now,
                UpdatedDate = now
            },
            new Client 
            { 
                Id = 2, 
                ClientCode = "CLI0002", 
                ClientTypeCode = "INDIVIDUAL",
                IdentityType = "NATIONAL_ID",
                TitleCode = "MRS",
                FirstName = "สมหญิง",
                LastName = "รักดี",
                FirstNameEn = "Somying",
                LastNameEn = "Rakdee",
                DateOfBirth = new DateTime(1990, 8, 20, 0, 0, 0, DateTimeKind.Utc),
                GenderCode = "F",
                NationalityCode = "THA",
                MaritalStatusCode = "SINGLE",
                PrimaryOccupationBusinessType = "GOVERNMENT",
                PrimaryOccupationOrganizationName = "Ministry of Finance",
                PremiumCapacity = 75000.00m,
                LanguagePreferenceCode = "TH",
                RefId = "AG0001",
                IsActive = true,
                CreatedDate = now,
                UpdatedDate = now
            },
            // Client ของ AE0001
            new Client 
            { 
                Id = 3, 
                ClientCode = "CLI0003", 
                ClientTypeCode = "ORGANIZATION",
                IdentityType = "TAX_ID",
                OrganizationName = "บริษัท ไทยประกันภัย จำกัด",
                OrganizationNameEn = "Thai Insurance Company Limited",
                OrganizationRegistrationDate = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                NationalityCode = "THA",
                OrganizationBusinessType = "INSURANCE",
                PremiumCapacity = 5000000.00m,
                LanguagePreferenceCode = "TH",
                RefId = "AE0001",
                IsActive = true,
                CreatedDate = now,
                UpdatedDate = now
            },
            new Client 
            { 
                Id = 4, 
                ClientCode = "CLI0004", 
                ClientTypeCode = "INDIVIDUAL",
                IdentityType = "PASSPORT",
                TitleCode = "MR",
                FirstName = "John",
                LastName = "Smith",
                FirstNameEn = "John",
                LastNameEn = "Smith",
                DateOfBirth = new DateTime(1975, 3, 10, 0, 0, 0, DateTimeKind.Utc),
                GenderCode = "M",
                NationalityCode = "USA",
                PlaceOfBirthCountryCode = "USA",
                PlaceOfBirthCity = "New York",
                MaritalStatusCode = "MARRIED",
                PrimaryOccupationBusinessType = "TECHNOLOGY",
                PrimaryOccupationOrganizationName = "Tech Global Inc.",
                PremiumCapacity = 200000.00m,
                LanguagePreferenceCode = "EN",
                RefId = "AE0001",
                IsActive = true,
                CreatedDate = now,
                UpdatedDate = now
            }
        );

        // Seed sample Client Addresses
        modelBuilder.Entity<ClientAddress>().HasData(
            // Address for CLI0001
            new ClientAddress
            {
                Id = 1,
                ClientCode = "CLI0001",
                AddressTypeCode = "HOME",
                AddressNo = "123/45",
                AddressMoo = "5",
                AddressDetail = "ซอยลาดพร้าว 101",
                AddressRoad = "ลาดพร้าว",
                SubdistrictCode = "100101",
                DistrictCode = "1001",
                ProvinceCode = "10",
                PostalCode = "10230",
                CountryCode = "THA",
                IsPrimary = true,
                CreatedDate = now,
                UpdatedDate = now
            },
            // Address for CLI0002
            new ClientAddress
            {
                Id = 2,
                ClientCode = "CLI0002",
                AddressTypeCode = "HOME",
                AddressNo = "567/89",
                AddressVillageBuilding = "หมู่บ้านสุขใจ",
                AddressRoad = "พระราม 9",
                SubdistrictCode = "100102",
                DistrictCode = "1001",
                ProvinceCode = "10",
                PostalCode = "10250",
                CountryCode = "THA",
                IsPrimary = true,
                CreatedDate = now,
                UpdatedDate = now
            },
            // Address for CLI0003
            new ClientAddress
            {
                Id = 3,
                ClientCode = "CLI0003",
                AddressTypeCode = "OFFICE",
                AddressNo = "999",
                AddressVillageBuilding = "อาคารไทยประกัน ทาวเวอร์",
                AddressRoad = "สาทร",
                SubdistrictCode = "100201",
                DistrictCode = "1002",
                ProvinceCode = "10",
                PostalCode = "10120",
                CountryCode = "THA",
                IsPrimary = true,
                CreatedDate = now,
                UpdatedDate = now
            },
            // Address for CLI0004
            new ClientAddress
            {
                Id = 4,
                ClientCode = "CLI0004",
                AddressTypeCode = "HOME",
                AddressNo = "88/12",
                AddressVillageBuilding = "Luxury Condo",
                AddressRoad = "Sukhumvit",
                SubdistrictCode = "100301",
                DistrictCode = "1003",
                ProvinceCode = "10",
                PostalCode = "10110",
                CountryCode = "THA",
                IsPrimary = true,
                CreatedDate = now,
                UpdatedDate = now
            }
        );

        // Seed sample Client Contacts
        modelBuilder.Entity<ClientContact>().HasData(
            // Contacts for CLI0001
            new ClientContact
            {
                Id = 1,
                ClientCode = "CLI0001",
                ContactTypeCode = "MOBILE",
                ContactValue = "081-234-5678",
                IsPrimary = true,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            new ClientContact
            {
                Id = 2,
                ClientCode = "CLI0001",
                ContactTypeCode = "EMAIL",
                ContactValue = "somchai.j@email.com",
                IsPrimary = false,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            // Contacts for CLI0002
            new ClientContact
            {
                Id = 3,
                ClientCode = "CLI0002",
                ContactTypeCode = "MOBILE",
                ContactValue = "082-345-6789",
                IsPrimary = true,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            new ClientContact
            {
                Id = 4,
                ClientCode = "CLI0002",
                ContactTypeCode = "EMAIL",
                ContactValue = "somying.r@email.com",
                IsPrimary = false,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            // Contacts for CLI0003
            new ClientContact
            {
                Id = 5,
                ClientCode = "CLI0003",
                ContactTypeCode = "OFFICE_PHONE",
                ContactValue = "02-123-4567",
                IsPrimary = true,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            new ClientContact
            {
                Id = 6,
                ClientCode = "CLI0003",
                ContactTypeCode = "EMAIL",
                ContactValue = "info@thaiinsurance.com",
                IsPrimary = false,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            // Contacts for CLI0004
            new ClientContact
            {
                Id = 7,
                ClientCode = "CLI0004",
                ContactTypeCode = "MOBILE",
                ContactValue = "+1-555-1234",
                IsPrimary = true,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            new ClientContact
            {
                Id = 8,
                ClientCode = "CLI0004",
                ContactTypeCode = "EMAIL",
                ContactValue = "john.smith@techglobal.com",
                IsPrimary = false,
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            }
        );

        // Seed ClientRole data
        modelBuilder.Entity<ClientRole>().HasData(
            // Roles for CLI0001 (สมชาย ใจดี)
            new ClientRole
            {
                Id = 1,
                ClientCode = "CLI0001",
                RoleCode = "POLICY_OWNER",
                ReferenceNo = "POL-2025-001",
                PolicyNo = "POL001-2025",
                EffectiveDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ExpiryDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                RoleSeqNo = 1,
                IsActive = true,
                Remark = "Life Insurance Policy Owner",
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            new ClientRole
            {
                Id = 2,
                ClientCode = "CLI0001",
                RoleCode = "INSURED",
                ReferenceNo = "POL-2025-001",
                PolicyNo = "POL001-2025",
                EffectiveDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ExpiryDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                RoleSeqNo = 1,
                IsActive = true,
                Remark = "Insured Person",
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            // Roles for CLI0002 (สมหญิง รักดี)
            new ClientRole
            {
                Id = 3,
                ClientCode = "CLI0002",
                RoleCode = "BENEFICIARY",
                ReferenceNo = "POL-2025-001",
                PolicyNo = "POL001-2025",
                EffectiveDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ExpiryDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                RoleSeqNo = 1,
                IsActive = true,
                Remark = "Primary Beneficiary - Spouse",
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            // Roles for CLI0003 (บริษัท ไทยประกันภัย)
            new ClientRole
            {
                Id = 4,
                ClientCode = "CLI0003",
                RoleCode = "CORPORATE_CLIENT",
                ReferenceNo = "CORP-2025-001",
                PolicyNo = "CORP001-2025",
                EffectiveDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ExpiryDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                RoleSeqNo = 1,
                IsActive = true,
                Remark = "Corporate Insurance Client",
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            // Roles for CLI0004 (John Smith)
            new ClientRole
            {
                Id = 5,
                ClientCode = "CLI0004",
                RoleCode = "POLICY_OWNER",
                ReferenceNo = "POL-2025-002",
                PolicyNo = "POL002-2025",
                EffectiveDate = new DateTime(2025, 2, 1, 0, 0, 0, DateTimeKind.Utc),
                ExpiryDate = new DateTime(2026, 2, 1, 0, 0, 0, DateTimeKind.Utc),
                RoleSeqNo = 1,
                IsActive = true,
                Remark = "Expatriate Policy Owner",
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            }
        );

        // Seed Image data
        // Note: For demonstration, using small base64 encoded images
        // In production, you would use actual image files
        
        // Simple 1x1 red pixel PNG (base64)
        var sampleImageData = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8/5+hHgAHggJ/PchI7wAAAABJRU5ErkJggg==");
        
        // Simple 1x1 blue pixel PNG for thumbnail
        var sampleThumbnailData = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg==");

        modelBuilder.Entity<Image>().HasData(
            // Images for CLI0001 (สมชาย ใจดี)
            new Image
            {
                Id = 1,
                Uuid = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ImageCode = "IMG0001",
                RefId = "CLI0001",
                ImageTypeCode = "PROFILE",
                ImageCategory = "PERSONAL",
                FileName = "somchai_profile.jpg",
                ContentType = "image/jpeg",
                FileSize = sampleImageData.Length,
                Width = 800,
                Height = 600,
                ImageData = sampleImageData,
                ThumbnailData = sampleThumbnailData,
                IsPrimary = true,
                DisplayOrder = 1,
                IsActive = true,
                Remark = "Profile picture",
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            new Image
            {
                Id = 2,
                Uuid = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                ImageCode = "IMG0002",
                RefId = "CLI0001",
                ImageTypeCode = "ID_CARD",
                ImageCategory = "DOCUMENT",
                FileName = "somchai_idcard.jpg",
                ContentType = "image/jpeg",
                FileSize = sampleImageData.Length,
                Width = 1024,
                Height = 768,
                ImageData = sampleImageData,
                ThumbnailData = sampleThumbnailData,
                IsPrimary = false,
                DisplayOrder = 2,
                IsActive = true,
                Remark = "National ID Card",
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            // Images for CLI0002 (สมหญิง รักดี)
            new Image
            {
                Id = 3,
                Uuid = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                ImageCode = "IMG0003",
                RefId = "CLI0002",
                ImageTypeCode = "PROFILE",
                ImageCategory = "PERSONAL",
                FileName = "somying_profile.jpg",
                ContentType = "image/jpeg",
                FileSize = sampleImageData.Length,
                Width = 800,
                Height = 600,
                ImageData = sampleImageData,
                ThumbnailData = sampleThumbnailData,
                IsPrimary = true,
                DisplayOrder = 1,
                IsActive = true,
                Remark = "Profile picture",
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            // Images for CLI0003 (บริษัท ไทยประกันภัย)
            new Image
            {
                Id = 4,
                Uuid = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                ImageCode = "IMG0004",
                RefId = "CLI0003",
                ImageTypeCode = "COMPANY_LOGO",
                ImageCategory = "CORPORATE",
                FileName = "thai_insurance_logo.png",
                ContentType = "image/png",
                FileSize = sampleImageData.Length,
                Width = 400,
                Height = 400,
                ImageData = sampleImageData,
                ThumbnailData = sampleThumbnailData,
                IsPrimary = true,
                DisplayOrder = 1,
                IsActive = true,
                Remark = "Company Logo",
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            new Image
            {
                Id = 5,
                Uuid = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                ImageCode = "IMG0005",
                RefId = "CLI0003",
                ImageTypeCode = "REGISTRATION",
                ImageCategory = "DOCUMENT",
                FileName = "company_registration.pdf.jpg",
                ContentType = "image/jpeg",
                FileSize = sampleImageData.Length,
                Width = 1200,
                Height = 1600,
                ImageData = sampleImageData,
                ThumbnailData = sampleThumbnailData,
                IsPrimary = false,
                DisplayOrder = 2,
                IsActive = true,
                Remark = "Company Registration Document",
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            // Images for CLI0004 (John Smith)
            new Image
            {
                Id = 6,
                Uuid = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                ImageCode = "IMG0006",
                RefId = "CLI0004",
                ImageTypeCode = "PASSPORT",
                ImageCategory = "DOCUMENT",
                FileName = "john_passport.jpg",
                ContentType = "image/jpeg",
                FileSize = sampleImageData.Length,
                Width = 1024,
                Height = 768,
                ImageData = sampleImageData,
                ThumbnailData = sampleThumbnailData,
                IsPrimary = true,
                DisplayOrder = 1,
                IsActive = true,
                Remark = "Passport Photo Page",
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            },
            new Image
            {
                Id = 7,
                Uuid = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                ImageCode = "IMG0007",
                RefId = "CLI0004",
                ImageTypeCode = "SIGNATURE",
                ImageCategory = "VERIFICATION",
                FileName = "john_signature.png",
                ContentType = "image/png",
                FileSize = sampleImageData.Length,
                Width = 400,
                Height = 200,
                ImageData = sampleImageData,
                ThumbnailData = sampleThumbnailData,
                IsPrimary = false,
                DisplayOrder = 2,
                IsActive = true,
                Remark = "Digital Signature",
                CreatedBy = "System",
                UpdatedBy = "System",
                CreatedDate = now,
                UpdatedDate = now
            }
        );

        // Optionally seed sample License
        // modelBuilder.Entity<License>().HasData(
        //     new License { Id = 1, AgentId = 7, LicenseNumber = "LIC-AG0001", IssueDate = now.Date, ExpiryDate = now.Date.AddYears(1), IsActive = true, CreatedDate = now, UpdatedDate = now }
        // );
    }
}
