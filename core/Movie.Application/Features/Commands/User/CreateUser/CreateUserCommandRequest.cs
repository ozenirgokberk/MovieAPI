using MediatR;

namespace Movie.Application.Features.Commands.User.CreateUser;

public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
{
    public string Password { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string PasswordConfirm { get; set; }
    public string UserName { get; set; }
}