using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Zuko.Services.External.API;

namespace Zuko.Services
{
    public static class ServicesRegistrar
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IGitHubClient, GitHubClient>(client =>
            {
                string gitHubPAT = configuration.GetSection("GitHubToken").Value;

                client.BaseAddress = new Uri("https://api.github.com/");
                client.DefaultRequestHeaders.Add("User-Agent", "zuko-api");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + gitHubPAT);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        }
    }
}
