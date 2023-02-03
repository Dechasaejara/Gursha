// 
using Microsoft.AspNetCore.Mvc;
using Gursha.Contracts.Authentication;
using Gursha.Application.Services.Authentication;
// 
namespace Gursha.Api.Controllers;
// 
[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    //
    private readonly IAuthenticationService _authenticationService;
    // 
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    // 
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        // 
        var authRequest = _authenticationService.Register(
            request.Firstname,
            request.Lastname,
            request.Email,
            request.Password
        );
        // 
        var authResponse = new AuthenticationResponse(
            authRequest.ID,
            authRequest.Firstname,
            authRequest.Lastname,
            authRequest.Email,
            authRequest.Token
        );
        return Ok(authResponse);
    }
    // 
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        // 
        var authRequest = _authenticationService.Login(
            request.Email,
            request.Password
        );
        // 
        var authResponse = new AuthenticationResponse(
            authRequest.ID,
            authRequest.Firstname,
            authRequest.Lastname,
            authRequest.Email,
            authRequest.Token
        );
        return Ok(authResponse);
    }
}