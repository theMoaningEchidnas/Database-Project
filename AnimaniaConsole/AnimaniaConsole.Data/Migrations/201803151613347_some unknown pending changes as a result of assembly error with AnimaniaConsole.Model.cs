namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someunknownpendingchangesasaresultofassemblyerrorwithAnimaniaConsoleModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Breeds", "Name", c => c.String());
            AddColumn("dbo.Posts", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Status");
            DropColumn("dbo.Breeds", "Name");
        }
    }
}
