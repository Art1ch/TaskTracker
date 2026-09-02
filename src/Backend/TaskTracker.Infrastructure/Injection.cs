using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Application.Abstractions.Services;
using TaskTracker.Core.Entities;
using TaskTracker.Infrastructure.Context;
using TaskTracker.Infrastructure.Helpers;
using TaskTracker.Infrastructure.Implementations.Repositories;
using TaskTracker.Infrastructure.Implementations.Services;
using TaskTracker.Infrastructure.Settings;

namespace TaskTracker.Infrastructure;

public static class Injection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, ApplicationDbSettings settings)
    {
        return services
            .AddHelpers()
            .AddApplicationDbContext(settings)
            .AddIdentity()
            .AddRepositories()
            .AddServices();
    }

    private static IServiceCollection AddHelpers(this IServiceCollection services) =>
        services.AddTransient<JwtTokenGeneratorHelper>();

    private static IServiceCollection AddApplicationDbContext(this IServiceCollection services, ApplicationDbSettings settings) =>
        services.AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(settings.ConnectionString));

    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<UserEntity, IdentityRole<Guid>>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = true;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IRemarkRepository, RemarkRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProcessRepository, ProcessRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services) =>
        services.AddScoped<IAuthService, IdentityAuthService>();
}
