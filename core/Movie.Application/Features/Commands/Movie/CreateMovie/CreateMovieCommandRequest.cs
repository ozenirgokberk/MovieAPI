using MediatR;

namespace Movie.Application.Features.Commands.Product.CreateProduct;

public class CreateMovieCommandRequest : IRequest<CreateMovieCommandResponse>
{
    public string Name { get; set; }
    public string CoverImageUrl { get; set; }
}