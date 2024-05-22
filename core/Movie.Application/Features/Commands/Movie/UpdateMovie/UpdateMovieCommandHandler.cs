using ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;
using MediatR;
using Movie.Application.Repositories.Movie;

namespace Movie.Application.Features.Commands.Product.UpdateProduct;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommandRequest, UpdateMovieCommandResponse>
{
    readonly IMovieReadRepository _movieReadRepository;
    private readonly IMovieWriteRepository _movieWriteRepository;


    public UpdateMovieCommandHandler(IMovieReadRepository movieReadRepository, IMovieWriteRepository movieWriteRepository)
    {
        _movieReadRepository = movieReadRepository;
        _movieWriteRepository = movieWriteRepository;
    }

    public async Task<UpdateMovieCommandResponse> Handle(UpdateMovieCommandRequest request, CancellationToken cancellationToken)
    {
        var movie = await _movieReadRepository.GetByIdAsync(request.Id);
        movie.Name = request.Name;
        movie.CoverImageUrl = request.CoverImageUrl;
        await _movieWriteRepository.SaveAsync();
        return new();
    }
}