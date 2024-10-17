using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Queries;
using UserService.Services;

namespace UserService.Controllers;

[ApiController]
public class UserController(IMediator mediator, IUserService service) : ControllerBase
{
    private IMediator _mediator = mediator;
    private readonly IUserService _service = service;

    [HttpGet("users")]
    public async Task<IActionResult> GetProducts()
        => Ok(await _service.GetUsers());


    [HttpGet("users/{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var response = await _mediator.Send(new GetUserById.Query(id));
        return Ok(response);
    }
}