namespace Zuko.Data.Models;

public class Repo : BaseModel
{
    public int GitHubId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
    public string GitHubCreatedAt { get; set; }
    public string Language { get; set; }
}
