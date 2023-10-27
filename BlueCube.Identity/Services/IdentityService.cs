using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using BlueCube.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BlueCube.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<User> _userManager;
    private readonly IRsaService _rsaService;

    private readonly string _jwtSecretKey;
    public IdentityService(UserManager<User> userManager, IConfiguration config, IRsaService rsaService)
    {
        _userManager = userManager;
        _rsaService = rsaService;
        _jwtSecretKey = config["Jwt:Key"] ?? throw new Exception("Jwt secret key is null");
    }

    public async Task RegisterAsync(string publicKey ,string userName, string signature)
    {
        Verify(publicKey, signature);
        var user = new User{ UserName = userName , PublicKey = publicKey};
        var result = await _userManager.CreateAsync(user);
        if (!result.Succeeded)
            throw new Exception(string.Join(',', result.Errors.Select(e => $"{e.Code} : {e.Description}")));
    }
    public async Task<string> AuthenticateAsync(string publicKey , string signature)
    {
        Verify(publicKey, signature);
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PublicKey == publicKey);
        if (user is null)
            throw new KeyNotFoundException("the publicKey didn't register");
        var roles = await _userManager.GetRolesAsync(user);
        var token = GenerateToken(user, roles);
        var encryptedToken = _rsaService.Encrypt(token, publicKey) ?? 
                             throw new Exception("encryption was failed");
        return encryptedToken;
    }
    public Task<User?> GetUserAsync(string userId) => _userManager.FindByIdAsync(userId);
    public async  Task<IEnumerable<User>> GetAllUsersAsync() => await _userManager.Users.ToListAsync();

    private void Verify(string publicKey, string signature)
    {
        if (publicKey != _rsaService.GetNormalizedPublicKey(publicKey))
            throw new InvalidCastException("public Key is not normal");
        if (!_rsaService.Verify(publicKey, publicKey, signature))
            throw new InvalidCredentialException("invalid signature");
    }
    private string GenerateToken(User user, IEnumerable<string> roles)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtSecretKey);
        var expiresDate = DateTime.UtcNow.AddDays(7);
        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id),
            new (ClaimTypes.Name, user.UserName!),
            new (ClaimTypes.Rsa, user.PublicKey)
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
}