using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Queries;
using ProductService.Services;

namespace ProductService.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController(IMediator mediator, IProductService service) : ControllerBase
{
    private IMediator _mediator = mediator;
    private readonly IProductService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetProducts()
        => Ok(await _service.GetProducts());


    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var response = await _mediator.Send(new GetProductById.Query(id));
        return Ok(response);
    }
}