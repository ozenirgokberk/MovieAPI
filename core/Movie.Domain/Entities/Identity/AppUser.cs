using Microsoft.AspNetCore.Identity;

namespace Movie.Domain.Entities.Identity;

public class AppUser : IdentityUser<int>
{
    public string NameSurname { get; set; }
}