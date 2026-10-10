using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Enums;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.Models;
using TaskTrackerDesktop.Core.Responses.Task;
using TaskTrackerDesktop.Core.Responses.User;

namespace TaskTrackerDesktop.Infrastructure.Implementations;

internal sealed class HttpUserService : IUserService
{
    private readonly HttpClient _httpClient;

    public HttpUserService(HttpClient httpClient) 
    {
        _httpClient = httpClient;
    }

    public async Task<GetUserResponse> GetUserAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var userResponse = await _httpClient.GetAsync($"api/users?id={id}", cancellationToken);
        var userResult = await userResponse.Content.ReadFromJsonAsync<GetUserResponse>(cancellationToken);

        return userResult;
    }

    public async Task<GetUserEntitiesResponse> GetUsersAsync(UserFilterForm filter, CancellationToken cancellationToken = default)
    {
        var basePath = "api/users/entities";

        var queryParams = new Dictionary<string, string?>
        {
            ["page"] = filter.Page.ToString(),
            ["pageSize"] = filter.PageSize.ToString(),
            ["from"] = filter.From?.ToString("O"),
            ["to"] = filter.To?.ToString("O"),
            ["firstName"] = filter.FirstName,
            ["lastName"] = filter.LastName,
            ["userRole"] = filter.UserRole?.ToString()
        };

        var filteredQueryParams = queryParams
            .Where(x => x.Value is not null)
            .ToDictionary(x => x.Key, x => x.Value!);

        string urlWithQuery = QueryHelpers.AddQueryString(basePath, filteredQueryParams);

        var getUserEntitiesResponse = await _httpClient.GetAsync(urlWithQuery, cancellationToken);
        var getUserEntitiesResult = await getUserEntitiesResponse.Content.ReadFromJsonAsync<GetUserEntitiesResponse>(cancellationToken);

        return getUserEntitiesResult;
    }
}
