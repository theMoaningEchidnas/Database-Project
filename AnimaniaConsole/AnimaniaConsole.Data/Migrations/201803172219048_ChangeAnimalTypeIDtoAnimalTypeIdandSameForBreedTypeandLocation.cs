namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAnimalTypeIDtoAnimalTypeIdandSameForBreedTypeandLocation : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Animals", new[] { "BreedTypeID" });
            DropIndex("dbo.Animals", new[] { "AnimalTypeID" });
            DropIndex("dbo.Animals", new[] { "LocationID" });
            CreateIndex("dbo.Animals", "BreedTypeId");
            CreateIndex("dbo.Animals", "AnimalTypeId");
            CreateIndex("dbo.Animals", "LocationId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Animals", new[] { "LocationId" });
            DropIndex("dbo.Animals", new[] { "AnimalTypeId" });
            DropIndex("dbo.Animals", new[] { "BreedTypeId" });
            CreateIndex("dbo.Animals", "LocationID");
            CreateIndex("dbo.Animals", "AnimalTypeID");
            CreateIndex("dbo.Animals", "BreedTypeID");
        }
    }
}
