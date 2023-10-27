using System.Security.Claims;
using BlueCube.Identity.Dto;
using BlueCube.Identity.Dto.Requests;
using BlueCube.Identity.Dto.Responses;
using BlueCube.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlueCube.Identity.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    [HttpPost]
    public async Task<ActionResult> Register(RegisterRequest request)
    {
        await _identityService.RegisterAsync(request.PublicKey, request.UserName, request.Signature!);
        return Ok();
    }
    
    [HttpPost]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
    {
        var token = await _identityService.AuthenticateAsync(request.PublicKey, request.Signature);
        return Ok(new LoginResponse(){  Token = token});
    }
    
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<UserDto>> MyUser()
    {
        var userId = HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            throw new KeyNotFoundException(ClaimTypes.NameIdentifier + " is not in the Claims");
        var user = await _identityService.GetUserAsync(userId) ?? throw new KeyNotFoundException("some thing went wrong");
        var userDto = new UserDto(user.Id, user.UserName!, user.PublicKey);
        return Ok(userDto);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<UserDto>> GetAllUsers()
    {
        var users = await _identityService.GetAllUsersAsync();
        var userDtos = users.Select(user => new UserDto(user.Id, user.UserName!, user.PublicKey)).ToList();
        return Ok(userDtos);
    }

}