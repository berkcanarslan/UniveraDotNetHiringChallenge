using Microsoft.EntityFrameworkCore;
using ProductApp.ProductAppData.DataModel;

namespace ProductApp.ProductAppData.Context;

public class ProductAppDbContext : DbContext
{
    public ProductAppDbContext(DbContextOptions<ProductAppDbContext> options) : base(options)
    {
        
    } 
    public DbSet<Product> Products { get; set; }
    public DbSet<List> Lists { get; set; }
    public DbSet<ListProduct> ListProducts { get; set; }
    public DbSet<User> Users { get; set; }
    
    // Add more DbSets for other entities as needed

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     // Configure entity relationships and other settings here
    //     modelBuilder.Entity<Product>().ToTable("Product");
    //     modelBuilder.Entity<Order>().ToTable("Order");
    //     // Add configurations for other entities as needed
    // }
}