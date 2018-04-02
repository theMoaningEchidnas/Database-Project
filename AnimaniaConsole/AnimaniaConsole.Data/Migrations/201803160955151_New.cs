namespace AnimaniaConsole.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        BreedTypeID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BreedTypes", t => t.BreedTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BreedTypeID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.BreedTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AnimaltypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AnimalTypes", t => t.AnimaltypeID, cascadeDelete: true)
                .Index(t => t.AnimaltypeID);
            
            CreateTable(
                "dbo.AnimalTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageFile = c.Binary(),
                        ImageFileName = c.String(),
                        PostId = c.Int(nullable: false),
                        Animal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animals", t => t.Animal_Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.Animal_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animals", t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Tel = c.String(),
                        Skype = c.String(),
                        FaceBook = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "UserId", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Posts", "Id", "dbo.Animals");
            DropForeignKey("dbo.Images", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Animals", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Images", "Animal_Id", "dbo.Animals");
            DropForeignKey("dbo.Animals", "BreedTypeID", "dbo.BreedTypes");
            DropForeignKey("dbo.BreedTypes", "AnimaltypeID", "dbo.AnimalTypes");
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "Id" });
            DropIndex("dbo.Images", new[] { "Animal_Id" });
            DropIndex("dbo.Images", new[] { "PostId" });
            DropIndex("dbo.BreedTypes", new[] { "AnimaltypeID" });
            DropIndex("dbo.Animals", new[] { "LocationID" });
            DropIndex("dbo.Animals", new[] { "BreedTypeID" });
            DropIndex("dbo.Animals", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Locations");
            DropTable("dbo.Images");
            DropTable("dbo.AnimalTypes");
            DropTable("dbo.BreedTypes");
            DropTable("dbo.Animals");
        }
    }
}
