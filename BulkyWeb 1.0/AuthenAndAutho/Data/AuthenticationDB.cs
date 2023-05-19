using Microsoft.EntityFrameworkCore;
using AuthenAndAutho.Models;


namespace AuthenAndAutho.Data
{
    public class AuthenticationDB : DbContext
    {
        public AuthenticationDB(DbContextOptions<AuthenticationDB> options) : base(options)
        {

        }
         public DbSet<user> Users { get; set; }
        public DbSet<role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>()
            .HasMany(u => u.Roles)
             .WithMany(r => r.Users)
            .UsingEntity(j => j.ToTable("UserRoles"));

        }


    }
}
