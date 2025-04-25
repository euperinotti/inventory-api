using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Api.Config.Middlewares;

public class AuthenticationMiddleware
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        JwtSettings jwtSettings = LoadJwtSettings(configuration);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret!))
                };
            });
    }

    private JwtSettings LoadJwtSettings(IConfiguration configuration)
    {
        Dictionary<string, string?> jwtSettings =
            configuration.GetSection("Jwt").GetChildren().ToDictionary(key => key.Key, value => value.Value);

        return new JwtSettings(jwtSettings);
    }

    private class JwtSettings(Dictionary<string, string?> jwtSettings)
    {
        public string? Issuer { get; set; } = jwtSettings["Issuer"];
        public string? Audience { get; set; } = jwtSettings["Audience"];
        public string? Secret { get; set; } = jwtSettings["Secret"];
    }
}
