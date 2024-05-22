using Movie.Domain.Entities.Base;

namespace Movie.Application.Repositories.Common;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T model);
    Task<bool> AddRangeAsync(List<T> model);
    bool Delete(T model);
    bool DeleteRange(List<T> model);
    Task<bool> DeleteAsync(int id);
    bool Update(T model);
    Task<int> SaveAsync();
}