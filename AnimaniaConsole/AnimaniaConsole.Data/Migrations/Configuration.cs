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

            var animalType = new AnimalType() { AnimalTypeName = "Dog" };
            context.AnimalTypes.AddOrUpdate(at => at.Id, animalType);
            context.SaveChanges();

            var maxAnimalTypeId = context.AnimalTypes.Max(x => x.Id);

            var breedType = new BreedType()
            {
                BreedTypeName = "Pudel2",
                AnimalTypeId = maxAnimalTypeId
            };
            context.BreedTypes.AddOrUpdate(bt => bt.Id, breedType);
            context.SaveChanges();

            var maxBreedTypeId = context.BreedTypes.Max(x => x.Id);

            var location = new Location() { Name = "Sofia" };
            context.Locations.AddOrUpdate(l => l.Id, location);
            context.SaveChanges();

            var maxLocationId = context.Locations.Max(x => x.Id);

            var rand = new Random().Next();

            ; var user = new Models.Models.User()
            {
                UserName = "cheficha" + rand,
                Password = "12345SmartPass",
                FirstName = "Stefan",
                LastName = "Zhekov",
                Email = "asdas" + rand + "@abv.bg",
            };
            context.Users.AddOrUpdate(u => u.Id, user);
            context.SaveChanges();

            var maxUserId = context.Users.Max(x => x.Id);

            var animal = new Animal()
            {
                AnimalName = "Jhony",
                Birthday = DateTime.Parse("2015-10-12"),
                AnimalTypeId = maxAnimalTypeId,
                BreedTypeId = maxBreedTypeId,
                LocationId = maxLocationId,
                UserId = maxUserId
            };
            context.Animals.AddOrUpdate(a => a.Id, animal);
            context.SaveChanges();

            var maxAnimalId = context.Animals.Max(x => x.Id);

            var post = new Post()
            {
                Id = maxAnimalId,
                Title = "A dog for sell",
                Description = "I sell my dog for a good price pls buy fast",
                PostDate = DateTime.Now,
                Price = 199m,
                Status = true,
                UserId = maxUserId
            };
            context.Posts.AddOrUpdate(p => p.Id, post);
            context.SaveChanges();

            //Method outputs the EntityValidationErrors in PackageManager
            EntityValidationErrorsOutput.SaveChanges(context);

        }
    }
}
