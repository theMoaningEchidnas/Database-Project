namespace AnimaniaConsole.Data.Migrations
{
    using AnimaniaConsole.Models;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<AnimaniaConsole.Data.AnimaniaConsoleContext>
    {
        public Configuration()
        {
        }

        protected override void Seed(AnimaniaConsole.Data.AnimaniaConsoleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            /*
            context.Animals.AddOrUpdate(x => x.Id,
                  new Animal() { Id = 1, AnimalName = "Jane Austen" },
                  new Animal() { Id = 2, AnimalName = "Charles Dickens" },
                  new Animal() { Id = 3, AnimalName = "Miguel de Cervantes" }
                  );

            context.Users.AddOrUpdate(x => x.Id,
                new Book()
                {
                    Id = 1,
                    Title = "Pride and Prejudice",
                    Year = 1813,
                    AuthorId = 1,
                    Price = 9.99M,
                    Genre = "Comedy of manners"
                },
                new Book()
                {
                    Id = 2,
                    Title = "Northanger Abbey",
                    Year = 1817,
                    AuthorId = 1,
                    Price = 12.95M,
                    Genre = "Gothic parody"
                },
                new Book()
                {
                    Id = 3,
                    Title = "David Copperfield",
                    Year = 1850,
                    AuthorId = 2,
                    Price = 15,
                    Genre = "Bildungsroman"
                },
                new Book()
                {
                    Id = 4,
                    Title = "Don Quixote",
                    Year = 1617,
                    AuthorId = 3,
                    Price = 8.95M,
                    Genre = "Picaresque"
                }
                );
                */
        }
    }
}
