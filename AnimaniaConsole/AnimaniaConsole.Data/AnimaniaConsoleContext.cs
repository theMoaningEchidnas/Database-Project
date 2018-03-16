using AnimaniaConsole.Models;
using System.Data.Entity;

namespace AnimaniaConsole.Data
{
    public class AnimaniaConsoleContext : DbContext
    {
        public AnimaniaConsoleContext() : base("name=AnimaniaConsoleCtx")
        {
            //To be used in case of Automatic Migration
            //var strategy = new MigrateDatabaseToLatestVersion<AnimaniaConsoleContext, Configuration>();
            //Database.SetInitializer(strategy);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<BreedType> BreedTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Animal>()
                .HasRequired(s => s.Post).WithRequiredPrincipal(ad => ad.Animal);
        }
    }
}
