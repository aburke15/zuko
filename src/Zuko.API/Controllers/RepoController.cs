using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Zuko.Data;

namespace Zuko.API.Controllers;

[Route("api/repos")]
[ApiController]
public class RepoController(IConfiguration configuration, ApplicationContext context) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration;
    private readonly ApplicationContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetRepos()
    {
        var repos = await _context.Repos.ToListAsync();

        return Ok(repos);
    }

    [HttpGet, Route("private")]
    public async Task<IActionResult> GetPrivateRepos()
    {
        var repos = await _context.Repos.ToListAsync();

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

