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
    public class AppUserServiceTest
    {
        public ILogger<AppUserServiceTest> _log;
        public ILogger<AppUserService> _servicelog;

        public AppUserServiceTest()
        {
            _log = Mock.Of<ILogger<AppUserServiceTest>>();
            _servicelog = Mock.Of<ILogger<AppUserService>>();
        }

        [TestMethod]
        public void GetAppUserTest()
        {
            //ARRANGE
            var mock = new Mock<IRepository<AppUser>>();
            mock.Setup(t => t.GetByCustom(It.IsAny<string>())).Returns(DataEntity.AppUser);

            //ACT
            var ActionService = new AppUserService(mock.Object, _servicelog);
            var result = ActionService.GetByCustom(string.Empty);

            //ASSERT
            Assert.IsNotNull(result);
        }
    }
}
