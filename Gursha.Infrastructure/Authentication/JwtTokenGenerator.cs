// This Authentication Infrastructure Impliments the IjwtTokenGenerator in Application/common/interface
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Gursha.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace Gursha.Infrastructure.Authentication;

public class JwtTokenGenerator : IjwtTokenGenerator
{
    // 
    private readonly JwtSettings _jwtSettings;
    // 
    public JwtTokenGenerator(IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }
    // 
    public string GenerateToken(Guid userID, string firstname, string lastname)
    {
        // Define Credentials
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.secret)), SecurityAlgorithms.HmacSha256);

        // Define Claims
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,  userID.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstname),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastname),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Define Token
        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinuts),
            claims: claims,
            signingCredentials: signingCredentials
        );
        // Return the new Token
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}