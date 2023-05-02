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
    }
}
