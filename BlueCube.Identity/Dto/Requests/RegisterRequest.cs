using System.ComponentModel.DataAnnotations;

namespace BlueCube.Identity.Dto.Requests;

public class RegisterRequest
{
    [Required]
    [MaxLength(512)]
    public string PublicKey { get; init; } = string.Empty;
    [Required]
    [MaxLength(64)]
    public string UserName { get; init; } = string.Empty;
    [Required]
    [MaxLength(512)]
    public string Signature { get; init; } = string.Empty;
    
}