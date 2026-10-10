using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.Responses.Process;

namespace TaskTrackerDesktop.Infrastructure.Implementations;

internal sealed class HttpProcessService : IProcessService
{
    private readonly HttpClient _httpClient;

    public HttpProcessService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetProcessResponse> GetProcessAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var processResponse = await _httpClient.GetAsync($"api/processes?id={id}", cancellationToken);
        var processResult = await processResponse.Content.ReadFromJsonAsync<GetProcessResponse>(cancellationToken);

        return processResult;
    }

    public async Task<GetProcessEntitiesResponse> GetProcessesAsync(ProcessFilterForm filter, CancellationToken cancellationToken = default)
    {
        var basePath = "api/processes/entities";

        var queryParams = new Dictionary<string, string?>
        {
            ["page"] = filter.Page.ToString(),
            ["pageSize"] = filter.PageSize.ToString(),
            ["from"] = filter.From?.ToString("O"),
            ["to"] = filter.To?.ToString("O"),
            ["name"] = filter.Name,
            ["description"] = filter.Description,
            ["isActive"] = filter.IsActive?.ToString().ToLowerInvariant()
        };

        var filteredQueryParams = queryParams
            .Where(x => x.Value is not null)
            .ToDictionary(x => x.Key, x => x.Value!);

        string urlWithQuery = QueryHelpers.AddQueryString(basePath, filteredQueryParams);

        var getProcessEntitiesResponse = await _httpClient.GetAsync(urlWithQuery, cancellationToken);
        var getProcessEntitiesResult = await getProcessEntitiesResponse.Content.ReadFromJsonAsync<GetProcessEntitiesResponse>(cancellationToken);

        return getProcessEntitiesResult;
    }
}