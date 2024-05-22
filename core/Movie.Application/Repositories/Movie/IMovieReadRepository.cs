using Movie.Application.Repositories.Common;

namespace Movie.Application.Repositories.Movie;

public interface IMovieReadRepository: IReadRepository<Domain.Entities.Movie>
{
    
}