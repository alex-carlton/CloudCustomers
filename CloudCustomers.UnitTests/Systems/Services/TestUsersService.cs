using CloudCustomers.Services;
using CloudCustomers.Services.Models;
using CloudCustomers.UnitTests.Fixtures;
using CloudCustomers.UnitTests.Helpers;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Xunit;

namespace CloudCustomers.UnitTests.Systems.Services
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
        {
            // Arange
            var expectedResponse = UsersFixture.GetTestUsers();

            var handlerMock = MockHttpMessageHandler<User>
                .SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);

            var service = new UsersService(httpClient);

            // Act
            await service.GetAllUsers();

            // Assert
            handlerMock
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Exactly(1),
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                    ItExpr.IsAny<CancellationToken>()
                );
        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsListOfUsers()
        {
            // Arange
            var expectedResponse = UsersFixture.GetTestUsers();

            var handlerMock = MockHttpMessageHandler<User>
                .SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);

            var service = new UsersService(httpClient);

            // Act
            List<User> result = await service.GetAllUsers();

            // Assert
            result.Should().BeOfType<List<User>>();
        }

        [Fact]
        public async Task GetAllUsers_WhenHits404_ReturnsEmptyListOfUsers()
        {
            // Arange
            var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();
            var httpClient = new HttpClient(handlerMock.Object);

            var service = new UsersService(httpClient);

            // Act
            List<User> result = await service.GetAllUsers();

            // Assert
            result.Count.Should().Be(0);
        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsListOfUsersOfExpectedSize()
        {
            // Arange
            var expectedResponse = UsersFixture.GetTestUsers();

            var handlerMock = MockHttpMessageHandler<User>
                .SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);

            var service = new UsersService(httpClient);

            // Act
            List<User> result = await service.GetAllUsers();

            // Assert
            result.Count.Should().Be(expectedResponse.Count);
        }
    }
}