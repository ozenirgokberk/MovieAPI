namespace Movie.Application.Abstractions.Token;

public interface ITokenHandler
{
    DTOs.Token CreateAccessToken();

    string RefreshToken();
}