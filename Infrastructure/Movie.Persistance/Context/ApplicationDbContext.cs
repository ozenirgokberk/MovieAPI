using Movie.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie.Domain.Entities.Base;

namespace Movie.Persistance.Context;

public class ApplicationDbContext : IdentityDbContext<AppUser,AppUserRole,int>
{
    public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
    public DbSet<Domain.Entities.Movie> Movies { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var datas = ChangeTracker.Entries<BaseEntity>();

        foreach (var data in datas)
        {
            if (data.State == EntityState.Added)
                data.Entity.CreatedDate = DateTime.UtcNow;
            if (data.State == EntityState.Modified)
                data.Entity.ModifiedDate = DateTime.UtcNow;
        }
            
        return base.SaveChangesAsync(cancellationToken);
    }
}