﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaniaConsole.Core.Contracts
{
    public interface IRenderer
    {
        void DispalyMainMenu();
        void DisplayUserMenu();
        void DisplayModelProperties(string[] properties);
    }
}
