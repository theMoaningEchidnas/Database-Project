namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePasswordValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
    }
}
