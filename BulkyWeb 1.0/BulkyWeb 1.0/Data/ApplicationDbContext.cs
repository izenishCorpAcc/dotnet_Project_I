using BulkyWeb_1._0.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BulkyWeb_1._0.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
          
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<QList> QuestionList { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

            new Category { Id=1,Name="Action",DisplayOrder=1 },
            new Category { Id = 2, Name = "Comedy", DisplayOrder = 2 },
            new Category { Id = 3, Name = "Thriller", DisplayOrder = 3 },
            new Category { Id = 4, Name = "Romance", DisplayOrder = 4 }

            );

            modelBuilder.Entity<QList>().HasData(
                new QList { Question_ID = 2, Question = "King Of England", Correst_Answer = "King Charles III", WrongAnswer_1 = "King Charles II", WrongAnswer_2 = "King Charles I", WrongAnswer_3 = "King Charles IV" },
                new QList { Question_ID = 3, Question = "How many states are there in USA", Correst_Answer = "50", WrongAnswer_1 = "51", WrongAnswer_3 = "52", WrongAnswer_2 = "49" }
                );
        }

    }
}
