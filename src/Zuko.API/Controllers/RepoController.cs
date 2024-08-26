using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Zuko.API.Controllers
{
    [Route("api/repos")]
    [ApiController]
    public class RepoController : ControllerBase
    {
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

        public class RepoResponse
        {
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("description")]
            public string Description { get; set; }
            [JsonProperty("html_url")]
            public string Link { get; set; } 
            [JsonProperty("created_at")]
            public string CreatedAt { get; set; } 
            [JsonProperty("language")]
            public string Language { get; set; } 
            [JsonProperty("private")]
            public bool Private { get; set; }
            [JsonProperty("updated_at")]
            public string UpdatedAt { get; set; } 
        }
    }
}
