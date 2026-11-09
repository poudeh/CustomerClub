using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Club.Api.Infrastructure.JwtUtil;

public static class JwtAuthentication
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfig = configuration
            .GetSection(JwtConfig.SectionName)
            .Get<JwtConfig>();

        if (jwtConfig is null)
            throw new InvalidOperationException("JwtConfig is not configured.");

        if (string.IsNullOrWhiteSpace(jwtConfig.SignInKey) ||
            Encoding.UTF8.GetByteCount(jwtConfig.SignInKey) < 32)
        {
            throw new InvalidOperationException(
                "JWT signing key must be at least 32 bytes.");
        }

        if (string.IsNullOrWhiteSpace(jwtConfig.Issuer) ||
            string.IsNullOrWhiteSpace(jwtConfig.Audience))
        {
            throw new InvalidOperationException(
                "JWT Issuer and Audience must be configured.");
        }

        services.Configure<JwtConfig>(
            configuration.GetSection(JwtConfig.SectionName));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme =
                JwtBearerDefaults.AuthenticationScheme;

            options.DefaultChallengeScheme =
                JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtConfig.SignInKey)),

                ValidateIssuer = true,
                ValidIssuer = jwtConfig.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtConfig.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(1),
                RequireExpirationTime = true,
                RequireSignedTokens = true
            };

            options.SaveToken = true;

            options.Events = new JwtBearerEvents
            {
                OnTokenValidated = async context =>
                {
                    var customValidate = context.HttpContext
                        .RequestServices
                        .GetRequiredService<CustomJwtValidation>();

                    await customValidate.Validate(context);
                }
            };
        });

        return services;
    }
}