using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Responses;

namespace TaskTrackerDesktop.Core.Interfaces;

public interface IAuthService
{
    Task<RegisterResponse> RegisterAsync(
        string email,
        string firstName,
        string lastName,
        string password,
        CancellationToken cancellationToken = default
    );
    Task<LoginResponse> LoginAsync(string email, string password, CancellationToken cancellationToken = default);
}
