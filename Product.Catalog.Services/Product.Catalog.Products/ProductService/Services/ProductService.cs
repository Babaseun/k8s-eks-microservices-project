using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Entities;

namespace ProductService.Services;

public class ProductService(AppDbContext ctx) : IProductService
{
    public async Task<IEnumerable<Product>> GetProducts()
    {
        var x = Task.W
        var products = ctx.Model.FindEntityType(typeof(Product)).GetSchema();
        var product = ctx.Model.FindEntityType(typeof(Product)).GetProperties();

        return await ctx.Products.ToListAsync();
    }

    public async Task<Product?> GetProductById(int id)
        => await ctx.Products.FirstOrDefaultAsync(p => p.ProductId == id);
}