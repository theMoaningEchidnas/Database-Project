namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBreedTypeId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Animals", name: "BreedTypeId", newName: "BreedTypeIdId");
            RenameIndex(table: "dbo.Animals", name: "IX_BreedTypeId", newName: "IX_BreedTypeIdId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Animals", name: "IX_BreedTypeIdId", newName: "IX_BreedTypeId");
            RenameColumn(table: "dbo.Animals", name: "BreedTypeIdId", newName: "BreedTypeId");
        }
    }
}
