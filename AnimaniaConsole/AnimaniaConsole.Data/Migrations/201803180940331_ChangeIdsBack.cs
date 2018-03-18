namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdsBack : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Animal_AnimalId", "dbo.Animals");
            DropForeignKey("dbo.Posts", "PostId", "dbo.Animals");
            RenameColumn(table: "dbo.Images", name: "Animal_AnimalId", newName: "Animal_Id");
            RenameColumn(table: "dbo.Posts", name: "PostId", newName: "Id");
            RenameIndex(table: "dbo.Images", name: "IX_Animal_AnimalId", newName: "IX_Animal_Id");
            RenameIndex(table: "dbo.Posts", name: "IX_PostId", newName: "IX_Id");
            DropPrimaryKey("dbo.Animals");
            DropColumn("dbo.Animals", "AnimalId");
            AddColumn("dbo.Animals", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Animals", "Id");
            AddForeignKey("dbo.Images", "Animal_Id", "dbo.Animals", "Id");
            AddForeignKey("dbo.Posts", "Id", "dbo.Animals", "Id");
                    }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "AnimalId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Posts", "Id", "dbo.Animals");
            DropForeignKey("dbo.Images", "Animal_Id", "dbo.Animals");
            DropPrimaryKey("dbo.Animals");
            DropColumn("dbo.Animals", "Id");
            AddPrimaryKey("dbo.Animals", "AnimalId");
            RenameIndex(table: "dbo.Posts", name: "IX_Id", newName: "IX_PostId");
            RenameIndex(table: "dbo.Images", name: "IX_Animal_Id", newName: "IX_Animal_AnimalId");
            RenameColumn(table: "dbo.Posts", name: "Id", newName: "PostId");
            RenameColumn(table: "dbo.Images", name: "Animal_Id", newName: "Animal_AnimalId");
            AddForeignKey("dbo.Posts", "PostId", "dbo.Animals", "AnimalId");
            AddForeignKey("dbo.Images", "Animal_AnimalId", "dbo.Animals", "AnimalId");
        }
    }
}
