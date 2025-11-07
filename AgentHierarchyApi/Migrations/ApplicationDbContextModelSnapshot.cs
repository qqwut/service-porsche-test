using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using AgentHierarchyApi.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgentHierarchyApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AgentHierarchyApi.Models.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AgentCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("AgentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HierarchyId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int?>("ParentAgentId")
                        .HasColumnType("integer");

                    b.Property<int>("RankId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AgentCode")
                        .IsUnique();

                    b.HasIndex("HierarchyId");

                    b.HasIndex("ParentAgentId");

                    b.HasIndex("RankId");

                    b.ToTable("Agents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgentCode = "AE0001",
                            AgentName = "Executive Agent 1",
                            CreatedDate = new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc),
                            HierarchyId = 9,
                            IsActive = true,
                            RankId = 3,
                            UpdatedDate = new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            AgentCode = "AL0001",
                            AgentName = "Leader Agent 1",
                            CreatedDate = new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc),
                            HierarchyId = 6,
                            IsActive = true,
                            ParentAgentId = 1,
                            RankId = 2,
                            UpdatedDate = new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 3,
                            AgentCode = "AL0002",
                            AgentName = "Leader Agent 2",
                            CreatedDate = new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc),
                            HierarchyId = 5,
                            IsActive = true,
                            ParentAgentId = 1,
                            RankId = 2,
                            UpdatedDate = new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 4,
                            AgentCode = "AG0001",
                            AgentName = "General Agent 1",
                            CreatedDate = new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc),
                            HierarchyId = 3,
                            IsActive = true,
                            ParentAgentId = 2,
                            RankId = 1,
                            UpdatedDate = new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 5,
                            AgentCode = "AG0002",
                            AgentName = "General Agent 2",
                            CreatedDate = new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc),
                            HierarchyId = 2,
                            IsActive = true,
                            ParentAgentId = 2,
                            RankId = 1,
                            UpdatedDate = new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 6,
                            AgentCode = "AG0003",
                            AgentName = "General Agent 3",
                            CreatedDate = new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc),
                            HierarchyId = 1,
                            IsActive = true,
                            ParentAgentId = 3,
                            RankId = 1,
                            UpdatedDate = new DateTime(2025, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("AgentHierarchyApi.Models.Hierarchy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("HierarchyCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("HierarchyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<int>("RankId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HierarchyCode")
                        .IsUnique();

                    b.HasIndex("RankId");

                    b.ToTable("Hierarchies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HierarchyCode = "A1",
                            HierarchyName = "Hierarchy A1",
                            Level = 1,
                            RankId = 1
                        },
                        new
                        {
                            Id = 2,
                            HierarchyCode = "A2",
                            HierarchyName = "Hierarchy A2",
                            Level = 2,
                            RankId = 1
                        },
                        new
                        {
                            Id = 3,
                            HierarchyCode = "A3",
                            HierarchyName = "Hierarchy A3",
                            Level = 3,
                            RankId = 1
                        },
                        new
                        {
                            Id = 4,
                            HierarchyCode = "A4",
                            HierarchyName = "Hierarchy A4",
                            Level = 4,
                            RankId = 2
                        },
                        new
                        {
                            Id = 5,
                            HierarchyCode = "A5",
                            HierarchyName = "Hierarchy A5",
                            Level = 5,
                            RankId = 2
                        },
                        new
                        {
                            Id = 6,
                            HierarchyCode = "A6",
                            HierarchyName = "Hierarchy A6",
                            Level = 6,
                            RankId = 2
                        },
                        new
                        {
                            Id = 7,
                            HierarchyCode = "A7",
                            HierarchyName = "Hierarchy A7",
                            Level = 7,
                            RankId = 3
                        },
                        new
                        {
                            Id = 8,
                            HierarchyCode = "A8",
                            HierarchyName = "Hierarchy A8",
                            Level = 8,
                            RankId = 3
                        },
                        new
                        {
                            Id = 9,
                            HierarchyCode = "A9",
                            HierarchyName = "Hierarchy A9",
                            Level = 9,
                            RankId = 3
                        });
                });

            modelBuilder.Entity("AgentHierarchyApi.Models.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("RankCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("RankName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("RankCode")
                        .IsUnique();

                    b.ToTable("Ranks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Level = 1,
                            RankCode = "AG",
                            RankName = "Agent General"
                        },
                        new
                        {
                            Id = 2,
                            Level = 2,
                            RankCode = "AL",
                            RankName = "Agent Leader"
                        },
                        new
                        {
                            Id = 3,
                            Level = 3,
                            RankCode = "AE",
                            RankName = "Agent Executive"
                        });
                });

            modelBuilder.Entity("AgentHierarchyApi.Models.Agent", b =>
                {
                    b.HasOne("AgentHierarchyApi.Models.Hierarchy", "Hierarchy")
                        .WithMany("Agents")
                        .HasForeignKey("HierarchyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AgentHierarchyApi.Models.Agent", "ParentAgent")
                        .WithMany("ChildAgents")
                        .HasForeignKey("ParentAgentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AgentHierarchyApi.Models.Rank", "Rank")
                        .WithMany("Agents")
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Hierarchy");

                    b.Navigation("ParentAgent");

                    b.Navigation("Rank");
                });

            modelBuilder.Entity("AgentHierarchyApi.Models.Hierarchy", b =>
                {
                    b.HasOne("AgentHierarchyApi.Models.Rank", "Rank")
                        .WithMany("Hierarchies")
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Rank");
                });

            modelBuilder.Entity("AgentHierarchyApi.Models.Agent", b =>
                {
                    b.Navigation("ChildAgents");
                });

            modelBuilder.Entity("AgentHierarchyApi.Models.Hierarchy", b =>
                {
                    b.Navigation("Agents");
                });

            modelBuilder.Entity("AgentHierarchyApi.Models.Rank", b =>
                {
                    b.Navigation("Agents");

                    b.Navigation("Hierarchies");
                });
#pragma warning restore 612, 618
        }
    }
}
