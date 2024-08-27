using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Zuko.API.Controllers;

[Route("api/repos")]
[ApiController]
public class RepoController(IConfiguration configuration) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration;

    [HttpGet]
    public async Task<IActionResult> GetRepos()
    {
        List<RepoResponse> repos =
        [
            new () { Id = 1, Name = "Iroh" },
            new () { Id = 2, Name = "Zuko" },
            new () { Id = 3, Name = "test-ninja" },
            new () { Id = 4, Name = "backend" },
        ];

        await Task.Delay(100);

        return Ok(repos);
    }

    [HttpGet, Route("settings")]
    public async Task<IActionResult> GetSettings()
    {
        var setting = _configuration.GetSection("Setting");

        await Task.Delay(100);

        return Ok(setting.Value);
    }

    public record RepoResponse
    {
        [JsonProperty("id")]
        public int Id { get; init; }
        [JsonProperty("name")]
        public string Name { get; init; }
        [JsonProperty("description")]
        public string Description { get; init; }
        [JsonProperty("html_url")]
        public string Link { get; init; }
        [JsonProperty("created_at")]
        public string CreatedAt { get; init; }
        [JsonProperty("language")]
        public string Language { get; init; }
        [JsonProperty("private")]
        public bool Private { get; init; }
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; init; }
    }
}

