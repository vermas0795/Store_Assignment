using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Store.Api.Controllers;
using Store.Business.Interfaces;
using Store.Core.Tests;
using Store.Core.ViewEntity;

namespace Store.Api.Tests
{
    [TestClass]
    public class EstimationLogsControllerTest
    {
        public ILogger<EstimationLogsControllerTest> _log;
        public ILogger<EstimationLogsController> _servicelog;

        public EstimationLogsControllerTest()
        {
            _log = Mock.Of<ILogger<EstimationLogsControllerTest>>();
            _servicelog = Mock.Of<ILogger<EstimationLogsController>>();
        }
        [TestMethod]
        public void PositiveTest()
        {
            //ARRANGE
            var mock = new Mock<IServiceRepository<EstimationLogsModel>>();
            mock.Setup(t => t.Insert(It.IsAny<EstimationLogsModel>())).Returns(ViewModel.EstimationLogsModel);
            
            //ACT
            var EstimationLogsController = new EstimationLogsController(mock.Object, _servicelog);
            var result = EstimationLogsController.EstimationLogs(ViewModel.EstimationLogsModel);
            var data = result as OkObjectResult;

            //ASSERT
            Assert.AreEqual(StatusCodes.Status200OK, data.StatusCode);
            Assert.IsNotNull(data.Value);
            Assert.IsInstanceOfType(data.Value, typeof(EstimationLogsModel));

        }
        [TestMethod]
        public void NegativeTest()
        {
            //ARRANGE
            EstimationLogsModel est = null;
            var mock = new Mock<IServiceRepository<EstimationLogsModel>>();
            mock.Setup(t => t.Insert(It.IsAny<EstimationLogsModel>())).Returns(est);

            //ACT
            var EstimationLogsController = new EstimationLogsController(mock.Object, _servicelog);
            var result = EstimationLogsController.EstimationLogs(ViewModel.EstimationLogsModel);
            var data = result as NotFoundResult;

            //ASSERT
            Assert.AreEqual(StatusCodes.Status404NotFound, data.StatusCode);
        }
    }
}
