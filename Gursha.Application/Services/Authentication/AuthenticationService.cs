// This is Authentication Service Implementation.
using Gursha.Application.Common.Interfaces.Authentication;
using Gursha.Application.Common.Interfaces.Persistence;
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
    public AuthenticationResult Login(string email, string password)
    {
        // 1. Check is user Exist
        if (_userRespository.GetUserByEmail(email) is not UserEntity user)
        {
            throw new Exception("User with given email doesn't exist.");
        }
        // 2. validate Password
        if (user.Password != password)
        {
            throw new Exception("Invalid Password");
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
    public AuthenticationResult Register(string firstname, string lastname, string email, string password)
    {
        // check is user exists
        if (_userRespository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exist.");
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