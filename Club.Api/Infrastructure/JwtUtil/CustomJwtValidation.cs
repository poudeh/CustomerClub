using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace Club.Api.Infrastructure.JwtUtil;

public class CustomJwtValidation
{
    public async Task Validate(TokenValidatedContext context)
    {
        var userId = context.Principal?
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(userId))
        {
            context.Fail("User identifier not found.");
            return;
        }

        // بررسی فعال بودن کاربر در دیتابیس
        // بررسی اعتبار نشست یا وضعیت حساب کاربری

        await Task.CompletedTask;
    }
}