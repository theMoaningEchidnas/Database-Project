using AnimaniaConsole.Data;

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
