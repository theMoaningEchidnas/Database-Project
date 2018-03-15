using AnimaniaConsole.Data.Migrations;
using AnimaniaConsole.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace AnimaniaConsole.Data
{
    public class AnimaniaConsoleContext : DbContext
    {
        public AnimaniaConsoleContext() : base("name=AnimaniaConsoleCtx")
        {
            var strategy = new MigrateDatabaseToLatestVersion<AnimaniaConsoleContext, Configuration>();
            Database.SetInitializer(strategy);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }

    }
}
