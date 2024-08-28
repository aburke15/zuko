namespace Zuko.Shared.Routes;
public static class GitHubRoutes
{
    public static string GetPublicRepos(string username, int? pageSize = null)
    {
        if (pageSize == null)
            return $"users/{username}/repos";

        return $"users/{username}/repos?per_page={pageSize}";
    }
}
