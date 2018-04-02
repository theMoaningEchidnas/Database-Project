using System;
using AnimaniaConsole.Core.Commands;
using AnimaniaConsole.DTO.Models;
using AnimaniaConsole.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnimaniaConsole.UnitTests.Core.Commands.ActivetePostCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Throw_Exception_IfPostService_IsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ActivatePostCommand(null));
        }

    }
}
