using BlueCube.Identity.Data;

namespace BlueCube.Identity.Services;

public interface IIdentityService
{
    Task RegisterAsync(string publicKey , string signature);
    Task<string> AuthenticateAsync(string publicKey , string signature);
    Task<User?> GetUserAsync(string userId);
}