using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnimaniaConsole.UnitTests.Core.Commands.EditPostPriceCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void Throw_ArgumentException_When_Price_IsNotDecimal()
        {


        }

        [TestMethod]
        public void Throw_ArgumentException_When_ThereIsNoLogedUser()
        {


        }

        [TestMethod]
        public void Throw_ArgumentException_When_PostToBeEdited_DoesNotExist()
        {


        }

        [TestMethod]
        public void Throw_ArgumentException_When_UsedTriesToEditPrice_OnPostWhichIsCreatedByOtherUser()
        {


        }


    }
}
