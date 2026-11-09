namespace Club.Api.Infrastructure.JwtUtil;

public class JwtConfig
{
    public const string SectionName = "JwtConfig";
    public string SignInKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int ExpirationMinutes { get; set; } = 60;
}