namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryRemoveImagesFromPost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "PostId", "dbo.Posts");
            DropIndex("dbo.Images", new[] { "PostId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Images", "PostId");
            AddForeignKey("dbo.Images", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
