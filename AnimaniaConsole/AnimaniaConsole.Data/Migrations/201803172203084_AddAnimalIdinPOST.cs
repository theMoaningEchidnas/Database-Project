namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnimalIdinPOST : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "AnimalId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "AnimalId");
        }
    }
}
