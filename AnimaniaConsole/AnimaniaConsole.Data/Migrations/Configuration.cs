namespace AnimaniaConsole.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<AnimaniaConsole.Data.AnimaniaConsoleContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            //TODO: to be set to false once app in production
            this.AutomaticMigrationDataLossAllowed = true;
            
        }

        protected override void Seed(AnimaniaConsole.Data.AnimaniaConsoleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
