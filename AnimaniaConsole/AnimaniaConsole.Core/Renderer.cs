using AnimaniaConsole.Core.Constants;
using AnimaniaConsole.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Core
{
    public class Renderer : IRenderer
    {
        private readonly IWriter writer;

        public Renderer(IWriter writer)
        {
            this.writer = writer;
        }

        public void DispalyMainMenu()
        {
            for (int i = 1; i <= GlobalConstants.mainMenuOptions.Length; i++)
            {
                writer.Write($"{i}. {GlobalConstants.mainMenuOptions[i - 1]}  ");
            }
            writer.NewLine();
        }

        public void DisplayUserMenu()
        {
            for (int i = 1; i <= GlobalConstants.userMenuOptions.Length; i++)
            {
                writer.Write($"{i}. {GlobalConstants.mainMenuOptions[i - 1]}");
            }
            writer.NewLine();
        }

        public void DisplayModelProperties(string[] properties)
        {
            for (int i = 1; i <= properties.Length; i++)
            {
                writer.WriteLine($"{i}. {properties[i - 1]}");
            }
            writer.NewLine();
        }
    }
}
