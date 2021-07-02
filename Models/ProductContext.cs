using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_2.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(c => c.CategoryId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category);

            //seeding
            modelBuilder.Entity<Category>().HasData(new Category{
                CategoryId = 1,
                CategoryName = "Category 1",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                ProductName = "Product 1",
                CategoryId = 1,
            });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}