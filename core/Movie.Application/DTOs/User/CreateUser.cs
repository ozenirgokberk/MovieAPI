namespace Movie.Application.DTOs.User;

public class CreateUser
{
    public string Password { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string PasswordConfirm { get; set; }
    public string UserName { get; set; }
}