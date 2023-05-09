using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using QuizApp.Model;

namespace QuizApp.Data

    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }
        public DbSet<RazorCategory> RazorCategories { get; set; }
            //public DbSet<Prasna> Prasna { get; set; }
            //public DbSet<Category> Categories { get; set; }

            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{
            //    modelBuilder.Entity<Category>().HasData(

            //    new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
            //    new Category { Id = 2, Name = "Comedy", DisplayOrder = 2 },
            //    new Category { Id = 3, Name = "Thriller", DisplayOrder = 3 },
            //    new Category { Id = 4, Name = "Romance", DisplayOrder = 4 }

            //    );


            //}

        }
    }
