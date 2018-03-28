using AnimaniaConsole.DTO.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.UnitTests.Core.Commands.ChangePasswordCommandTests
{
    [TestClass]
    public class Constructor_Should
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
