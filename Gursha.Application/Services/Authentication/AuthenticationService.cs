// This is Authentication Service Implementation.
using ErrorOr;
using Gursha.Application.Common.Interfaces.Authentication;
using Gursha.Application.Common.Interfaces.Persistence;
using Gursha.Domain.Common.Errors;
using Gursha.Domain.Entities;

namespace Gursha.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IjwtTokenGenerator _ijwtTokenGenerator;
    private readonly IUserRespository _userRespository;
    // Constructor
    public AuthenticationService(IjwtTokenGenerator jwtTTokenGenerator, IUserRespository userRespository)
    {
        _ijwtTokenGenerator = jwtTTokenGenerator;
        _userRespository = userRespository;
    }
    // Login User
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // 1. Check is user Exist
        if (_userRespository.GetUserByEmail(email) is not UserEntity user)
        {
            // return single Error
            return Errors.Authentication.EmailNotFound;
        }
        // 2. validate Password
        if (user.Password != password)
        {
            // return list of Errors
            return new[] { Errors.Authentication.InvalidPassword };
        }
        // 3. Generate login token
        var token = _ijwtTokenGenerator.GenerateToken(user.ID, user.Firstname, user.Lastname);
        return new AuthenticationResult(
            user.ID,
            user.Firstname,
            user.Lastname,
            email,
            token);
    }
    //  Register User
    public ErrorOr<AuthenticationResult> Register(string firstname, string lastname, string email, string password)
    {
        // check is user exists
        if (_userRespository.GetUserByEmail(email) is not null)
        {
            // throw new Exception("User with given email already exist.");
            return Errors.User.DuplicateEmail;
        }
        // create new user
        var user = new UserEntity
        {
            Firstname = firstname,
            Lastname = lastname,
            Email = email,
            Password = password
        };
        _userRespository.Add(user);
        // create token
        var token = _ijwtTokenGenerator.GenerateToken(user.ID, firstname, lastname);

        return new AuthenticationResult(
            user.ID,
            firstname,
            lastname,
            email,
            token
            );
    }
}