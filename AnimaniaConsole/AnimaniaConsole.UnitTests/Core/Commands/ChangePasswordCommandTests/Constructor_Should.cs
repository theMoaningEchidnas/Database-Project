using System;
using AnimaniaConsole.Core.Commands;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnimaniaConsole.UnitTests.Core.Commands.ChangePasswordCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        private UserSessionModel userSession;

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
        public void Throw_Exception_IfUserService_IsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ChangePasswordCommand(null));
        }

    }
}
