using ProductService.Data;
using ProductService.Entities;

namespace ProductService.Repositories;

public class ProductRepository(AppDbContext ctx) : BaseRepository<Product>(ctx), IProductRepository;