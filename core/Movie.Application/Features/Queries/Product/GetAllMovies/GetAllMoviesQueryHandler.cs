using MediatR;
using Movie.Application.Repositories.Movie;

namespace Movie.Application.Features.Queries.Product.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllMoviesQueryRequest,GetAllMoviesQueryResponse>
{
    private readonly IMovieReadRepository _movieReadRepository;
    
    public GetAllProductsQueryHandler(IMovieReadRepository movieReadRepository)
    {
        _movieReadRepository = movieReadRepository;
    }
    public async Task<GetAllMoviesQueryResponse> Handle(GetAllMoviesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var totalCount = _movieReadRepository.GetAll(false).Count();
        var products = _movieReadRepository.GetAll(false).Skip(request.Page * request.Size)
            .Take(request.Size).Select(
                s => new
                {
                    s.Id,
                    s.Name,
                    s.CreatedDate,
                    s.ModifiedDate
                }).ToList();

        return new()
        {
            TotalCount = totalCount,
            Products = products
        };
    }
}