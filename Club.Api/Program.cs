using Club.Api.Infrastructure.JwtUtil;
using Club.Config;
using Club.Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.RegisterCustomerDependency(connectionString);
// Configure the HTTP request pipeline.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddScoped<CustomJwtValidation>();

var app = builder.Build();
//For SeedData;
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<ClubContext>();
//    await context.Database.MigrateAsync();
//    await ClubContextSeed.SeedAsync(context);
//}
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.MapGet("/", () => Results.Redirect("/scalar"));
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
