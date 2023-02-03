namespace Gursha.Contracts.Authentication;
public record AuthenticationResponse(
Guid ID,
string Firstname,
string Lastname,
string Email,
string Token);