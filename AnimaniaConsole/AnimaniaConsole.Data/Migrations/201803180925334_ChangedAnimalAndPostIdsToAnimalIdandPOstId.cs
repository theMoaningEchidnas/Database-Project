namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAnimalAndPostIdsToAnimalIdandPOstId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Animal_Id", "dbo.Animals");
            DropForeignKey("dbo.Posts", "Id", "dbo.Animals");
            RenameColumn(table: "dbo.Images", name: "Animal_Id", newName: "Animal_AnimalId");
            RenameColumn(table: "dbo.Posts", name: "Id", newName: "PostId");
            RenameIndex(table: "dbo.Images", name: "IX_Animal_Id", newName: "IX_Animal_AnimalId");
            RenameIndex(table: "dbo.Posts", name: "IX_Id", newName: "IX_PostId");
            DropPrimaryKey("dbo.Animals");
            DropColumn("dbo.Animals", "Id");
            DropColumn("dbo.Animals", "PostId");
            DropColumn("dbo.Posts", "AnimalId");
            AddColumn("dbo.Animals", "AnimalId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Animals", "AnimalId");
            AddForeignKey("dbo.Images", "Animal_AnimalId", "dbo.Animals", "AnimalId");
            AddForeignKey("dbo.Posts", "PostId", "dbo.Animals", "AnimalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "AnimalId", c => c.Int(nullable: false));
            AddColumn("dbo.Animals", "PostId", c => c.Int(nullable: false));
            AddColumn("dbo.Animals", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Posts", "PostId", "dbo.Animals");
            DropForeignKey("dbo.Images", "Animal_AnimalId", "dbo.Animals");
            DropPrimaryKey("dbo.Animals");
            DropColumn("dbo.Animals", "AnimalId");
            AddPrimaryKey("dbo.Animals", "Id");
            RenameIndex(table: "dbo.Posts", name: "IX_PostId", newName: "IX_Id");
            RenameIndex(table: "dbo.Images", name: "IX_Animal_AnimalId", newName: "IX_Animal_Id");
            RenameColumn(table: "dbo.Posts", name: "PostId", newName: "Id");
            RenameColumn(table: "dbo.Images", name: "Animal_AnimalId", newName: "Animal_Id");
            AddForeignKey("dbo.Posts", "Id", "dbo.Animals", "Id");
            AddForeignKey("dbo.Images", "Animal_Id", "dbo.Animals", "Id");
        }
    }
}
