using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using BlueCube.Identity.Services.Contract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BlueCube.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<IdentityUser> _userManager;

    private readonly string _jwtSecretKey;
    public IdentityService(UserManager<IdentityUser> userManager, IConfiguration config)
    {
        _userManager = userManager;
        _jwtSecretKey = config["Jwt:Key"] ?? string.Empty;
    }

    public async Task<string> AuthenticateAsync(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user is null)
            throw new KeyNotFoundException("Username doesn't exist");
        var isPasswordVerified = await _userManager.CheckPasswordAsync(user, password);
        if (!isPasswordVerified)
            throw new InvalidCredentialException("Invalid password");

        var roles = await _userManager.GetRolesAsync(user);
        var token = GenerateToken(user.Id, user.UserName!, roles);
        return token;
    }

    private string GenerateToken(string userId, string userName, IEnumerable<string> roles)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtSecretKey);
        var expiresDate = DateTime.UtcNow.AddDays(7);
        
        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, userId),
            new (ClaimTypes.Name, userName)
        };
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expiresDate,
            SigningCredentials = 
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);

        var jwt = tokenHandler.WriteToken(token);

        return jwt;
    }
    public async Task RegisterAsync(string username, string password)
    { 
        var user = await _userManager.FindByNameAsync(username);
        if (user is not null) throw new DuplicateNameException("Username already exist");

        user = new() { UserName = username };
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
            throw new Exception(string.Join(',', result.Errors.Select(e => $"{e.Code} : {e.Description}")));
    }
}