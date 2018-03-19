using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = "Title";
            Console.Write(title);
            Console.SetCursorPosition(title.Length + 1, 0);
            string titleName = Console.ReadLine();
            string desc = "Desc";
            Console.Write(desc);
            Console.SetCursorPosition(desc.Length + 1, 1);
            string decsName = Console.ReadLine();

        }
    }
}
