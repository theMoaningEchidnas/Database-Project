using AnimaniaConsole.Core.Commands;
using AnimaniaConsole.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.UnitTests.Core.Commands.SearchByPriceFromCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Throw_When_PostServices_Are_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(()=> new SearchPostsByPriceFromCommand(null));
        }
        
    }
}
