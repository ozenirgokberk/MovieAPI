using Microsoft.AspNetCore.Identity;
using Movie.Application.Abstractions.Services.Auth;
using Movie.Application.Abstractions.Token;
using Movie.Application.DTOs;
using Movie.Application.Exceptions;
using Movie.Domain.Entities.Identity;

namespace Movie.Persistance.Services.Auth;


public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenHandler _tokenHandler;

    public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenHandler = tokenHandler;
    }

    public async Task<Token> LoginAsync(string userNameOrEmail, string password)
    {
        var user = await _userManager.FindByNameAsync(userNameOrEmail);
        if (user == null)
        {
            user = await _userManager.FindByEmailAsync(userNameOrEmail);
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        if (result.Succeeded) // Authentication succeeded
        {
            Token token = _tokenHandler.CreateAccessToken();
            return token;
        }

        throw new AuthenticationErrorException();
    }
}