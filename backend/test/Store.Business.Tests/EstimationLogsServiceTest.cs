using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Store.Business.Implementation;
using Store.Core.Tests;
using Store.DataAccess.Repository;
using Store.DataAccess.Repository.Entities;

namespace Store.Api.Tests
{
    [TestClass]
    public class EstimationLogsServiceTest
    {
        public ILogger<EstimationLogsServiceTest> _log;
        public ILogger<EstimationLogsService> _servicelog;

        public EstimationLogsServiceTest()
        {
            _log = Mock.Of<ILogger<EstimationLogsServiceTest>>();
            _servicelog = Mock.Of<ILogger<EstimationLogsService>>();
        }

        [TestMethod]
        public void GetEstimationLogsTest()
        {
            //ARRANGE
            var mock = new Mock<IRepository<EstimationLogs>>();
            mock.Setup(t => t.Insert(It.IsAny<EstimationLogs>())).Returns(DataEntity.EstimationLogs);

            //ACT
            var EstimationLogsService = new EstimationLogsService(mock.Object, _servicelog);
            var result = EstimationLogsService.Insert(ViewModel.EstimationLogsModel);

            //ASSERT
            Assert.IsNotNull(result);
        }

    }
}
