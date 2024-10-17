using ProductService.Entities;

namespace ProductService.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product?> GetProductById(int id);
}