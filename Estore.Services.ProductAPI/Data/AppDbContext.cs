using Estore.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace Estore.Services.ProductAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
            
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name="product one",
                Price = 12,
                Description = "product one des",
                CategoryName = "Category1",
                ImageUrl = "url"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "product one",
                Price = 12,
                Description = "product one des",
                CategoryName = "Category1",
                ImageUrl = "url"
            });
        }
    }
}
