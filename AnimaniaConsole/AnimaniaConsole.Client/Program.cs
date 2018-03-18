using AnimaniaConsole.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace AnimaniaConsole.Client
{
    class Program
    {
        static void Main(string[] args)
        {
                var context = new AnimaniaConsoleContext();
                context.Database.CreateIfNotExists();

                //var animals = context.Animals.Add() ;
        
        }
    }
}
