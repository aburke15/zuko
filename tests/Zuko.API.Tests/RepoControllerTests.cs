using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Zuko.API.Controllers;
using Zuko.Data;

namespace Zuko.API.Tests;

[TestFixture]
public class RepoControllerTests
{
    private Mock<IConfiguration> _configuration;
    private Mock<ApplicationContext> _context;

    [SetUp]
    public void SetUp()
    {
        _configuration = new Mock<IConfiguration>();
        _context = new Mock<ApplicationContext>();
    }

    [Test]
    public async Task GetRepos_WhenCalled_ReturnsOkResult()
    {
        var controller = new RepoController(_configuration.Object, _context.Object);

        var result = await controller.GetRepos();

        Assert.That(result, Is.TypeOf<OkObjectResult>());
    }
}