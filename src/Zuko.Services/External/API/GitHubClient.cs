using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Zuko.Shared.Contracts;
using Zuko.Shared.Routes;

namespace Zuko.Services.External.API;

public interface IGitHubClient
{
    Task<List<RepoResponse>> GetReposForUser(string username, int? pageSize = 50);
}

public class GitHubClient(HttpClient httpClient) : IGitHubClient
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<List<RepoResponse>> GetReposForUser(string username, int? pageSize = 50)
    {
        var route = GitHubRoutes.GetPublicRepos(username, pageSize);

        var response = await _httpClient.GetAsync(route);
        var responseJson = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new InvalidOperationException(responseJson);

        var repos = JsonConvert.DeserializeObject<List<RepoResponse>>(responseJson);

        return repos;
    }
}
