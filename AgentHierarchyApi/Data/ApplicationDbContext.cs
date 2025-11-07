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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Rank entity
        modelBuilder.Entity<Rank>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.RankCode).IsRequired().HasMaxLength(10);
            entity.Property(e => e.RankName).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.RankCode).IsUnique();
        });

        // Configure Hierarchy entity
        modelBuilder.Entity<Hierarchy>(entity =>
        {
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
            entity.HasKey(e => e.Id);
            entity.Property(e => e.AgentCode).IsRequired().HasMaxLength(20);
            entity.Property(e => e.AgentName).IsRequired().HasMaxLength(100);
            entity.HasIndex(e => e.AgentCode).IsUnique();
            entity.HasIndex(e => e.HierarchyId);
            entity.HasIndex(e => e.ParentAgentId);
            entity.HasIndex(e => e.RankId);

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

        // Seed data
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Ranks
        modelBuilder.Entity<Rank>().HasData(
            new Rank { Id = 1, RankCode = "AG", RankName = "Agent General", Level = 1 },
            new Rank { Id = 2, RankCode = "AL", RankName = "Agent Leader", Level = 2 },
            new Rank { Id = 3, RankCode = "AE", RankName = "Agent Executive", Level = 3 }
        );

        // Seed Hierarchies
        modelBuilder.Entity<Hierarchy>().HasData(
            new Hierarchy { Id = 1, HierarchyCode = "A1", HierarchyName = "Hierarchy A1", RankId = 1, Level = 1 },
            new Hierarchy { Id = 2, HierarchyCode = "A2", HierarchyName = "Hierarchy A2", RankId = 1, Level = 2 },
            new Hierarchy { Id = 3, HierarchyCode = "A3", HierarchyName = "Hierarchy A3", RankId = 1, Level = 3 },
            new Hierarchy { Id = 4, HierarchyCode = "A4", HierarchyName = "Hierarchy A4", RankId = 2, Level = 4 },
            new Hierarchy { Id = 5, HierarchyCode = "A5", HierarchyName = "Hierarchy A5", RankId = 2, Level = 5 },
            new Hierarchy { Id = 6, HierarchyCode = "A6", HierarchyName = "Hierarchy A6", RankId = 2, Level = 6 },
            new Hierarchy { Id = 7, HierarchyCode = "A7", HierarchyName = "Hierarchy A7", RankId = 3, Level = 7 },
            new Hierarchy { Id = 8, HierarchyCode = "A8", HierarchyName = "Hierarchy A8", RankId = 3, Level = 8 },
            new Hierarchy { Id = 9, HierarchyCode = "A9", HierarchyName = "Hierarchy A9", RankId = 3, Level = 9 }
        );

        // Seed sample Agents
        var now = DateTime.UtcNow;
        modelBuilder.Entity<Agent>().HasData(
            // Top-level AE agent
            new Agent { Id = 1, AgentCode = "AE0001", AgentName = "Executive Agent 1", HierarchyId = 9, RankId = 3, ParentAgentId = null, IsActive = true, CreatedDate = now, UpdatedDate = now },
            
            // AL agents under AE
            new Agent { Id = 2, AgentCode = "AL0001", AgentName = "Leader Agent 1", HierarchyId = 6, RankId = 2, ParentAgentId = 1, IsActive = true, CreatedDate = now, UpdatedDate = now },
            new Agent { Id = 3, AgentCode = "AL0002", AgentName = "Leader Agent 2", HierarchyId = 5, RankId = 2, ParentAgentId = 1, IsActive = true, CreatedDate = now, UpdatedDate = now },
            
            // AG agents under AL
            new Agent { Id = 4, AgentCode = "AG0001", AgentName = "General Agent 1", HierarchyId = 3, RankId = 1, ParentAgentId = 2, IsActive = true, CreatedDate = now, UpdatedDate = now },
            new Agent { Id = 5, AgentCode = "AG0002", AgentName = "General Agent 2", HierarchyId = 2, RankId = 1, ParentAgentId = 2, IsActive = true, CreatedDate = now, UpdatedDate = now },
            new Agent { Id = 6, AgentCode = "AG0003", AgentName = "General Agent 3", HierarchyId = 1, RankId = 1, ParentAgentId = 3, IsActive = true, CreatedDate = now, UpdatedDate = now }
        );
    }
}
