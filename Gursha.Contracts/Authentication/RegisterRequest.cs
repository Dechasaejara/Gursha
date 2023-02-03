namespace Gursha.Contracts.Authentication;
// 
public record RegisterRequest(
Guid ID,
string Firstname,
string Lastname,
string Email,
string Password
);