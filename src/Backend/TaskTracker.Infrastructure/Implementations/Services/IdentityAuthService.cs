using Microsoft.AspNetCore.Identity;
using TaskTracker.Application.Abstractions.Services;
using TaskTracker.Application.Results;
using TaskTracker.Core.Entities;
using TaskTracker.Core.Enums;
using TaskTracker.Infrastructure.Helpers;

namespace TaskTracker.Infrastructure.Implementations.Services;

internal sealed class IdentityAuthService : IAuthService
{
    private readonly JwtTokenGeneratorHelper _jwtTokenGeneratorHelper;
    private readonly UserManager<UserEntity> _userManager;

    public IdentityAuthService(
        UserManager<UserEntity> userManager,
        JwtTokenGeneratorHelper jwtTokenGeneratorHelper
    )
    {
        _userManager = userManager;
        _jwtTokenGeneratorHelper = jwtTokenGeneratorHelper;
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
            return new LoginResult(false, null, "INVALID_CREDENTIALS", null, null);
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);

        if (!isPasswordValid)
        {
            return new LoginResult(false, null, "INVALID_CREDENTIALS", null, null);
        }

        var token = _jwtTokenGeneratorHelper.GenerateJwtToken(user);

        return new LoginResult(true, token, null, user.Email, user.UserRole);
    }
}
