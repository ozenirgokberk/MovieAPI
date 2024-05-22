using MediatR;
using Movie.Application.Abstractions.Services.Users;

namespace Movie.Application.Features.Commands.User.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IUserService _userService;


    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.CreateUserAsync(new DTOs.User.CreateUser()
        {
            Email = request.Email,
            NameSurname = request.NameSurname,
            Password = request.Password,
            UserName = request.UserName
        });
        return new CreateUserCommandResponse()
        {
            Message = response.Message,
            Succeeded = response.Succeeded
        };
    }
}