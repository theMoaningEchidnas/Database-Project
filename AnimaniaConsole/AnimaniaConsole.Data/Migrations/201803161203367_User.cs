namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "AnimalName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AnimalTypes", "AnimalTypeName", c => c.String());
            AddColumn("dbo.BreedTypes", "BreedTypeName", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 12));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 12));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 12));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 100));
            CreateIndex("dbo.Users", "UserName", unique: true);
            CreateIndex("dbo.Users", "Email", unique: true);
            DropColumn("dbo.Animals", "Name");
            DropColumn("dbo.AnimalTypes", "Name");
            DropColumn("dbo.BreedTypes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BreedTypes", "Name", c => c.String());
            AddColumn("dbo.AnimalTypes", "Name", c => c.String());
            AddColumn("dbo.Animals", "Name", c => c.String(nullable: false, maxLength: 50));
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "UserName" });
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            DropColumn("dbo.BreedTypes", "BreedTypeName");
            DropColumn("dbo.AnimalTypes", "AnimalTypeName");
            DropColumn("dbo.Animals", "AnimalName");
        }
    }
}
