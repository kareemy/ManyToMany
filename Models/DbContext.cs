using System;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = database.db");
        }

        // Needed for Many-to-Many association entity
        // EmployeeProject entity has 2 attributes as the primary key.
        // This code tells EF Core that EmployeeId and ProjectId combine for the primary key
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeProject>()
                .HasKey(e => new {e.EmployeeId, e.ProjectId});
        }

        // DbSet<> of each entity class, including the association entity
        public DbSet<Employee> Employees {get; set;} = null!;
        public DbSet<Project> Projects {get; set;} = null!;
        public DbSet<EmployeeProject> EmployeeProjects {get; set;} = null!;
    }
}