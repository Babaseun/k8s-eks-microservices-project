using ProductService.Entities;
using ProductService.Repositories;

namespace ProductService.Data;

public static class PreSeeder
{
    public static async Task Seeder(AppDbContext ctx, IProductRepository productRepository)
    {
        await ctx.Database.EnsureCreatedAsync();
        var listOfProducts = new List<Product>
        {
            new Product 
            { 
                ProductId = 1, 
                Name = "Wireless Mouse", 
                Description = "Ergonomic wireless mouse with 1600 DPI", 
                Price = 25.99m, 
                StockQuantity = 150 
            },
            new Product 
            { 
                ProductId = 2, 
                Name = "Mechanical Keyboard", 
                Description = "RGB backlit mechanical keyboard with brown switches", 
                Price = 75.49m, 
                StockQuantity = 85 
            },
            new Product 
            { 
                ProductId = 3, 
                Name = "27-inch Monitor", 
                Description = "144Hz gaming monitor with 1ms response time", 
                Price = 299.99m, 
                StockQuantity = 40 
            },
            new Product 
            { 
                ProductId = 4, 
                Name = "USB-C Hub", 
                Description = "7-in-1 USB-C hub with HDMI and Ethernet port", 
                Price = 39.95m, 
                StockQuantity = 200 
            },
            new Product 
            { 
                ProductId = 5, 
                Name = "External SSD 1TB", 
                Description = "Portable 1TB external SSD with USB 3.1", 
                Price = 120.00m, 
                StockQuantity = 60 
            }
        };


        if (!ctx.Products.Any())
        {
            foreach (var product in listOfProducts)
            {
                ctx.Products.Add(product);
            }
            await ctx.SaveChangesAsync();
        }
    }
}