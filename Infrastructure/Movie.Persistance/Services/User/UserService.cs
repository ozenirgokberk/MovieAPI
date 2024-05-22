using Microsoft.AspNetCore.Identity;
using Movie.Application.Abstractions.Services.Users;
using Movie.Application.DTOs.User;
using Movie.Domain.Entities.Identity;

namespace Movie.Persistance.Services.User;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<CreateUserResponse> CreateUserAsync(Application.DTOs.User.CreateUser user)
    {
        var result = await _userManager.CreateAsync(new AppUser()
        {
            UserName = user.UserName,
            Email = user.Email,
            NameSurname = user.NameSurname
        }, user.Password);

        CreateUserResponse response = new CreateUserResponse() { Succeeded = result.Succeeded };

        if (result.Succeeded)
            response.Message = "Başarılı giriş";
        else
        {
            foreach (var error in result.Errors)
            {
                response.Message += $"{error.Code} - {error.Description}";
            }
        }

        return response;
    }
}