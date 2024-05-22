using MediatR;
using Movie.Application.Features.Commands.Product.UpdateProduct;

namespace ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;

public class UpdateMovieCommandRequest: IRequest<UpdateMovieCommandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CoverImageUrl { get; set; }
}