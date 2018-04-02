using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Contracts;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Services;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AnimaniaConsole.UnitTests.Services.UserServicesTests
{
    [TestClass]
    public class LogOut_Should
    {

        private IUserSessionModel userSession;

        [TestInitialize]
        public void Initialize()
        {
            userSession = new UserSessionModel
            {
                Id = 1,
                UserName = "Test"
            };
        }

        [TestMethod]
        public void Reset_userSessionId()
        {
            //Arrange
            var moqContext = new Mock<IAnimaniaConsoleContext>();
            var moqMapper = new Mock<IMapper>();
            var sut = new UserServices(moqContext.Object, moqMapper.Object, userSession);

            //Act 
            sut.LogOutUser();

            //Assert
            Assert.AreEqual(0, userSession.Id);
        }

        [TestMethod]
        public void Reset_userSessionUserName()
        {
            //Arrange
            var moqContext = new Mock<IAnimaniaConsoleContext>();
            var moqMapper = new Mock<IMapper>();
            var sut = new UserServices(moqContext.Object, moqMapper.Object, userSession);

            //Act 
            sut.LogOutUser();

            //Assert
            Assert.AreEqual(null, userSession.UserName);
        }

    }
}
