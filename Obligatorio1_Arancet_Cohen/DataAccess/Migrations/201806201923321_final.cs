namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlueprintEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Length = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Owner_UserName = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserEntities", t => t.Owner_UserName, cascadeDelete: true)
                .Index(t => t.Id, unique: true)
                .Index(t => t.Owner_UserName);
            
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 100, unicode: false),
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Password = c.String(),
                        RegistrationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastLoginDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Phone = c.String(),
                        IdCard = c.String(),
                        Address = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserName)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.ColumnEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Width = c.Single(nullable: false),
                        Length = c.Single(nullable: false),
                        Height = c.Single(nullable: false),
                        CoordX = c.Single(nullable: false),
                        CoordY = c.Single(nullable: false),
                        BearerBlueprint_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlueprintEntities", t => t.BearerBlueprint_Id, cascadeDelete: true)
                .Index(t => t.BearerBlueprint_Id);
            
            CreateTable(
                "dbo.CostPriceEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Cost = c.Single(nullable: false),
                        ComponentType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OpeningEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CoordX = c.Single(nullable: false),
                        CoordY = c.Single(nullable: false),
                        BearerBlueprint_Id = c.Guid(nullable: false),
                        Template_Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlueprintEntities", t => t.BearerBlueprint_Id, cascadeDelete: true)
                .ForeignKey("dbo.OpeningTemplateEntities", t => t.Template_Name, cascadeDelete: true)
                .Index(t => t.BearerBlueprint_Id)
                .Index(t => t.Template_Name);
            
            CreateTable(
                "dbo.OpeningTemplateEntities",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Id = c.Guid(nullable: false, identity: true),
                        Height = c.Single(nullable: false),
                        Length = c.Single(nullable: false),
                        HeightAboveFloor = c.Single(nullable: false),
                        ComponentType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.SignatureEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SignerName = c.String(),
                        SignerSurname = c.String(),
                        SignerUserName = c.String(),
                        SignatureDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BlueprintSigned_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlueprintEntities", t => t.BlueprintSigned_Id, cascadeDelete: true)
                .Index(t => t.Id, unique: true)
                .Index(t => t.BlueprintSigned_Id);
            
            CreateTable(
                "dbo.WallEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Height = c.Single(nullable: false),
                        Width = c.Single(nullable: false),
                        BeginningX = c.Single(nullable: false),
                        BeginningY = c.Single(nullable: false),
                        EndX = c.Single(nullable: false),
                        EndY = c.Single(nullable: false),
                        BearerBlueprint_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlueprintEntities", t => t.BearerBlueprint_Id, cascadeDelete: true)
                .Index(t => t.BearerBlueprint_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WallEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities");
            DropForeignKey("dbo.SignatureEntities", "BlueprintSigned_Id", "dbo.BlueprintEntities");
            DropForeignKey("dbo.OpeningEntities", "Template_Name", "dbo.OpeningTemplateEntities");
            DropForeignKey("dbo.OpeningEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities");
            DropForeignKey("dbo.ColumnEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities");
            DropForeignKey("dbo.BlueprintEntities", "Owner_UserName", "dbo.UserEntities");
            DropIndex("dbo.WallEntities", new[] { "BearerBlueprint_Id" });
            DropIndex("dbo.SignatureEntities", new[] { "BlueprintSigned_Id" });
            DropIndex("dbo.SignatureEntities", new[] { "Id" });
            DropIndex("dbo.OpeningTemplateEntities", new[] { "Name" });
            DropIndex("dbo.OpeningEntities", new[] { "Template_Name" });
            DropIndex("dbo.OpeningEntities", new[] { "BearerBlueprint_Id" });
            DropIndex("dbo.ColumnEntities", new[] { "BearerBlueprint_Id" });
            DropIndex("dbo.UserEntities", new[] { "UserName" });
            DropIndex("dbo.BlueprintEntities", new[] { "Owner_UserName" });
            DropIndex("dbo.BlueprintEntities", new[] { "Id" });
            DropTable("dbo.WallEntities");
            DropTable("dbo.SignatureEntities");
            DropTable("dbo.OpeningTemplateEntities");
            DropTable("dbo.OpeningEntities");
            DropTable("dbo.CostPriceEntities");
            DropTable("dbo.ColumnEntities");
            DropTable("dbo.UserEntities");
            DropTable("dbo.BlueprintEntities");
        }
    }
}
