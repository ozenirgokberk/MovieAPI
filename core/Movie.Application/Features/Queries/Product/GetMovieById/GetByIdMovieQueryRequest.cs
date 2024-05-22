using MediatR;

namespace Movie.Application.Features.Queries.Product.GetProductById;

public class GetByIdMovieQueryRequest:IRequest<GetByIdMovieQueryResponse>
{
    public int Id { get; set; }
}