namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusToUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Status");
        }
    }
}
