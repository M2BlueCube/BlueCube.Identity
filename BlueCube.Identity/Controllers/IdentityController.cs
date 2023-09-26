using BlueCube.Identity.Dto.Requests;
using BlueCube.Identity.Dto.Responses;
using BlueCube.Identity.Services.Contract;
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
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
    {
        var token = await _identityService.AuthenticateAsync(request.Username, request.Password);
        return Ok(new LoginResponse(){  Token = token});
    }

    [HttpPost]
    public async Task<ActionResult> Signup(SignupRequest request)
    {
        await _identityService.RegisterAsync(request.UserName, request.Password);
        return Ok();
    }
}