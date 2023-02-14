// This is a interface that Define the Authentication service.
using ErrorOr;

namespace Gursha.Application.Services.Authentication;
public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
    ErrorOr<AuthenticationResult> Register(string firstname, string lastname, string email, string password);
}