// using Microsoft.EntityFrameworkCore;
// using MyFirstApp.Models;

// namespace MyFirstApp.Data;

// public class AppDbContext : DbContext
// {
//     public AppDbContext(DbContextOptions<AppDbContext> options)
//         : base(options)
//     {
//     }
// //tabls
//     public DbSet<Project> Projects { get; set; }

//     public DbSet<Category> Categories { get; set; }

//     public DbSet<Technology> Technologies { get; set; }

//     public DbSet<ProjectDetails> ProjectDetails { get; set; }


//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         base.OnModelCreating(modelBuilder);
//    // ==========================================
//         // 1. Category 1 ---- * Project
//         // ==========================================

//         modelBuilder.Entity<Project>()
//             .HasOne(p => p.Category)
//             .WithMany(c => c.Projects)
//             .HasForeignKey(p => p.CategoryId)
//             .OnDelete(DeleteBehavior.Restrict);


//         // ==========================================
//         // 2. Project * ---- * Technology
//         // ==========================================

//         modelBuilder.Entity<Project>()
//             .HasMany(p => p.Technologies)
//             .WithMany(t => t.Projects)
//             .UsingEntity(j => j.ToTable("ProjectTechnology"));


//         // ==========================================
//         // 3. Project 1 ---- 1 ProjectDetails
//         // ==========================================

//         modelBuilder.Entity<Project>()
//             .HasOne(p => p.ProjectDetails)
//             .WithOne(pd => pd.Project)
//             .HasForeignKey<ProjectDetails>(pd => pd.ProjectId)
//             .OnDelete(DeleteBehavior.Cascade);


//     }
// }






























using Microsoft.EntityFrameworkCore;
using MyFirstApp.Models;

namespace MyFirstApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Technology> Technologies { get; set; }

    public DbSet<ProjectDetails> ProjectDetails { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // ==========================================
        // 1. Category 1 ---- * Project
        // ==========================================

        modelBuilder.Entity<Project>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Projects)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);


        // ==========================================
        // 2. Project * ---- * Technology
        // ==========================================

        modelBuilder.Entity<Project>()
            .HasMany(p => p.Technologies)
            .WithMany(t => t.Projects)
            .UsingEntity(j => j.ToTable("ProjectTechnology"));


        // ==========================================
        // 3. Project 1 ---- 1 ProjectDetails
        // ==========================================

        modelBuilder.Entity<Project>()
            .HasOne(p => p.ProjectDetails)
            .WithOne(pd => pd.Project)
            .HasForeignKey<ProjectDetails>(pd => pd.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);


        // ==========================================
        // Seed Categories
        // ==========================================

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "WEB DEVELOPMENT"
            },
            new Category
            {
                Id = 2,
                Name = "DESKTOP DEVELOPMENT"
            },
            new Category
            {
                Id = 3,
                Name = "MOBILE DEVELOPMENT"
            },
            new Category
            {
                Id = 4,
                Name = "ARTIFICIAL INTELLIGENCE"
            }
        );


        // ==========================================
        // Seed Technologies
        // ==========================================

        modelBuilder.Entity<Technology>().HasData(
            new Technology
            {
                Id = 1,
                Name = "C#"
            },
            new Technology
            {
                Id = 2,
                Name = "ASP.NET CORE"
            },
            new Technology
            {
                Id = 3,
                Name = "MYSQL"
            },
            new Technology
            {
                Id = 4,
                Name = "JAVASCRIPT"
            },
            new Technology
            {
                Id = 5,
                Name = "PYTHON"
            },
            new Technology
            {
                Id = 6,
                Name = "FLUTTER"
            }
        );


        // ==========================================
        // Seed Projects
        // ==========================================

        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = 1,
                Name = "MY FIRST APP",
                Description = "ASP.NET CORE MVC PROJECT",
                GitHubUrl = "https://github.com/example/my-first-app",
                IsPublic = true,
                ProjectType = "WEB",
                License = "MIT",
                CategoryId = 1
            },
            new Project
            {
                Id = 2,
                Name = "NOTES APP",
                Description = "NOTE MANAGEMENT APPLICATION",
                GitHubUrl = "https://github.com/example/notes-app",
                IsPublic = true,
                ProjectType = "WEB",
                License = "MIT",
                CategoryId = 1
            },
            new Project
            {
                Id = 3,
                Name = "SMART SYSTEM",
                Description = "AI BASED SMART SYSTEM",
                GitHubUrl = "https://github.com/example/smart-system",
                IsPublic = true,
                ProjectType = "AI",
                License = "MIT",
                CategoryId = 4
            },
            new Project
            {
                Id = 4,
                Name = "MOBILE APP",
                Description = "CROSS PLATFORM MOBILE APPLICATION",
                GitHubUrl = "https://github.com/example/mobile-app",
                IsPublic = false,
                ProjectType = "MOBILE",
                License = "MIT",
                CategoryId = 3
            }
        );


        // ==========================================
        // Seed ProjectDetails
        // ==========================================

        modelBuilder.Entity<ProjectDetails>().HasData(
            new ProjectDetails
            {
                Id = 1,
                ProjectId = 1,
                Client = "CLIENT A",
                StartDate = new DateTime(2026, 1, 1),
                EndDate = new DateTime(2026, 2, 1),
                Budget = 1000
            },
            new ProjectDetails
            {
                Id = 2,
                ProjectId = 2,
                Client = "CLIENT B",
                StartDate = new DateTime(2026, 2, 1),
                EndDate = new DateTime(2026, 3, 1),
                Budget = 1500
            },
            new ProjectDetails
            {
                Id = 3,
                ProjectId = 3,
                Client = "CLIENT C",
                StartDate = new DateTime(2026, 3, 1),
                EndDate = new DateTime(2026, 5, 1),
                Budget = 3000
            },
            new ProjectDetails
            {
                Id = 4,
                ProjectId = 4,
                Client = "CLIENT D",
                StartDate = new DateTime(2026, 4, 1),
                EndDate = new DateTime(2026, 6, 1),
                Budget = 2000
            }
        );


        // ==========================================
        // Seed ProjectTechnology
        // ==========================================

        modelBuilder.Entity<Project>()
            .HasMany(p => p.Technologies)
            .WithMany(t => t.Projects)
            .UsingEntity<Dictionary<string, object>>(
                "ProjectTechnology",
                j => j
                    .HasOne<Technology>()
                    .WithMany()
                    .HasForeignKey("TechnologiesId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Project>()
                    .WithMany()
                    .HasForeignKey("ProjectsId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("ProjectsId", "TechnologiesId");

                    j.HasData(
                        new
                        {
                            ProjectsId = 1,
                            TechnologiesId = 1
                        },
                        new
                        {
                            ProjectsId = 1,
                            TechnologiesId = 2
                        },
                        new
                        {
                            ProjectsId = 1,
                            TechnologiesId = 3
                        },
                        new
                        {
                            ProjectsId = 2,
                            TechnologiesId = 1
                        },
                        new
                        {
                            ProjectsId = 2,
                            TechnologiesId = 2
                        },
                        new
                        {
                            ProjectsId = 2,
                            TechnologiesId = 3
                        },
                        new
                        {
                            ProjectsId = 3,
                            TechnologiesId = 5
                        },
                        new
                        {
                            ProjectsId = 3,
                            TechnologiesId = 3
                        },
                        new
                        {
                            ProjectsId = 4,
                            TechnologiesId = 6
                        },
                        new
                        {
                            ProjectsId = 4,
                            TechnologiesId = 4
                        }
                    );
                });
    }
}