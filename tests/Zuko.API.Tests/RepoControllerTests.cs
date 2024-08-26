using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Threading.Tasks;
using Zuko.API.Controllers;

namespace Zuko.API.Tests;

[TestFixture]
public class RepoControllerTests
{
    [Test]
    public async Task GetRepos_WhenCalled_ReturnsActionResult()
    {
        var controller = new RepoController();

        var result = await controller.GetRepos();

        Assert.That(result, Is.InstanceOf<IActionResult>());
    }
}