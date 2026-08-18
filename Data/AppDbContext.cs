using Microsoft.EntityFrameworkCore;
using MyFirstApp.Models;

namespace MyFirstApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
//tabls
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


    }
}