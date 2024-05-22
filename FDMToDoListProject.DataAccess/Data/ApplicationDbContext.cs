using FDMToDoListProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FDMToDoListProject.DataAccess.Data
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //define relationship
            //modelBuilder.Entity<Category>()
            //    .HasMany(c => c.ToDoLists)
            //    .WithOne(a => a.Category)
            //    .HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<Category>()
                .HasData(
                new Category { Id = 1, Name = "Education", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Fitness", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Work", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Leisure", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Others", DisplayOrder = 5 });
            
            modelBuilder.Entity<ToDoList>().HasData(
               new ToDoList { Id = 1, CategoryId = 3, Title = "ToDoList Project", DueDate = new DateTime(2024, 5, 24) },
               new ToDoList { Id = 2, CategoryId = 1, Title = "Do LeetCode", Description = "LeetCode is hard", DueDate = new DateTime(2024, 12, 24), HighPriority = true },
               new ToDoList { Id = 3, CategoryId = 2, Title = "Go Gym", DueDate = new DateTime(2024, 5, 20), Completed = true },
               new ToDoList { Id = 4, CategoryId = 5, Title = "Fishing", Description = "Catch fish for lunch", DueDate = new DateTime(2024, 6, 24), HighPriority = true },
               new ToDoList { Id = 5, CategoryId = 4, Title = "Walk at Nature Park", DueDate = new DateTime(2024, 5, 21) }

               );
        }

        
    }
}
