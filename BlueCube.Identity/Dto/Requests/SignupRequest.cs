using System.ComponentModel.DataAnnotations;

namespace BlueCube.Identity.Dto.Requests;

public class SignupRequest
{
    [Required]
    public string PublicKey { get; init; } = string.Empty;
    [Required]
    public string Signature { get; init; } = string.Empty;
}