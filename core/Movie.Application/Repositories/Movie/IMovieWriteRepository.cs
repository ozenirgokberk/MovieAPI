using Movie.Application.Repositories.Common;

namespace Movie.Application.Repositories.Movie;

public interface IMovieWriteRepository : IWriteRepository<Domain.Entities.Movie>
{
    
}