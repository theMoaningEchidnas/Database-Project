namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryToINcludeAnimalInPostWhenSeeding1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "PostId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "PostId", c => c.Int());
        }
    }
}
