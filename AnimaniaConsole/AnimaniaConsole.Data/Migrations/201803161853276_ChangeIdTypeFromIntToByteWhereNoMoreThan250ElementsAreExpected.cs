namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdTypeFromIntToByteWhereNoMoreThan250ElementsAreExpected : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BreedTypes", "AnimaltypeID", "dbo.AnimalTypes");
            DropForeignKey("dbo.Animals", "AnimalTypeID", "dbo.AnimalTypes");
            DropIndex("dbo.Animals", new[] { "AnimalTypeID" });
            DropIndex("dbo.BreedTypes", new[] { "AnimaltypeID" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropPrimaryKey("dbo.AnimalTypes");
            AlterColumn("dbo.Animals", "AnimalTypeID", c => c.Byte(nullable: false));
            AlterColumn("dbo.AnimalTypes", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.BreedTypes", "AnimaltypeID", c => c.Byte(nullable: false));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AddPrimaryKey("dbo.AnimalTypes", "Id");
            CreateIndex("dbo.Animals", "AnimalTypeID");
            CreateIndex("dbo.BreedTypes", "AnimaltypeID");
            AddForeignKey("dbo.BreedTypes", "AnimaltypeID", "dbo.AnimalTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Animals", "AnimalTypeID", "dbo.AnimalTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "AnimalTypeID", "dbo.AnimalTypes");
            DropForeignKey("dbo.BreedTypes", "AnimaltypeID", "dbo.AnimalTypes");
            DropIndex("dbo.BreedTypes", new[] { "AnimaltypeID" });
            DropIndex("dbo.Animals", new[] { "AnimalTypeID" });
            DropPrimaryKey("dbo.AnimalTypes");
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 12));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 12));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.BreedTypes", "AnimaltypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.AnimalTypes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Animals", "AnimalTypeID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AnimalTypes", "ID");
            CreateIndex("dbo.Users", "Email", unique: true);
            CreateIndex("dbo.Users", "UserName", unique: true);
            CreateIndex("dbo.BreedTypes", "AnimaltypeID");
            CreateIndex("dbo.Animals", "AnimalTypeID");
            AddForeignKey("dbo.Animals", "AnimalTypeID", "dbo.AnimalTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BreedTypes", "AnimaltypeID", "dbo.AnimalTypes", "ID", cascadeDelete: true);
        }
    }
}
