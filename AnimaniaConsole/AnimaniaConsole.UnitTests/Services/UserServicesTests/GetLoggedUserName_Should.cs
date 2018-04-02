using AnimaniaConsole.Data;
using AnimaniaConsole.DTO.Contracts;
using AnimaniaConsole.Services.Services;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.UnitTests.Services.UserServicesTests
{
    [TestClass]
    public class GetLoggedUserName_Should
    {
        [TestMethod]
        public void Return_TheSession_Username()
        {
            string userName = "Test";

            var contextMock = new Mock<IAnimaniaConsoleContext>();
            var mapperMock = new Mock<IMapper>();
            var sessionMock = new Mock<IUserSessionModel>();

            sessionMock.Setup(x => x.UserName).Returns(userName);
            sessionMock.Setup(x => x.Id).Returns(1);

            var userServices = new UserServices(contextMock.Object, mapperMock.Object, sessionMock.Object);

            Assert.AreEqual(userName, userServices.GetLoggedUserName());
        }
    }
}
