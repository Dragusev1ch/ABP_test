using ABP_test.Controllers;
using ABP_test.Dto;
using ABP_test.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace APB_test.NUnitTest.Controllers;

[TestFixture]
public class TokenControllerTests
{
    private TokenController _controller;
    private Mock<ITokenService> _tokenServiceMock;

    [SetUp]
    public void Setup()
    {
        _tokenServiceMock = new Mock<ITokenService>();
        _controller = new TokenController(_tokenServiceMock.Object);
    }

    [Test]
    public void CreateToken_ValidToken_ReturnsOkResult()
    {
        // Arrange
        var tokenDto = new CreateTokenDto { /* Initialize token data */ };

        // Act
        var result = _controller.CreateToken(tokenDto) as OkResult;

        // Assert
        Assert.IsNotNull(result);
    }

    [Test]
    public void CreateToken_NullToken_ThrowsException()
    {
        // Arrange
        CreateTokenDto tokenDto = null;

        // Act and Assert
        Assert.Throws<Exception>(() => _controller.CreateToken(tokenDto));
    }
}