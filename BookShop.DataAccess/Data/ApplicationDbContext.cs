using Microsoft.EntityFrameworkCore;
using BookShop.Models.Models;

namespace BookShop.DataAcess.Data
{
   public class ApplicationDbContext : DbContext
   {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category 
                { 
                    CategoryId = Guid.Parse("7bce5010-cc03-4d32-83fd-ca8be036b410"),
                    Name = "Action",
                    DisplayOrder = 1
                },

                new Category
                {
                    CategoryId = Guid.Parse("b193339b-85be-4884-ab1a-6f8f6f24d588"),
                    Name = "SciFi",
                    DisplayOrder = 2
                },

                new Category
                {
                    CategoryId = Guid.Parse("cca4011f-1e42-4a9e-a8bd-c7fe3577af65"),
                    Name = "History",
                    DisplayOrder = 3
                }
            );
        }


   }
}
