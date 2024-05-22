
using Microsoft.EntityFrameworkCore;
using Movie.Domain.Entities.Base;

namespace Movie.Application.Repositories.Common;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}