namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllIdsAutoIncrement_NoSeedData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BreedTypes", "AnimaltypeID", "dbo.AnimalTypes");
            DropForeignKey("dbo.Animals", "AnimalTypeID", "dbo.AnimalTypes");
            DropForeignKey("dbo.Images", "PostId", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "Id" });
            DropPrimaryKey("dbo.AnimalTypes");
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.AnimalTypes", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Posts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AnimalTypes", "Id");
            AddPrimaryKey("dbo.Posts", "Id");
            CreateIndex("dbo.Posts", "Id");
            AddForeignKey("dbo.BreedTypes", "AnimaltypeID", "dbo.AnimalTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Animals", "AnimalTypeID", "dbo.AnimalTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Images", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Animals", "AnimalTypeID", "dbo.AnimalTypes");
            DropForeignKey("dbo.BreedTypes", "AnimaltypeID", "dbo.AnimalTypes");
            DropIndex("dbo.Posts", new[] { "Id" });
            DropPrimaryKey("dbo.Posts");
            DropPrimaryKey("dbo.AnimalTypes");
            AlterColumn("dbo.Posts", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.AnimalTypes", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Posts", "Id");
            AddPrimaryKey("dbo.AnimalTypes", "Id");
            CreateIndex("dbo.Posts", "Id");
            AddForeignKey("dbo.Images", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Animals", "AnimalTypeID", "dbo.AnimalTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BreedTypes", "AnimaltypeID", "dbo.AnimalTypes", "Id", cascadeDelete: true);
        }
    }
}
