using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using AzureServerlessTemplate.Functions;
using AzureServerlessTemplate.Services;

namespace AzureServerlessTemplate.Tests.FunctionTests
{
    public class HttpTriggerTests
    {
        private readonly Mock<ISampleService> _mockSampleService;
        private readonly Mock<ILogger> _mockLogger;
        private readonly HttpTrigger _httpTrigger;

        public HttpTriggerTests()
        {
            _mockSampleService = new Mock<ISampleService>();
            _mockLogger = new Mock<ILogger>();
            _httpTrigger = new HttpTrigger(_mockSampleService.Object);
        }

        [Fact]
        public async Task Run_WithName_ReturnsOkObjectResult()
        {
            // Arrange
            var name = "TestUser";
            var expectedGreeting = $"Hello, {name}! Welcome to Azure Functions.";
            _mockSampleService.Setup(s => s.GetGreetingAsync(name)).ReturnsAsync(expectedGreeting);

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Query = new QueryCollection(new Dictionary<string, StringValues>
            {
                { "name", name }
            });

            // Act
            var result = await _httpTrigger.Run(httpContext.Request, _mockLogger.Object);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedGreeting, okResult.Value);
        }

        [Fact]
        public async Task Run_WithoutName_ReturnsOkObjectResultWithAnonymous()
        {
            // Arrange
            var expectedGreeting = "Hello, Anonymous! Welcome to Azure Functions.";
            _mockSampleService.Setup(s => s.GetGreetingAsync("Anonymous")).ReturnsAsync(expectedGreeting);

            var httpContext = new DefaultHttpContext();

            // Act
            var result = await _httpTrigger.Run(httpContext.Request, _mockLogger.Object);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedGreeting, okResult.Value);
        }
    }
}
