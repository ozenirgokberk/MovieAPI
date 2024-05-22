using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movie.Application.Abstractions.Services.Auth;
using Movie.Application.Abstractions.Services.Users;
using Movie.Application.Repositories.Movie;
using Movie.Domain.Entities.Identity;
using Movie.Persistance.Context;
using Movie.Persistance.Repositories;
using Movie.Persistance.Services.Auth;
using Movie.Persistance.Services.User;

namespace Movie.Persistance;


public static class ServiceRegistration
{
    public static void AddPersistanceServices(this IServiceCollection services)
    {
        
        services.AddDbContext<ApplicationDbContext>
            (opt => opt.UseSqlServer(Configuration.ConnectionString));
        
        
        services.AddIdentity<AppUser, AppUserRole>(options =>
        {
            options.Password.RequiredLength = 3;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredUniqueChars = 0;
        }).AddEntityFrameworkStores<ApplicationDbContext>(); // migration oluştur.
        
        services.AddScoped<IMovieReadRepository, MovieReadRepository>();
        services.AddScoped<IMovieWriteRepository, MovieWriteRepository>();


        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
    }
}