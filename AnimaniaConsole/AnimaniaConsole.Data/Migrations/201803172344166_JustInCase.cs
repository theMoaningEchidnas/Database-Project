namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JustInCase : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BreedTypes", new[] { "AnimaltypeId" });
            CreateIndex("dbo.BreedTypes", "AnimalTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.BreedTypes", new[] { "AnimalTypeId" });
            CreateIndex("dbo.BreedTypes", "AnimaltypeId");
        }
    }
}
