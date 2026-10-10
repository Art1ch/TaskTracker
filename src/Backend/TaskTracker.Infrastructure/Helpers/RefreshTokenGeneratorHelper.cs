using System.Security.Cryptography;

namespace TaskTracker.Infrastructure.Helpers;

internal sealed class RefreshTokenGeneratorHelper
{
    public string GenerateRefreshToken()
    {
        var randomBytes = RandomNumberGenerator.GetBytes(64);

        return Convert.ToBase64String(randomBytes);
    }
}
