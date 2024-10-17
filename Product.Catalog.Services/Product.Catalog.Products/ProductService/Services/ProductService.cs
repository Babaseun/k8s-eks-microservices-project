using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Entities;

namespace ProductService.Services;

public class ProductService(AppDbContext ctx) : IProductService
{
    public async Task<IEnumerable<Product>> GetProducts()
        => await ctx.Products.ToListAsync();

    public async Task<Product?> GetProductById(int id)
        => await ctx.Products.FirstOrDefaultAsync(p => p.ProductId == id);
}