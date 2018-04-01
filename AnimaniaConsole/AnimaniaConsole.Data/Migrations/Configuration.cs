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

            //Method outputs the EntityValidationErrors in PackageManager
            EntityValidationErrorsOutput.SaveChanges(context);







        }

    }
}
