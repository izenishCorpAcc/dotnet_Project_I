using BulkyWeb_1._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BulkyWeb_1._0.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
          
        }
        public DbSet<Prasna> Prasna { get; set; }
        public DbSet<Category> Categories { get; set; }
      
        public DbSet<SuperAdmin> superAdmins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.Entity<Category>().HasData(
            new Category { Id=1,Name="Action",DisplayOrder=1 },
            new Category { Id = 2, Name = "Comedy", DisplayOrder = 2 },
            new Category { Id = 3, Name = "Thriller", DisplayOrder = 3 },
            new Category { Id = 4, Name = "Romance", DisplayOrder = 4 }

            );

            
        }

    }
}
