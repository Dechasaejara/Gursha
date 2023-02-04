namespace Gursha.Infrastructure.Authentication;
public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string? Issuer { get; init; }
    public string? secret { get; init; }
    public int ExpiryMinuts { get; init; }
    public string? Audience { get; init; }

}