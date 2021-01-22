using Microsoft.EntityFrameworkCore;

namespace ToDoListApp.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
new Category { CategoryId = "work", Name = "Work" },
new Category { CategoryId = "home", Name = "Home" },
new Category { CategoryId = "ex", Name = "Exercise" },
new Category { CategoryId = "shop", Name = "Shopping" },
new Category { CategoryId = "contact", Name = "Contact" }
                );
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "open", Name = "Open" },
                new Status { StatusId = "completed", Name = "Completed" }
                );
        }
    }
}