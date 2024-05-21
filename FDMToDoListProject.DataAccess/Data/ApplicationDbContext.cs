using FDMToDoListProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FDMToDoListProject.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //define relationship
            modelBuilder.Entity<Category>()
                .HasData(
                new Category { Id = 1, Name = "Education", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Fitness", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Work", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Leisure", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Others", DisplayOrder = 5 });
        }

        public DbSet<Category> Categories { get; set; }
    }
}
