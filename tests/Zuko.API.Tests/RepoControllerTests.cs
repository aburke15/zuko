using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Zuko.API.Controllers;

namespace Zuko.API.Tests;

[TestFixture]
public class RepoControllerTests
{
    private Mock<IConfiguration> _configuration;

    [SetUp]
    public void SetUp()
    {
        _configuration = new Mock<IConfiguration>();
    }

    [Test]
    public async Task GetRepos_WhenCalled_ReturnsOkResult()
    {
        var controller = new RepoController(_configuration.Object);

        var result = await controller.GetRepos();

        Assert.That(result, Is.TypeOf<OkObjectResult>());
    }
}