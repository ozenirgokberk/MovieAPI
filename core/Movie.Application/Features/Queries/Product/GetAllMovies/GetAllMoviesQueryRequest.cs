using MediatR;

namespace Movie.Application.Features.Queries.Product.GetAllProducts;

public class GetAllMoviesQueryRequest : IRequest<GetAllMoviesQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}