using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Movie.Application.Abstractions.Token;

namespace Movie.Infrastructure.Services.Token;

public class TokenHandler : ITokenHandler
{
    private readonly IConfiguration _configuration;

    public TokenHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Application.DTOs.Token CreateAccessToken()
    {
        Application.DTOs.Token token = new Application.DTOs.Token();
        SymmetricSecurityKey securityKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityToken"]));

        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        token.ExpiredDate = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["Token:ExpireMinute"]));

        JwtSecurityToken securityToken =
            new JwtSecurityToken(audience: _configuration["Token:Audience"],
                expires: token.ExpiredDate, notBefore: DateTime.UtcNow, issuer: _configuration["Token:Issuer"],
                signingCredentials: signingCredentials);

        JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
        token.AccessToken = securityTokenHandler.WriteToken(securityToken);
        token.RefreshToken = RefreshToken();
        return token;
    }

    public string RefreshToken()
    {
        byte[] number = new byte[32];
        using (RandomNumberGenerator random = RandomNumberGenerator.Create())
        {
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        };
    }
}