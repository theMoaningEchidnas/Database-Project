using AnimaniaConsole.Models.Models;
using System.Data.Common;
using System.Data.Entity;

namespace AnimaniaConsole.Data
{
    public class AnimaniaConsoleContext : DbContext, IAnimaniaConsoleContext
    {
        public AnimaniaConsoleContext()
            : base("name=AnimaniaConsoleCtx")
        {
            //To be used in case of Automatic Migration
            //var strategy = new MigrateDatabaseToLatestVersion<AnimaniaConsoleContext, Configuration>();
            //Database.SetInitializer(strategy);
        }

        public AnimaniaConsoleContext(DbConnection connection)
            : base(connection, true)
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //without this we will get an error
            modelBuilder.Entity<Animal>()
                .HasRequired(s => s.Post)
                .WithRequiredPrincipal(ad => ad.Animal);
        }

        public IDbSet<Post> Posts { get; set; }
        public IDbSet<Image> Images { get; set; }
        public IDbSet<Location> Locations { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Animal> Animals { get; set; }
        public IDbSet<AnimalType> AnimalTypes { get; set; }
        public IDbSet<BreedType> BreedTypes { get; set; }
    }
}
