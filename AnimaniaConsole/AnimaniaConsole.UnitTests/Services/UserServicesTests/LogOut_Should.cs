using AnimaniaConsole.Data;
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

        private UserSessionModel userSession;

        [TestInitialize]
        public void Initialize()
        {
            userSession = new UserSessionModel();
            userSession.Id = 1;
            userSession.UserName = "Test";
        }


        [TestMethod]
        public void Reset_Session_Id()
        {
            var moqContext = new Mock<IAnimaniaConsoleContext>();
            var moqMapper = new Mock<IMapper>();



            var userService = new UserServices(moqContext.Object, moqMapper.Object, userSession);

            userService.LogOutUser();

            Assert.AreEqual(0, userSession.Id);

        }


    }
}
