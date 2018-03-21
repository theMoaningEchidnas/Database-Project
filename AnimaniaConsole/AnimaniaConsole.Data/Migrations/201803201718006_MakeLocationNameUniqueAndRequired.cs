namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeLocationNameUniqueAndRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "LocationName", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Locations", "LocationName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Locations", new[] { "LocationName" });
            AlterColumn("dbo.Locations", "LocationName", c => c.String());
        }
    }
}
