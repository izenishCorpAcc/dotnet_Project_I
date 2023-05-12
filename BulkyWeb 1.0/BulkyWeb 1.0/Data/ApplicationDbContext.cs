using System;
using BulkyWeb_1._0.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace BulkyWeb_1._0.Data
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Prasna> Prasna { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Category>()
          .Property(c => c.Name)
          .HasColumnType("varchar")
          .HasAnnotation("Relational:ColumnType", "varchar(255)");

            modelBuilder.Entity<Prasna>()
                .Property(a => a.Question)
                .HasColumnType("varchar")
                .HasAnnotation("Relational:ColumnType", "varchar(255)");

            modelBuilder.Entity<Prasna>()
                .Property(a => a.Correst_Answer)
                .HasColumnType("varchar")
                .HasAnnotation("Relational:ColumnType", "varchar(255)");

            modelBuilder.Entity<Prasna>()
                .Property(a => a.WrongAnswer_1)
                .HasColumnType("varchar")
                .HasAnnotation("Relational:ColumnType", "varchar(255)");

            modelBuilder.Entity<Prasna>()
                .Property(a => a.WrongAnswer_2)
                .HasColumnType("varchar")
                .HasAnnotation("Relational:ColumnType", "varchar(255)");

            modelBuilder.Entity<Prasna>()
                .Property(a => a.WrongAnswer_3)
                .HasColumnType("varchar")
                .HasAnnotation("Relational:ColumnType", "varchar(255)");

            modelBuilder.Entity<Category>().HasData(

         new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
         new Category { Id = 2, Name = "Comedy", DisplayOrder = 2 },
         new Category { Id = 3, Name = "Thriller", DisplayOrder = 3 },
         new Category { Id = 4, Name = "Romance", DisplayOrder = 4 }

         );

            base.OnModelCreating(modelBuilder);
        }
    }
}

