using System;
// This is the Authentication service result.
namespace Gursha.Application.Services.Authentication;

public record AuthenticationResult(
    Guid ID,
    string Firstname,
    string Lastname,
    string Email,
    string Token
);