using System.Runtime;
using TaskTracker.Infrastructure.Settings;

namespace TaskTracker.Api.Extensions;

internal static class WebApplicationBuilderExtensions
{
    internal static JwtSettings ConfigureJwtSettings(this WebApplicationBuilder builder) =>
        builder.ConfigureSettings<JwtSettings>();

    internal static ApplicationDbSettings ConfigureApplicationDbSettings(this WebApplicationBuilder builder) =>
        builder.ConfigureSettings<ApplicationDbSettings>();

    private static T ConfigureSettings<T>(this WebApplicationBuilder builder) where T : class
    {
        var sectionName = typeof(T).Name;
        var settings = builder.Configuration.GetSection(sectionName).Get<T>()!;
        builder.Services.Configure<T>(builder.Configuration.GetSection(sectionName));
        return settings;
    }
}
