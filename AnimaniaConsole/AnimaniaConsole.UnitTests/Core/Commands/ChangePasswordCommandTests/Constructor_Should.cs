using AnimaniaConsole.DTO.Models;
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

        }

        [TestMethod]
        public void Throw_Exception_IfSessionService_IsNull()
        {

        }

        [TestMethod]
        public void Throw_Exception_IfSession_IsNull()
        {

        }
    }
}
