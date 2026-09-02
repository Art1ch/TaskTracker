using TaskTracker.Application.Results;

namespace TaskTracker.Application.Abstractions.Services;

public interface IAuthService
{
    Task<RegisterResult> RegisterAsync(
        string email,
        string firstName,
        string lastName,
        string password, 
        CancellationToken cancellationToken = default
    );
    Task<LoginResult> LoginAsync(string email, string password, CancellationToken cancellationToken = default);
}
