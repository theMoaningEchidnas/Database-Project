using AnimaniaConsole.Core.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.UnitTests.Core.Commands.SearchPostsCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Throw_Exception_IfPostService_IsNull()
        {
            Action creatingSearchPostsCommand = () => new SearchPostsCommand(null);

            Assert.ThrowsException<ArgumentNullException>(creatingSearchPostsCommand);
        }
    }
}
