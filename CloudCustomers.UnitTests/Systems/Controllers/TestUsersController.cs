using CloudCustomers.Api.Controllers;
using CloudCustomers.Services;
using CloudCustomers.Services.Models;
using CloudCustomers.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task Get_Success_ReturnStatusCode200()
    {
        // Arange
        var mockUserService = new Mock<IUsersService>();

        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UsersFixture.GetTestUsers());

        var controller = new UsersController(mockUserService.Object);

        // Act
        var result = (OkObjectResult)await controller.Get();

        // Asert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_InvokeUserService()
    {
        // Arange
        var mockUserService = new Mock<IUsersService>();

        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var controller = new UsersController(mockUserService.Object);

        // Act
        var result = await controller.Get();

        // Asert
        mockUserService.Verify(
            service => service.GetAllUsers(),
            Times.Once());
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfUSers()
    {
        // Arange
        var mockUserService = new Mock<IUsersService>();

        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UsersFixture.GetTestUsers());

        var controller = new UsersController(mockUserService.Object);

        // Act
        var result = await controller.Get();

        // Asert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();
    }

    [Fact]
    public async Task Get_OnNoUsersFound_Returns404()
    {
        // Arange
        var mockUserService = new Mock<IUsersService>();

        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var controller = new UsersController(mockUserService.Object);

        // Act
        var result = await controller.Get();

        // Asert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }
}