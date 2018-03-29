namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAnimalTypeIdFromBreedType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BreedTypes", "AnimalTypeId", "dbo.AnimalTypes");
            DropIndex("dbo.BreedTypes", new[] { "AnimalTypeId" });
            RenameColumn(table: "dbo.BreedTypes", name: "AnimalTypeId", newName: "AnimalType_Id");
            AlterColumn("dbo.BreedTypes", "AnimalType_Id", c => c.Byte());
            CreateIndex("dbo.BreedTypes", "AnimalType_Id");
            AddForeignKey("dbo.BreedTypes", "AnimalType_Id", "dbo.AnimalTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BreedTypes", "AnimalType_Id", "dbo.AnimalTypes");
            DropIndex("dbo.BreedTypes", new[] { "AnimalType_Id" });
            AlterColumn("dbo.BreedTypes", "AnimalType_Id", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.BreedTypes", name: "AnimalType_Id", newName: "AnimalTypeId");
            CreateIndex("dbo.BreedTypes", "AnimalTypeId");
            AddForeignKey("dbo.BreedTypes", "AnimalTypeId", "dbo.AnimalTypes", "Id", cascadeDelete: true);
        }
    }
}
