using MediatR;
using UserService.Exceptions;
using UserService.Services;

namespace UserService.Queries;

public static class GetUserById
{
    public record Query(int Id) : IRequest<Response>;


    public class Handler(IUserService service) : IRequestHandler<Query, Response>
    {
        private readonly IUserService _service = service;

        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            var product =  await _service.GetUserById(request.Id);
            
            if (product == null)
                throw new NotFoundException();
            
            return new Response(product.Id, product.FirstName, product.LastName);
        }
    }

    public record Response(int Id, string FirstName, string LastName);
}