using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Movie.Application.Repositories.Common;
using Movie.Domain.Entities.Base;
using Movie.Persistance.Context;

namespace Movie.Persistance.Repositories;

public class WriteRepository<T>:IWriteRepository<T> where T: BaseEntity
{
    private readonly ApplicationDbContext _context;

    public WriteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();
    public async Task<bool> AddAsync(T model)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(List<T> model)
    {
        await Table.AddRangeAsync(model);
        return true;
    }

    public bool Delete(T model)
    {
        EntityEntry<T> entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }
    public bool DeleteRange(List<T> model)
    {
        Table.RemoveRange(model);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        T model = await Table.FirstOrDefaultAsync(data => data.Id == id);
        return Delete(model);
    }

    public bool Update(T model)
    {
        EntityEntry entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }

    public Task<int> SaveAsync() => _context.SaveChangesAsync();
}