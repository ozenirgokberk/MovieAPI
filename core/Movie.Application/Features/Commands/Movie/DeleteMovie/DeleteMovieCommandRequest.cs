using MediatR;
using Movie.Application.Features.Commands.Product.DeleteProduct;

namespace ETicaretAPI.Application.Features.Commands.Product.DeleteProduct;

public class DeleteMovieCommandRequest : IRequest<DeleteMovieCommandResponse>
{
    public int Id { get; set; }
}