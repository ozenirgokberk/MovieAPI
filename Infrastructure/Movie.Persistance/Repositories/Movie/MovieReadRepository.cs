using Movie.Application.Repositories.Movie;
using Movie.Persistance.Context;

namespace Movie.Persistance.Repositories;

public class MovieReadRepository :ReadRepository<Movie.Domain.Entities.Movie>, IMovieReadRepository
{
    public MovieReadRepository(ApplicationDbContext context): base(context)
    {
        
    }
}