using AnimaniaConsole.Core.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AnimaniaConsole.UnitTests.Core.Commands.SearchByPriceFromCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Throw_When_PostServices_Are_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new SearchPostsByPriceFromCommand(null));
        }

    }
}
