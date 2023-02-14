// 
using Microsoft.AspNetCore.Mvc;
using Gursha.Contracts.Authentication;
using Gursha.Application.Services.Authentication;
using ErrorOr;
// 
namespace Gursha.Api.Controllers;
// 
[Route("auth")]
public class AuthenticationController : ApiController
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
        ErrorOr<AuthenticationResult> authRequest = _authenticationService.Register(
            request.Firstname,
            request.Lastname,
            request.Email,
            request.Password
        );

        // 

        return authRequest.Match(
            authRequest => Ok(MapAuthResult(authRequest)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authRequest)
    {
        return new AuthenticationResponse(
            authRequest.ID,
            authRequest.Firstname,
            authRequest.Lastname,
            authRequest.Email,
            authRequest.Token
        );
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
        if (authRequest.IsError && authRequest.FirstError == Domain.Common.Errors.Errors.Authentication.EmailNotFound)
        {

            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authRequest.FirstError.Description);
        }
        return authRequest.Match(
                  authRequest => Ok(MapAuthResult(authRequest)),
                  errors => Problem(errors));
    }
}