using ETicaretAPI.Application.Features.Commands.Product.DeleteProduct;
using ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Features.Commands.Product.CreateProduct;
using Movie.Application.Features.Queries.Product.GetAllProducts;
using Movie.Application.Features.Queries.Product.GetProductById;

namespace ETicaretAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]
public class MoviesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MoviesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllMoviesQueryRequest getAllMoviesQueryRequest)
    {
        var response = await _mediator.Send(getAllMoviesQueryRequest);
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] GetByIdMovieQueryRequest getByIdMovieQueryRequest)
    {
        var response = await _mediator.Send(getByIdMovieQueryRequest);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateMovieCommandRequest createMovieCommandRequest)
    {
        var response = await _mediator.Send(createMovieCommandRequest);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateMovieCommandRequest updateMovieCommandRequest)
    {
        _ = await _mediator.Send(updateMovieCommandRequest);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteMovieCommandRequest deleteMovieCommandRequest)
    {
        _ = await _mediator.Send(deleteMovieCommandRequest);
        return Ok();
    }
}