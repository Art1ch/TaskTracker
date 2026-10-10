using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Models;
using TaskTrackerDesktop.Core.Responses.Auth;

namespace TaskTrackerDesktop.Core.Interfaces;

public interface IAuthService
{
    public bool IsAuthenticated { get; }
    public UserModel? CurrentUser { get; }
    Task<RegisterResponse> RegisterAsync( 
        string email,
        string firstName,
        string lastName,
        string password,
        CancellationToken cancellationToken = default
    );
    Task<LoginResponse> LoginAsync(string email, string password, CancellationToken cancellationToken = default);
    Task<bool> RefreshAsync(CancellationToken cancellationToken = default);
    Task<bool> LogoutAsync(CancellationToken cancellationToken = default);
}
