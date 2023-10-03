using BlueCube.Identity.Data;
using BlueCube.Identity.Dto.Requests;
using BlueCube.Identity.Dto.Responses;

namespace BlueCube.Identity.Services;

public interface IIdentityService
{
    Task RegisterAsync(string publicKey , string signature);
    Task<string> AuthenticateAsync(string publicKey , string signature);
    Task<User?> GetUserAsync(string userId);
}