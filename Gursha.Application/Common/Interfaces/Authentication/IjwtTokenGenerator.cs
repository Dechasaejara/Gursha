namespace Gursha.Application.Common.Interfaces.Authentication;
public interface IjwtTokenGenerator
{
    string GenerateToken(Guid userID, string firstname, string lastname);
}