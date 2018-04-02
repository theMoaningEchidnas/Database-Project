namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TweakPropsTryingToFixErrorResultedFromDatabaseGeneratedIds : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "UserId", newName: "User_Id");
            RenameIndex(table: "dbo.Posts", name: "IX_UserId", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Posts", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Posts", name: "User_Id", newName: "UserId");
        }
    }
}
