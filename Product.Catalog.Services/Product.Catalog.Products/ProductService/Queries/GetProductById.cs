using MediatR;
using ProductService.Middlewares;
using ProductService.Services;

namespace ProductService.Queries;

public static class GetProductById
{
    public record Query(int Id) : IRequest<Response>;


    public class Handler(IProductService service) : IRequestHandler<Query, Response>
    {
        private readonly IProductService _service = service;

        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            var product =  await _service.GetProductById(request.Id);
            
            if (product == null)
                throw new NotFoundException();
            
            return new Response(product.ProductId, product.Name, product.Description);
        }
    }

    public record Response(int Id, string Name, string Description);
}