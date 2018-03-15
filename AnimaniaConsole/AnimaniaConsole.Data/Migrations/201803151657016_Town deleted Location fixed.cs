namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TowndeletedLocationfixed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Animals", "AnimalName", c => c.String());
            AddColumn("dbo.Animals", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Animals", "AnimalTypeId_ID", c => c.Int());
            AddColumn("dbo.Animals", "BreedID_ID", c => c.Int());
            AddColumn("dbo.Animals", "UserId_Id", c => c.Int());
            AddColumn("dbo.Locations", "LocationName", c => c.String());
            AddColumn("dbo.Posts", "Status", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Animals", "AnimalTypeId_ID");
            CreateIndex("dbo.Animals", "BreedID_ID");
            CreateIndex("dbo.Animals", "UserId_Id");
            AddForeignKey("dbo.Animals", "AnimalTypeId_ID", "dbo.AnimalTypes", "ID");
            AddForeignKey("dbo.Animals", "BreedID_ID", "dbo.Breeds", "ID");
            AddForeignKey("dbo.Animals", "UserId_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "UserId_Id", "dbo.Users");
            DropForeignKey("dbo.Animals", "BreedID_ID", "dbo.Breeds");
            DropForeignKey("dbo.Animals", "AnimalTypeId_ID", "dbo.AnimalTypes");
            DropIndex("dbo.Animals", new[] { "UserId_Id" });
            DropIndex("dbo.Animals", new[] { "BreedID_ID" });
            DropIndex("dbo.Animals", new[] { "AnimalTypeId_ID" });
            DropColumn("dbo.Posts", "Status");
            DropColumn("dbo.Locations", "LocationName");
            DropColumn("dbo.Animals", "UserId_Id");
            DropColumn("dbo.Animals", "BreedID_ID");
            DropColumn("dbo.Animals", "AnimalTypeId_ID");
            DropColumn("dbo.Animals", "Age");
            DropColumn("dbo.Animals", "AnimalName");
            DropTable("dbo.Breeds");
            DropTable("dbo.AnimalTypes");
        }
    }
}
