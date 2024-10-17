using Microsoft.EntityFrameworkCore;
using UserService.Entities;

namespace UserService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // var user = modelBuilder.Entity<User>();
        // user.HasKey(e => e.ProductId);
        // user.Property(a => a.Name)
        //     .IsRequired();
        // user.Property(a => a.Price)
        //     .IsRequired();
    }
}