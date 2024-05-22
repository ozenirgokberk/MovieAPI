using MediatR;
using Movie.Application.Repositories.Movie;

namespace Movie.Application.Features.Queries.Product.GetProductById;

public class GetByIdMovieQueryHandler : IRequestHandler<GetByIdMovieQueryRequest, GetByIdMovieQueryResponse>
{
    private readonly IMovieReadRepository _movieReadRepository;


    public GetByIdMovieQueryHandler(IMovieReadRepository movieReadRepository)
    {
        _movieReadRepository = movieReadRepository;
    }

    public async Task<GetByIdMovieQueryResponse> Handle(GetByIdMovieQueryRequest request, CancellationToken cancellationToken)
    {
        Movie.Domain.Entities.Movie movie = await _movieReadRepository.GetByIdAsync(request.Id, false);
        return new()
        {
            Name = movie.Name,
        };
    }
}