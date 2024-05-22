using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Features.Commands.User.CreateUser;
using Movie.Application.Features.Commands.User.LoginUser;

namespace Movie.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    // GET
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommandRequest createUserCommandRequest)
    {
        var response = await _mediator.Send(createUserCommandRequest);
        return Ok(response);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest loginUserCommandRequest)
    {
        var response = await _mediator.Send(loginUserCommandRequest);
        return Ok(response);
    }
}