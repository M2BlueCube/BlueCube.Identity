using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlueCube.Identity.Data;

[Index(nameof(PublicKey), IsUnique = true)]
public class User : IdentityUser
{
    [MaxLength(512)]
    public string? PublicKey { get; init; }
}