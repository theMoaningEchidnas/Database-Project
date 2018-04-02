namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Johnyanymaltype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animals", "BreedTypeID", "dbo.BreedTypes");
            DropIndex("dbo.Animals", new[] { "BreedTypeID" });
            AddColumn("dbo.Animals", "Birthday", c => c.DateTime());
            AddColumn("dbo.Animals", "AnimalTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Animals", "PostId", c => c.Int());
            AlterColumn("dbo.Animals", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Animals", "BreedTypeID", c => c.Int());
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Posts", "Description", c => c.String(nullable: false, maxLength: 1000));
            CreateIndex("dbo.Animals", "BreedTypeID");
            CreateIndex("dbo.Animals", "AnimalTypeID");
            AddForeignKey("dbo.Animals", "AnimalTypeID", "dbo.AnimalTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Animals", "BreedTypeID", "dbo.BreedTypes", "ID");
            DropColumn("dbo.Animals", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "Age", c => c.Int(nullable: false));
            DropForeignKey("dbo.Animals", "BreedTypeID", "dbo.BreedTypes");
            DropForeignKey("dbo.Animals", "AnimalTypeID", "dbo.AnimalTypes");
            DropIndex("dbo.Animals", new[] { "AnimalTypeID" });
            DropIndex("dbo.Animals", new[] { "BreedTypeID" });
            AlterColumn("dbo.Posts", "Description", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Animals", "BreedTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Animals", "Name", c => c.String());
            AlterColumn("dbo.Animals", "PostId", c => c.Int(nullable: false));
            DropColumn("dbo.Animals", "AnimalTypeID");
            DropColumn("dbo.Animals", "Birthday");
            CreateIndex("dbo.Animals", "BreedTypeID");
            AddForeignKey("dbo.Animals", "BreedTypeID", "dbo.BreedTypes", "ID", cascadeDelete: true);
        }
    }
}
