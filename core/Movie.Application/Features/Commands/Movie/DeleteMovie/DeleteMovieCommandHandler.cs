using ETicaretAPI.Application.Features.Commands.Product.DeleteProduct;
using MediatR;
using Movie.Application.Features.Commands.Product.DeleteProduct;
using Movie.Application.Repositories.Movie;

namespace Movie.Application.Features.Commands.Movie.DeleteProduct;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommandRequest, DeleteMovieCommandResponse>
{
    private readonly IMovieWriteRepository _productWriteRepository;

    public DeleteMovieCommandHandler(IMovieWriteRepository productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }

    public async Task<DeleteMovieCommandResponse> Handle(DeleteMovieCommandRequest request, CancellationToken cancellationToken)
    {
        await _productWriteRepository.DeleteAsync(request.Id);
        await _productWriteRepository.SaveAsync();
        return new();
    }
}