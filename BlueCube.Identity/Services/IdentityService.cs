using BlueCube.Identity.Services.Contract;

namespace BlueCube.Identity.Services;

public class IdentityService : IIdentityService
{
    public Task<string> AuthenticateAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task RegisterAsync(string username, string password)
    {
        throw new NotImplementedException();
    }
}