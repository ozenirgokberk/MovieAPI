using MediatR;
using Movie.Application.Features.Commands.Product.CreateProduct;
using Movie.Application.Repositories.Movie;

namespace ETicaretAPI.Application.Features.Commands.Movie.CreateMovie;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommandRequest,CreateMovieCommandResponse>
{
    private readonly IMovieWriteRepository _MovieWriteRepository;

    public CreateMovieCommandHandler(IMovieWriteRepository MovieWriteRepository)
    {
        _MovieWriteRepository = MovieWriteRepository;
    }

    public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
    {
        await _MovieWriteRepository.AddAsync(new global::Movie.Domain.Entities.Movie()
        {
            Name = request.Name,
            CoverImageUrl = request.CoverImageUrl
        });

        await _MovieWriteRepository.SaveAsync();
        return new();
    }
}