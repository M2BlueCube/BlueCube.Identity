using System.ComponentModel.DataAnnotations;

namespace BlueCube.Identity.Dto.Requests;

public class LoginRequest
{
    [Required]
    public string Username { get; init; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; init; } = string.Empty;
}