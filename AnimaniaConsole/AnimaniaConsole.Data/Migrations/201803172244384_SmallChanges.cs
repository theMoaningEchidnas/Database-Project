namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallChanges : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BreedTypes", new[] { "AnimaltypeID" });
            CreateIndex("dbo.BreedTypes", "AnimaltypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.BreedTypes", new[] { "AnimaltypeId" });
            CreateIndex("dbo.BreedTypes", "AnimaltypeID");
        }
    }
}
