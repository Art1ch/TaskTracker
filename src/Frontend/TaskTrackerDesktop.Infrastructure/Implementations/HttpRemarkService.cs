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
using TaskTrackerDesktop.Core.Responses.Remark;

namespace TaskTrackerDesktop.Infrastructure.Implementations;

internal sealed class HttpRemarkService : IRemarkService
{
    private readonly HttpClient _httpClient;

    public HttpRemarkService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetRemarkResponse> GetRemarkAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var remarkResponse = await _httpClient.GetAsync($"api/remarks?id={id}", cancellationToken);
        var remarkResult = await remarkResponse.Content.ReadFromJsonAsync<GetRemarkResponse>(cancellationToken);

        return remarkResult;
    }

    public async Task<GetRemarkEntitiesResponse> GetRemarksAsync(RemarkFilterForm filter, CancellationToken cancellationToken = default)
    {
        var basePath = "api/remarks/entities";

        var queryParams = new Dictionary<string, string?>
        {
            ["page"] = filter.Page.ToString(),
            ["pageSize"] = filter.PageSize.ToString(),
            ["from"] = filter.From?.ToString("O"),
            ["to"] = filter.To?.ToString("O"),
            ["taskId"] = filter.TaskId?.ToString(),
            ["text"] = filter.Text
        };

        var filteredQueryParams = queryParams
            .Where(x => x.Value is not null)
            .ToDictionary(x => x.Key, x => x.Value!);

        string urlWithQuery = QueryHelpers.AddQueryString(basePath, filteredQueryParams);

        var getRemarkEntitiesResponse = await _httpClient.GetAsync(urlWithQuery, cancellationToken);
        var getRemarkEntitiesResult = await getRemarkEntitiesResponse.Content.ReadFromJsonAsync<GetRemarkEntitiesResponse>(cancellationToken);

        return getRemarkEntitiesResult;
    }
}
