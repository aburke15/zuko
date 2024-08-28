using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Zuko.Data;
using Zuko.Services.External.API;
using Zuko.Shared.Contracts;

namespace Zuko.API.Controllers;

[Route("api/repos")]
[ApiController]
public class RepoController(IConfiguration configuration, ApplicationContext context, IGitHubClient gitHubClient) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration;
    private readonly ApplicationContext _context = context;
    private readonly IGitHubClient _gitHubClient = gitHubClient;

    [HttpGet]
    public async Task<IActionResult> GetRepos()
    {
        try
        {
            var repos = await _context.Repos.ToListAsync();

            return Ok(repos);
        }
        catch (Exception ex)
        {
            return BadRequest(new FailureResponse
            {
                Message = ex.Message,
            });
        }
    }
    
    [HttpGet, Route("github")]
    public async Task<IActionResult> GetReposFromGitHub()
    {
        var repos = await _gitHubClient.GetReposForUser("aburke15", 100);

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
}

