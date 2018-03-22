using AnimaniaConsole.Models.Models;
using System;
using System.Linq;

namespace AnimaniaConsole.Data.Migrations
{
    using System.Data.Entity.Migrations;


    public sealed class Configuration : DbMigrationsConfiguration<AnimaniaConsole.Data.AnimaniaConsoleContext>
    {

        public Configuration()
        {
            ////used while in development mode to be able to debug while updating database
            //if (System.Diagnostics.Debugger.IsAttached == false) { System.Diagnostics.Debugger.Launch(); }
        }

        protected override void Seed(AnimaniaConsole.Data.AnimaniaConsoleContext context)
        {
            /*string dogString = "Dog";
            var dog = context.AnimalTypes.Where(x => x.AnimalTypeName == dogString).Single();

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString("https://dog.ceo/api/breeds/list/all");
                // Now parse with JSON.Net
            }
            context.BreedTypes.AddOrUpdate();
            context.SaveChanges();

            //Method outputs the EntityValidationErrors in PackageManager
            EntityValidationErrorsOutput.SaveChanges(context);*/

        }
        
    }
}
