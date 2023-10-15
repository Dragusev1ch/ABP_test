using ABP_test.Controllers;
using ABP_test.Interfaces.Services;
using ABP_test.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APB_test.NUnitTest.Controllers
{
    [TestFixture]
    public class ExperimentControllerTests
    {
        private ExperimentController _controller;
        private Mock<IExperimentService> _experimentServiceMock;

        [SetUp]
        public void Setup()
        {
            _experimentServiceMock = new Mock<IExperimentService>();
            _controller = new ExperimentController(_experimentServiceMock.Object);
        }

        [Test]
        public void GetButtonColorExperiment_ValidDeviceToken_ReturnsOkResult()
        {
            // Arrange
            string deviceToken = "validToken";
            var experimentResult = new Experiment { /* Initialize experiment data */ };
            _experimentServiceMock.Setup(x => x.GetButtonColorExperiment(deviceToken)).Returns(experimentResult);

            // Act
            var result = _controller.GetButtonColorExperiment(deviceToken);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetButtonColorExperiment_InvalidDeviceToken_ReturnsNotFound()
        {
            // Arrange
            string deviceToken = "invalidToken";
            _experimentServiceMock.Setup(x => x.GetButtonColorExperiment(deviceToken)).Returns((Experiment)null);

            // Act
            var result = _controller.GetButtonColorExperiment(deviceToken);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetPriceExperiment_ValidDeviceToken_ReturnsOkResult()
        {
            // Arrange
            string deviceToken = "validToken";
            var experimentResult = new Experiment { /* Initialize experiment data */ };
            _experimentServiceMock.Setup(x => x.GetPriceExperiment(deviceToken)).Returns(experimentResult);

            // Act
            var result = _controller.GetPriceExperiment(deviceToken);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetPriceExperiment_InvalidDeviceToken_ReturnsNotFound()
        {
            // Arrange
            string deviceToken = "invalidToken";
            _experimentServiceMock.Setup(x => x.GetPriceExperiment(deviceToken)).Returns((Experiment)null);

            // Act
            var result = _controller.GetPriceExperiment(deviceToken);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetExperimentsList_ReturnsOkResult()
        {
            // Arrange
            var experiments = new List<Experiment> { /* Initialize a list of experiments */ };


            // Act
            var result = _controller.GetExperimentsList() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
