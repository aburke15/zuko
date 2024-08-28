using Newtonsoft.Json;

namespace Zuko.Shared.Contracts;

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
