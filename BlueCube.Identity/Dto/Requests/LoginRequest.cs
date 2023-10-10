using System.ComponentModel.DataAnnotations;

namespace BlueCube.Identity.Dto.Requests;

public class LoginRequest
{
    [Required]
    [MaxLength(512)]
    public string PublicKey { get; init; } = string.Empty;
    [Required]
    [MaxLength(512)]
    public string Signature { get; init; } = string.Empty;
}