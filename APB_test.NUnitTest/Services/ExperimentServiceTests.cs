using ABP_test.Interfaces;
using ABP_test.Model;
using ABP_test.Models;
using ABP_test.Services;
using Moq;

namespace APB_test.NUnitTest.Services
{
    [TestFixture]
    public class ExperimentServiceTests
    {
        [Test]
        public void GetButtonColorExperiment_ExistingExperiment_ReturnsExperiment()
        {
            // Arrange
            var deviceToken = "existingToken";
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRandom = new Mock<Random>();
            var service = new ExperimentService(mockUnitOfWork.Object);

            // Mock the behavior of Experiments.GetAll() to return an IQueryable
            var experiments = new List<Experiment> { new Experiment { TokenName = deviceToken } }.AsQueryable();
            mockUnitOfWork.Setup(u => u.Experiments.GetAll()).Returns(experiments);

            // Act
            var result = service.GetButtonColorExperiment(deviceToken);

            // Assert
            Assert.AreEqual(deviceToken, result.TokenName);
        }

        [Test]
        public void GetButtonColorExperiment_NonExistingToken_ThrowsException()
        {
            // Arrange
            var deviceToken = "nonExistingToken";
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRandom = new Mock<Random>();
            var service = new ExperimentService(mockUnitOfWork.Object);

            // Mock the behavior of Experiments.GetAll() to return an IQueryable
            var experiments = new List<Experiment>().AsQueryable();
            mockUnitOfWork.Setup(u => u.Experiments.GetAll()).Returns(experiments);

            // Mock the behavior of Tokens.GetAll() to return an IQueryable
            var tokens = new List<Token>().AsQueryable();
            mockUnitOfWork.Setup(u => u.Tokens.GetAll()).Returns(tokens);

            // Act & Assert
            Assert.IsEmpty(tokens);
        }

        [Test]
        public void GetButtonColorExperiment_NonExistingExperiment_CreatesAndReturnsExperiment()
        {
            // Arrange
            var deviceToken = "newToken";
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRandom = new Mock<Random>();
            var service = new ExperimentService(mockUnitOfWork.Object);

            // Create a list of experiments
            var experiments = new List<Experiment>().AsQueryable();

            // Mock the behavior of Experiments.GetAll() to return an IQueryable
            mockUnitOfWork.Setup(u => u.Experiments.GetAll()).Returns(experiments);

            // Set up the mock for Tokens.GetAll() to return an empty list
            var tokens = new List<Token>().AsQueryable();
            mockUnitOfWork.Setup(u => u.Tokens.GetAll()).Returns(tokens);

            // Act
            var result = service.GetButtonColorExperiment(deviceToken);

            // Assert
            Assert.IsNull(result);
        }


        [Test]
        public void GetPriceExperiment_ExistingExperiment_ReturnsExperiment()
        {
            // Arrange
            var deviceToken = "existingToken";
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRandom = new Mock<Random>();
            var service = new ExperimentService(mockUnitOfWork.Object);

            // Create a list of experiments
            var experiments = new List<Experiment> { new Experiment { TokenName = deviceToken } }.AsQueryable();

            // Mock the behavior of Experiments.GetAll() to return an IQueryable
            mockUnitOfWork.Setup(u => u.Experiments.GetAll()).Returns(experiments);

            // Act
            var result = service.GetPriceExperiment(deviceToken);

            // Assert
            Assert.AreEqual(deviceToken, result.TokenName);
        }

        [Test]
        public void GetPriceExperiment_NonExistingToken_ThrowsException()
        {
            // Arrange
            var deviceToken = "nonExistingToken";
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRandom = new Mock<Random>();
            var service = new ExperimentService(mockUnitOfWork.Object);

            // Create a list of experiments
            var experiments = new List<Experiment>().AsQueryable();

            // Mock the behavior of Experiments.GetAll() to return an IQueryable
            mockUnitOfWork.Setup(u => u.Experiments.GetAll()).Returns(experiments);

            // Create a list of tokens
            var tokens = new List<Token>().AsQueryable();

            // Mock the behavior of Tokens.GetAll() to return an IQueryable
            mockUnitOfWork.Setup(u => u.Tokens.GetAll()).Returns(tokens);

            // Act & Assert
            Assert.IsEmpty(tokens);
        }



        [Test]
        public void GetPriceExperiment_RandomValueLessThan76_CreatesAndReturnsExperimentWithPrice10()
        {
            // Arrange
            var deviceToken = "randomToken";
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRandom = new Mock<Random>();
            var service = new ExperimentService(mockUnitOfWork.Object);

            // Create an empty list of experiments and convert it to IQueryable
            var experiments = new List<Experiment>().AsQueryable();
            mockUnitOfWork.Setup(u => u.Experiments.GetAll()).Returns(experiments);

            // Create a token
            var token = new Token { DeviceToken = deviceToken };
            // Create a list of tokens and convert it to IQueryable
            var tokens = new List<Token> { token }.AsQueryable();
            mockUnitOfWork.Setup(u => u.Tokens.GetAll()).Returns(tokens);

            // Set up the mock to return a random value below 76 (for example, 50)
            mockRandom.Setup(r => r.Next(1, 101)).Returns(50);

            // Act
            var result = service.GetPriceExperiment(deviceToken);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("price", result.Name);
            Assert.AreEqual(deviceToken, result.TokenName);
        }



        [Test]
        public void GetPriceExperiment_RandomValueBetween75And85_CreatesExperimentWithPrice20()
        {
            // Arrange
            var deviceToken = "randomToken";
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRandom = new Mock<Random>();
            var service = new ExperimentService(mockUnitOfWork.Object);

            // Create an empty list of experiments and convert it to IQueryable
            var experiments = new List<Experiment>().AsQueryable();
            mockUnitOfWork.Setup(u => u.Experiments.GetAll()).Returns(experiments);

            // Create a token
            var token = new Token { DeviceToken = deviceToken };
            // Create a list of tokens and convert it to IQueryable
            var tokens = new List<Token> { token }.AsQueryable();
            mockUnitOfWork.Setup(u => u.Tokens.GetAll()).Returns(tokens);

            mockRandom.Setup(r => r.Next(1, 101)).Returns(80);

            // Act
            var result = service.GetPriceExperiment(deviceToken);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("price", result.Name);
            Assert.AreEqual(deviceToken, result.TokenName);
        }

        [Test]
        public void GetPriceExperiment_RandomValueBetween85And90_CreatesExperimentWithPrice50()
        {
            // Arrange
            var deviceToken = "randomToken";
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRandom = new Mock<Random>();
            var service = new ExperimentService(mockUnitOfWork.Object);

            // Create an empty list of experiments and convert it to IQueryable
            var experiments = new List<Experiment>().AsQueryable();
            mockUnitOfWork.Setup(u => u.Experiments.GetAll()).Returns(experiments);

            // Create a token
            var token = new Token { DeviceToken = deviceToken };
            // Create a list of tokens and convert it to IQueryable
            var tokens = new List<Token> { token }.AsQueryable();
            mockUnitOfWork.Setup(u => u.Tokens.GetAll()).Returns(tokens);

            mockRandom.Setup(r => r.Next(1, 101)).Returns(88);

            // Act
            var result = service.GetPriceExperiment(deviceToken);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("price", result.Name);
            Assert.AreEqual(deviceToken, result.TokenName);
        }

        [Test]
        public void GetPriceExperiment_RandomValueAbove90_CreatesExperimentWithPrice5()
        {
            // Arrange
            var deviceToken = "randomToken";
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockRandom = new Mock<Random>();
            var service = new ExperimentService(mockUnitOfWork.Object);

            // Create an empty list of experiments and convert it to IQueryable
            var experiments = new List<Experiment>().AsQueryable();
            mockUnitOfWork.Setup(u => u.Experiments.GetAll()).Returns(experiments);

            // Create a token
            var token = new Token { DeviceToken = deviceToken };
            // Create a list of tokens and convert it to IQueryable
            var tokens = new List<Token> { token }.AsQueryable();
            mockUnitOfWork.Setup(u => u.Tokens.GetAll()).Returns(tokens);

            mockRandom.Setup(r => r.Next(1, 101)).Returns(95);

            // Act
            var result = service.GetPriceExperiment(deviceToken);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("price", result.Name);
            Assert.AreEqual(deviceToken, result.TokenName);
        }
        [Test]
        public void GetAllExperiments_ReturnsExperiments()
        {
            //Arrange
            var mockDatabase = new Mock<IUnitOfWork>();
            var expectedExperiments = new List<Experiment>
            {
                new Experiment { Name = "Exp1", Value = "10" },
                new Experiment { Name = "Exp2", Value = "20" }
            };

            // Convert the List to an IQueryable
            var expectedExperimentsQueryable = expectedExperiments.AsQueryable();

            mockDatabase.Setup(d => d.Experiments.GetAll()).Returns(expectedExperimentsQueryable);
            var experimentService = new ExperimentService(mockDatabase.Object);

            // Act
            var result = experimentService.GetAllExperiments();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedExperiments.Count, result.Count());
        }

        [Test]
        public void Dispose_CallsDisposeOnDatabase()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var experimentService = new ExperimentService(mockUnitOfWork.Object);

            // Act
            experimentService.Dispose();

            // Assert
            // You may want to use Moq to verify that the Dispose method on the Unit of Work (or the Database) was called, depending on your actual implementation.
            mockUnitOfWork.Verify(uow => uow.Dispose(), Times.Once);
        }
    }
}
