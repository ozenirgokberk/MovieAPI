using MediatR;
using Movie.Application.Abstractions.Services.Auth;

namespace Movie.Application.Features.Commands.User.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private readonly IAuthService _authService;

    public LoginUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _authService.LoginAsync(request.UserNameOrEmail, request.Password);
        return new LoginUserSuccessCommandResponse()
        {
            Token = response
        };
    }
}