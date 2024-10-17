using Microsoft.EntityFrameworkCore;
using ProductService.Entities;

namespace ProductService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var product = modelBuilder.Entity<Product>();
        product.HasKey(e => e.ProductId);
        product.Property(a => a.Name)
            .IsRequired();
        product.Property(a => a.Price)
            .IsRequired();
    }
}