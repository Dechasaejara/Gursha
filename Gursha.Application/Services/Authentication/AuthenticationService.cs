// This is Authentication Service Implementation.
using Gursha.Application.Common.Interfaces.Authentication;

namespace Gursha.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IjwtTokenGenerator _ijwtTokenGenerator;
    public AuthenticationService(IjwtTokenGenerator jwtTTokenGenerator)
    {
        _ijwtTokenGenerator = jwtTTokenGenerator;
    }
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
 Guid.NewGuid(),
 "firstname",
 "lastname",
email,
"token"
        );
    }

    public AuthenticationResult Register(string firstname, string lastname, string email, string password)
    {
        // check is user exists

        // create new user


        // create token
        Guid userID = Guid.NewGuid();
        var token = _ijwtTokenGenerator.GenerateToken(userID, firstname, lastname);

        return new AuthenticationResult(
            userID,
            firstname,
            lastname,
            email,
            token
            );
    }
}