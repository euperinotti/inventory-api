using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Domain.Entities;
using Api.Domain.Security;
using Microsoft.IdentityModel.Tokens;

namespace Api.Infra.Security.Jwt;

public class JwtAuthenticator : IJWTAuth
{
    public string GenerateToken(UserBO user)
    {
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"));
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        TokenPayloadBO tokenPayload = TokenPayloadBO.Of(user);

        JwtSecurityToken token = new JwtSecurityToken(
            claims: ToClaims(tokenPayload),
            issuer: "issuer",
            audience: "audience",
            expires: tokenPayload.ExpiresAt,
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private List<Claim> ToClaims(TokenPayloadBO payload)
    {
        List<Claim> claims = new List<Claim>();

        claims.Add(new Claim(nameof(payload.Email), payload.Email));
        claims.Add(new Claim(nameof(payload.CreatedAt), payload.CreatedAt.ToString(CultureInfo.InvariantCulture)));
        claims.Add(new Claim(nameof(payload.LastLoginAt), payload.LastLoginAt.ToString(CultureInfo.InvariantCulture)));
        claims.Add(new Claim(nameof(payload.Attempts), payload.Attempts.ToString()));

        return claims;
    }
}
