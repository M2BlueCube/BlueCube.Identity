using System.ComponentModel.DataAnnotations;

namespace BlueCube.Identity.Dto.Requests;

public class SignupRequest
{
    [Required]
    public string UserName { get; init; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; init; } = string.Empty;
}