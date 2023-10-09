using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlueCube.Identity.Data;

[Index(nameof(PublicKey), IsUnique = true)]
public class User : IdentityUser
{
    public string PublicKey { get; init; } = string.Empty;
}