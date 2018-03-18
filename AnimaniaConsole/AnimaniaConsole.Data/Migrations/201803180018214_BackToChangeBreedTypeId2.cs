namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackToChangeBreedTypeId2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Animals", name: "BreedTypeIdId", newName: "BreedTypeId");
            RenameIndex(table: "dbo.Animals", name: "IX_BreedTypeIdId", newName: "IX_BreedTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Animals", name: "IX_BreedTypeId", newName: "IX_BreedTypeIdId");
            RenameColumn(table: "dbo.Animals", name: "BreedTypeId", newName: "BreedTypeIdId");
        }
    }
}
