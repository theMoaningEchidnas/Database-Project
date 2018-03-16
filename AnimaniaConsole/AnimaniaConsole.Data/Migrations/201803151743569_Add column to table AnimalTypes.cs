namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumntotableAnimalTypes : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Animals", new[] { "AnimalTypeId_ID" });
            AddColumn("dbo.AnimalTypes", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Animals", "AnimalTypeId_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Animals", new[] { "AnimalTypeId_Id" });
            DropColumn("dbo.AnimalTypes", "Name");
            CreateIndex("dbo.Animals", "AnimalTypeId_ID");
        }
    }
}
