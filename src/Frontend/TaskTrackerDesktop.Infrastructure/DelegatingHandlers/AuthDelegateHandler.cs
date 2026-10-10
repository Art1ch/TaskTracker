using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Infrastructure.Helpers;

namespace TaskTrackerDesktop.Infrastructure.DelegatingHandlers;

internal class AuthDelegatingHandler : DelegatingHandler
{
    private readonly IAuthService _authService;
    private readonly TokenStorageHelper _tokenStorageHelper;

    public AuthDelegatingHandler(IAuthService authService, TokenStorageHelper tokenStorageHelper)
    {
        _authService = authService;
        _tokenStorageHelper = tokenStorageHelper;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        AddAccessTokenToHeader(request);

        var response = await base.SendAsync(request, cancellationToken);

        if (!(response.StatusCode == HttpStatusCode.Unauthorized))
            return response;

        var isRefreshed = await _authService.RefreshAsync(cancellationToken);

        if (!isRefreshed)
            return response;

        AddAccessTokenToHeader(request);

        var refreshedResponse = await base.SendAsync(request, cancellationToken);

        return refreshedResponse;
            

    }

    private void AddAccessTokenToHeader(HttpRequestMessage request)
    {
        var accessToken = _tokenStorageHelper.AccessToken;
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }
}
