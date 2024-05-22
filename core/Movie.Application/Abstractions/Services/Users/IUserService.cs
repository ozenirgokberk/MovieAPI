using Movie.Application.DTOs.User;

namespace Movie.Application.Abstractions.Services.Users;

public interface IUserService
{
    Task<CreateUserResponse> CreateUserAsync(CreateUser user);
}