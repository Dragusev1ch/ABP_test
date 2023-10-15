using ABP_test.Dto;
using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Model;
using ABP_test.Repositories;
using ABP_test.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

[TestFixture]
public class TokenServiceTests
{
    
    [Test]
    public void Dispose_DisposesUnitOfWork()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var tokenService = new TokenService(mockUnitOfWork.Object);

        // Act
        tokenService.Dispose();

        // Assert
        mockUnitOfWork.Verify(u => u.Dispose(), Times.Once);
    }
}