namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReturnPostIdToBeOptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "PostId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "PostId", c => c.Int(nullable: false));
        }
    }
}
