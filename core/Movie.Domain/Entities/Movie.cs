using Movie.Domain.Entities.Base;

namespace Movie.Domain.Entities;

public class Movie : BaseEntity
{
    public string Name { get; set; }
    public string CoverImageUrl { get; set; }
}