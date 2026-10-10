using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.Models;
using TaskTrackerDesktop.Core.Responses.Auth;
using TaskTrackerDesktop.Core.Responses.User;
using TaskTrackerDesktop.Infrastructure.Helpers;

namespace TaskTrackerDesktop.Infrastructure.Implementations;

internal sealed class HttpAuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly TokenStorageHelper _tokenStorage;

    public bool IsAuthenticated => _tokenStorage.HasTokens;

    public UserModel CurrentUser => _tokenStorage.CurrentUser;

    public HttpAuthService(HttpClient httpClient, TokenStorageHelper tokenStorage)
    {
        _httpClient = httpClient;
        _tokenStorage = tokenStorage;
    }

    public async Task<LoginResponse> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", new { Email = email, Password = password }, cancellationToken);

        var loginResult = await response.Content.ReadFromJsonAsync<LoginResponse>(cancellationToken);

        if (!loginResult.IsSucceed)
            return loginResult;

        _tokenStorage.SaveTokens(loginResult.AccessToken, loginResult.RefreshToken);

        try
        {
            var user = await GetCurrentUserAsync(loginResult.AccessToken, cancellationToken);
            _tokenStorage.SaveUser(user);
        }
        catch
        {
            _tokenStorage.Clear();
            throw;
        }

        return loginResult;
    }

    public async Task<bool> RefreshAsync(CancellationToken cancellationToken = default)
    {
        var refreshToken = _tokenStorage.RefreshToken;

        if (string.IsNullOrEmpty(refreshToken))
        {
            _tokenStorage.Clear();
            return false;
        }

        HttpResponseMessage response;

        try
        {
            response = await _httpClient.PostAsJsonAsync("api/auth/refresh", new { RefreshToken = refreshToken }, cancellationToken);
        }
        catch (HttpRequestException)
        {
            return false;
        }

        if (response.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
        {
            _tokenStorage.Clear();
            return false;
        }

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        var refreshResult = await response.Content.ReadFromJsonAsync<RefreshResponse>(cancellationToken);

        if (!refreshResult.IsSucceed)
        {
            return false;
        }

        var newRefreshToken = refreshResult.RefreshToken;

        _tokenStorage.SaveTokens(refreshResult.AccessToken, newRefreshToken);

        return true;
    }

    public async Task<bool> LogoutAsync(CancellationToken cancellationToken = default)
    {
        var refreshToken = _tokenStorage.RefreshToken;

        try
        {
            if (!string.IsNullOrEmpty(refreshToken))
            {
                await _httpClient.PostAsJsonAsync(
                    "api/auth/logout",
                    new { RefreshToken = refreshToken },
                    cancellationToken);
            }
        }
        catch
        {

        }
        finally
        {
            _tokenStorage.Clear();
        }

        return true;
    }

    public async Task<RegisterResponse> RegisterAsync(
        string email,
        string firstName,
        string lastName,
        string password,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/auth/register",
            new
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = password
            },
            cancellationToken);

        var registerResult = await response.Content.ReadFromJsonAsync<RegisterResponse>(cancellationToken);

        return registerResult;
    }

    private async Task<UserModel> GetCurrentUserAsync(string accessToken, CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/users/me");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        using var response = await _httpClient.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException();

        var userResponse = await response.Content.ReadFromJsonAsync<GetUserResponse>(cancellationToken);

        return new UserModel
        {
            Id = userResponse.Id,
            FirstName = userResponse.FirstName,
            LastName = userResponse.LastName,
            UserRole = userResponse.UserRole
        };
    }
}
