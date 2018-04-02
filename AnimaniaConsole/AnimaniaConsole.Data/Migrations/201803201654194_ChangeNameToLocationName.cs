namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameToLocationName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "LocationName", c => c.String());
            DropColumn("dbo.Locations", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Name", c => c.String());
            DropColumn("dbo.Locations", "LocationName");
        }
    }
}
