namespace Movie.Application.Abstractions.Services.Auth;

public interface IAuthService
{
    Task<DTOs.Token> LoginAsync(string userNameOrEmail, string password);
}