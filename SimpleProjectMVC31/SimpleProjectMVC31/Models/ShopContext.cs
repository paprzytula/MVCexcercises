using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleProjectMVC31.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
              new Category { CategoryId = 1, Name = "Chocolates" },
              new Category { CategoryId = 2, Name = "Fruit Candy" },
              new Category { CategoryId = 3, Name = "Gummy Candy" },
              new Category { CategoryId = 4, Name = "Halloween Candy" },
              new Category { CategoryId = 5, Name = "Hard Candy" }
              );

            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  ProductId = 1,
                  CategoryId = 1,
                  Code = "Chocolate_Assorted",
                  Name = "Assorted Chocolate",
                  Price = (decimal)4.99
              },
              new Product
              {
                  ProductId = 2,
                  CategoryId = 1,
                  Code = "Chocolate_Mixed",
                  Name = "Chocolate Mixed Candy",
                  Price = (decimal)5.99
              },
              new Product
              {
                  ProductId = 3,
                  CategoryId = 1,
                  Code = "Chocolate_MMS",
                  Name = "M&M",
                  Price = (decimal)3.75
              },
              new Product
              {
                  ProductId = 4,
                  CategoryId = 2,
                  Code = "Fruit_Chewy",
                  Name = "Chewy Fruit Candy",
                  Price = (decimal)6.90
              },
              new Product
              {
                  ProductId = 5,
                  CategoryId = 2,
                  Code = "Fruit_Pops",
                  Name = "Fruit Lolli Pops",
                  Price = (decimal)2.90
              },
              new Product
              {
                  ProductId = 6,
                  CategoryId = 2,
                  Code = "Fruit_Sour",
                  Name = "Sour Fruit Candy",
                  Price = (decimal)4.95
              },
              new Product
              {
                  ProductId = 7,
                  CategoryId = 3,
                  Code = "Gummy_Import",
                  Name = "Imported Gummy Candy",
                  Price = (decimal)11.90
              },
              new Product
              {
                  ProductId = 8,
                  CategoryId = 3,
                  Code = "Gummy_Sour",
                  Name = "Gummy Sour Candy",
                  Price = (decimal)1.90
              },
              new Product
              {
                  ProductId = 9,
                  CategoryId = 3,
                  Code = "Gummy_Traditional",
                  Name = "Traditional Gummy Candy",
                  Price = (decimal)2.90
              },
              new Product
              {
                  ProductId = 10,
                  CategoryId = 4,
                  Code = "Halloween_Assorted",
                  Name = "Assorted Halloween Candy",
                  Price = (decimal)3.50
              },
              new Product
              {
                  ProductId = 11,
                  CategoryId = 4,
                  Code = "Halloween_Orange",
                  Name = "Halloween Orange Cones",
                  Price = (decimal)4.33
              },
              new Product
              {
                  ProductId = 12,
                  CategoryId = 4,
                  Code = "Halloween_Red",
                  Name = "Halloween Red Cones",
                  Price = (decimal)3.98
              },
              new Product
              {
                  ProductId = 13,
                  CategoryId = 5,
                  Code = "Hard_Fruit",
                  Name = "Hard Fruit Candy",
                  Price = (decimal)9.90
              },
              new Product
              {
                  ProductId = 14,
                  CategoryId = 5,
                  Code = "Hard_Assorted",
                  Name = "Hard Assorted Candy",
                  Price = (decimal)8.97
              },
              new Product
              {
                  ProductId = 15,
                  CategoryId = 5,
                  Code = "Hard_Sour",
                  Name = "Sour Hard Candy",
                  Price = (decimal)5.55
              });
        }
    }
}
