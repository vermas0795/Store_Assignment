using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class AuthenticateControllerTest
    {
        public ILogger<AuthenticateControllerTest> _log;
        public ILogger<AuthenticateController> _servicelog;

        public AuthenticateControllerTest()
        {
            _log = Mock.Of<ILogger<AuthenticateControllerTest>>();
            _servicelog = Mock.Of<ILogger<AuthenticateController>>();
        }

        [TestMethod]
        public void AuthenticateUserSuccessTest()
        {
            //ARRANGE
            var mock = new Mock<IServiceRepository<AppUserModel>>();
            mock.Setup(t => t.GetByCustom(It.IsAny<string>())).Returns(ViewModel.AppUserModel);
            Mock<IConfigurationSection> mockSection = new Mock<IConfigurationSection>();
            mockSection.Setup(x => x.Value).Returns("Siemens_Project_Assignement");
            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(x => x.GetSection(It.IsAny<string>())).Returns(mockSection.Object);
            
            //ACT
            var AuthenticateController = new AuthenticateController(mock.Object, _servicelog, mockConfig.Object);
            var result = AuthenticateController.AuthenticateUser(ViewModel.AppUserModel);
            var data = result as OkObjectResult;

            //ASSERT
            Assert.AreEqual(StatusCodes.Status200OK, data.StatusCode);
            Assert.IsNotNull(data.Value);
            Assert.IsInstanceOfType(data.Value, typeof(AppUserModel));

        }

        [TestMethod]
        public void AuthenticateUserUnAuthorizedTest()
        {
            //ARRANGE
            var mock = new Mock<IServiceRepository<AppUserModel>>();
            mock.Setup(t => t.GetByCustom(string.Empty)).Returns(ViewModel.AppUserModel);
            Mock<IConfigurationSection> mockSection = new Mock<IConfigurationSection>();
            mockSection.Setup(x => x.Value).Returns(string.Empty);
            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(x => x.GetSection(It.IsAny<string>())).Returns(mockSection.Object);

            //ACT
            var AuthenticateController = new AuthenticateController(mock.Object, _servicelog, mockConfig.Object);
            var result = AuthenticateController.AuthenticateUser(ViewModel.AppUserModel);
            var data = result as UnauthorizedResult;

            //ASSERT
            Assert.AreEqual(StatusCodes.Status401Unauthorized, data.StatusCode);
        }

        [TestMethod]
        public void AuthenticateUserNotFoundTest()
        {
            //ARRANGE
            var mock = new Mock<IServiceRepository<AppUserModel>>();
            mock.Setup(t => t.GetByCustom(It.IsAny<string>())).Returns(ViewModel.AppUserModel);
            Mock<IConfigurationSection> mockSection = new Mock<IConfigurationSection>();
            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(x => x.GetSection(It.IsAny<string>())).Returns(mockSection.Object);

            //ACT
            var AuthenticateController = new AuthenticateController(mock.Object, _servicelog, mockConfig.Object);
            var result = AuthenticateController.AuthenticateUser(ViewModel.AppUserModel);
            var data = result as NotFoundResult;

            //ASSERT
            Assert.AreEqual(StatusCodes.Status404NotFound, data.StatusCode);
        }
    }
}
