using BlueCube.Identity.Dto.Requests;
using BlueCube.Identity.Dto.Responses;

namespace BlueCube.Identity.Services.Contract;

public interface IIdentityService
{
    Task<string> AuthenticateAsync(string username , string password);
    Task RegisterAsync(string username , string password);
}