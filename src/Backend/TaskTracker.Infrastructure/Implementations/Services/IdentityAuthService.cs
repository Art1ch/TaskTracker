using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaskTracker.Application.Abstractions.Services;
using TaskTracker.Application.Results;
using TaskTracker.Core.Entities;
using TaskTracker.Core.Enums;
using TaskTracker.Infrastructure.Context;
using TaskTracker.Infrastructure.Helpers;
using TaskTracker.Infrastructure.Settings;

namespace TaskTracker.Infrastructure.Implementations.Services;

internal sealed class IdentityAuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<UserEntity> _userManager;
    private readonly JwtTokenGeneratorHelper _jwtTokenGeneratorHelper;
    private readonly RefreshTokenGeneratorHelper _refreshTokenGeneratorHelper;
    private readonly RefreshTokenSettings _refreshTokenSettings;

    public IdentityAuthService(
        UserManager<UserEntity> userManager,
        JwtTokenGeneratorHelper jwtTokenGeneratorHelper,
        RefreshTokenGeneratorHelper refreshTokenGeneratorHelper,
        ApplicationDbContext context,
        IOptions<RefreshTokenSettings> refreshTokenOptions
    )
    {
        _userManager = userManager;
        _jwtTokenGeneratorHelper = jwtTokenGeneratorHelper;
        _refreshTokenGeneratorHelper = refreshTokenGeneratorHelper;
        _context = context;
        _refreshTokenSettings = refreshTokenOptions.Value;
    }

    public async Task<RegisterResult> RegisterAsync(
        string email,
        string firstName,
        string lastName,
        string password,
        CancellationToken cancellationToken = default
    )
    {
        var existingUser = await _userManager.FindByEmailAsync(email);

        if (existingUser != null)
        {
            return new RegisterResult(false, "USER_ALREADY_EXISTS");
        }

        var user = new UserEntity
        {
            UserName = email,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            UserRole = UserRole.User,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null,
            RefreshToken = null,
            RefreshTokenExpiryDate = null
        };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            return new RegisterResult(false, null);
        }

        return new RegisterResult(true, null);
    }

    public async Task<LoginResult> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return new LoginResult(false, null, null, "INVALID_CREDENTIALS");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);

        if (!isPasswordValid)
        {
            return new LoginResult(false, null, null, "INVALID_CREDENTIALS");
        }

        var accessToken = _jwtTokenGeneratorHelper.GenerateJwtToken(user);
        var refreshToken = _refreshTokenGeneratorHelper.GenerateRefreshToken();
        var refreshTokenExpiryDate = DateTime.UtcNow.AddDays(_refreshTokenSettings.ExpiresAtDays);

        _context.Users
            .Where(x => x.Id == user.Id)
            .ExecuteUpdate(x => x
                .SetProperty(x => x.RefreshToken, x => refreshToken)
                .SetProperty(x => x.RefreshTokenExpiryDate, x => refreshTokenExpiryDate)
            );

        return new LoginResult(true, accessToken, refreshToken, null);
    }

    public async Task<RefreshResult> RefreshAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.Where(x => x.RefreshToken == refreshToken).FirstOrDefaultAsync();

        if (user == null)
            return new RefreshResult(false, "INVALID_REFRESH_TOKEN", null, null);

        if (user.RefreshTokenExpiryDate < DateTime.UtcNow)
            return new RefreshResult(false, "REFRESH_TOKEN_EXPIRED", null, null);

        var accessToken = _jwtTokenGeneratorHelper.GenerateJwtToken(user);

        return new RefreshResult(true, null, accessToken, refreshToken);
    }

    public async Task<LogoutResult> LogoutAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.Where(x => x.RefreshToken == refreshToken).FirstOrDefaultAsync();

        if (user == null)
            return new LogoutResult(false);

        _context.Users
            .Where(x => x.Id == user.Id)
            .ExecuteUpdate(x => x
                .SetProperty(x => x.RefreshToken, x => null)
                .SetProperty(x => x.RefreshTokenExpiryDate, x => null)
            );

        return new LogoutResult(true);
    }
}
