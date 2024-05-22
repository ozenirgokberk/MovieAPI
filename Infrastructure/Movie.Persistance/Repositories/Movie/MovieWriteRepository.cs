using Movie.Application.Repositories.Common;
using Movie.Application.Repositories.Movie;
using Movie.Persistance.Context;

namespace Movie.Persistance.Repositories;

public class MovieWriteRepository :WriteRepository<Movie.Domain.Entities.Movie>, IMovieWriteRepository
{
    public MovieWriteRepository(ApplicationDbContext context): base(context)
    {
        
    }
}