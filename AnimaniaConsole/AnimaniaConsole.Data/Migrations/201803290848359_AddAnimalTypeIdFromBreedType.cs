namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnimalTypeIdFromBreedType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BreedTypes", "AnimalType_Id", "dbo.AnimalTypes");
            DropIndex("dbo.BreedTypes", new[] { "AnimalType_Id" });
            RenameColumn(table: "dbo.BreedTypes", name: "AnimalType_Id", newName: "AnimalTypeId");
            AlterColumn("dbo.BreedTypes", "AnimalTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.BreedTypes", "AnimalTypeId");
            AddForeignKey("dbo.BreedTypes", "AnimalTypeId", "dbo.AnimalTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BreedTypes", "AnimalTypeId", "dbo.AnimalTypes");
            DropIndex("dbo.BreedTypes", new[] { "AnimalTypeId" });
            AlterColumn("dbo.BreedTypes", "AnimalTypeId", c => c.Byte());
            RenameColumn(table: "dbo.BreedTypes", name: "AnimalTypeId", newName: "AnimalType_Id");
            CreateIndex("dbo.BreedTypes", "AnimalType_Id");
            AddForeignKey("dbo.BreedTypes", "AnimalType_Id", "dbo.AnimalTypes", "Id");
        }
    }
}
