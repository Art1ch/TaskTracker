using TaskTracker.Api.Extensions;
using TaskTracker.Api.Middlewares;
using TaskTracker.Application;
using TaskTracker.Infrastructure;

namespace TaskTracker.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var jwtSettings = builder.ConfigureJwtSettings();
        var applicationDbSettings = builder.ConfigureApplicationDbSettings();

        builder.Services.AddJwtAuthentication(jwtSettings);

        builder.Services
            .AddApplicationLayer()
            .AddInfrastructureLayer(applicationDbSettings);

        builder.Services.AddApiLocalization();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseRequestLocalization();
        app.UseMiddleware<GlobalExceptionMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
