namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BreedType : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BreedTypes", new[] { "BreedTypeName" });
            AlterColumn("dbo.BreedTypes", "BreedTypeName", c => c.String(nullable: false, maxLength: 60));
            CreateIndex("dbo.BreedTypes", "BreedTypeName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.BreedTypes", new[] { "BreedTypeName" });
            AlterColumn("dbo.BreedTypes", "BreedTypeName", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.BreedTypes", "BreedTypeName", unique: true);
        }
    }
}
