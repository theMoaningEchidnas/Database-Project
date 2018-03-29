namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UservalidationAnimalTypevalidationBreedTypevalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AnimalTypes", "AnimalTypeName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.BreedTypes", "BreedTypeName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Skype", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "Facebook", c => c.String(maxLength: 30));
            CreateIndex("dbo.BreedTypes", "BreedTypeName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.BreedTypes", new[] { "BreedTypeName" });
            AlterColumn("dbo.Users", "Facebook", c => c.String());
            AlterColumn("dbo.Users", "Skype", c => c.String());
            AlterColumn("dbo.BreedTypes", "BreedTypeName", c => c.String());
            AlterColumn("dbo.AnimalTypes", "AnimalTypeName", c => c.String());
        }
    }
}
