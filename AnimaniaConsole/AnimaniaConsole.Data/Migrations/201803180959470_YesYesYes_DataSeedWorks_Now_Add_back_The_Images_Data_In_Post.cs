namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YesYesYes_DataSeedWorks_Now_Add_back_The_Images_Data_In_Post : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Images", "PostId");
            AddForeignKey("dbo.Images", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "PostId", "dbo.Posts");
            DropIndex("dbo.Images", new[] { "PostId" });
        }
    }
}
