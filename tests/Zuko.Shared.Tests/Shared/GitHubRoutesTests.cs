using NUnit.Framework;
using Zuko.Shared.Routes;

namespace Zuko.Shared.Tests.Shared;

public class GitHubRoutesTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("username", 100)]
    public void GetPublicRepos_WhenCalledWith2Args_ReturnsRouteContainingArgs(string username, int pageSize)
    {
        var result = GitHubRoutes.GetPublicRepos(username, pageSize);

        Assert.That(result, Does.Contain(username));
        Assert.That(result, Does.Contain($"{pageSize}"));
    }
}