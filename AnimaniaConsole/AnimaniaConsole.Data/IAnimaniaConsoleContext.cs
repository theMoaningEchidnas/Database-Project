using System.Data.Entity;
using AnimaniaConsole.Models.Models;

namespace AnimaniaConsole.Data
{
    public interface IAnimaniaConsoleContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<Animal> Animals { get; set; }

        IDbSet<AnimalType> AnimalTypes { get; set; }

        IDbSet<BreedType> BreedTypes { get; set; }

        IDbSet<Location> Locations { get; set; }

        int SaveChanges();
    }
}