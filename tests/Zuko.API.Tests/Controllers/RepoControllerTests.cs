using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Zuko.API.Controllers;
using Zuko.Data;
using Zuko.Services.External.API;

namespace Zuko.API.Tests.Controllers;

[TestFixture]
public class RepoControllerTests
{
    private Mock<IConfiguration> _configuration;
    private Mock<ApplicationContext> _context;
    private Mock<IGitHubClient> _gitHubClient;

    [SetUp]
    public void SetUp()
    {
        _configuration = new Mock<IConfiguration>();
        _context = new Mock<ApplicationContext>();
        _gitHubClient = new Mock<IGitHubClient>();
    }

    [Test]
    public async Task GetRepos_WhenCalled_ReturnsOkResult()
    {
        var controller = new RepoController(
            _configuration.Object,
            _context.Object,
            _gitHubClient.Object);

        var result = await controller.GetRepos();

        Assert.That(result, Is.TypeOf<OkObjectResult>());
    }
}