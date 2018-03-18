namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDataGeneratedOnIdinPost : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Posts", new[] { "Id" });
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.Posts", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Posts", "Id");
            CreateIndex("dbo.Posts", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Posts", new[] { "Id" });
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.Posts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Posts", "Id");
            CreateIndex("dbo.Posts", "Id");
        }
    }
}
