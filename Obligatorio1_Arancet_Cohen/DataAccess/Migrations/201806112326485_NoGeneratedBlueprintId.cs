namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoGeneratedBlueprintId : DbMigration
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
                        Owner_UserName = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserEntities", t => t.Owner_UserName)
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
                "dbo.SignatureEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        SignatureDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Signer_UserName = c.String(maxLength: 100, unicode: false),
                        BlueprintEntity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserEntities", t => t.Signer_UserName)
                .ForeignKey("dbo.BlueprintEntities", t => t.BlueprintEntity_Id)
                .Index(t => t.Signer_UserName)
                .Index(t => t.BlueprintEntity_Id);
            
            CreateTable(
                "dbo.ColumnEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Width = c.Single(nullable: false),
                        Length = c.Single(nullable: false),
                        Height = c.Single(nullable: false),
                        BearerBlueprint_Id = c.Guid(),
                        Position_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlueprintEntities", t => t.BearerBlueprint_Id)
                .ForeignKey("dbo.PointEntities", t => t.Position_Id)
                .Index(t => t.BearerBlueprint_Id)
                .Index(t => t.Position_Id);
            
            CreateTable(
                "dbo.PointEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CoordX = c.Single(nullable: false),
                        CoordY = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        BearerBlueprint_Id = c.Guid(),
                        Position_Id = c.Guid(),
                        Template_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlueprintEntities", t => t.BearerBlueprint_Id)
                .ForeignKey("dbo.PointEntities", t => t.Position_Id)
                .ForeignKey("dbo.OpeningTemplateEntities", t => t.Template_Id)
                .Index(t => t.BearerBlueprint_Id)
                .Index(t => t.Position_Id)
                .Index(t => t.Template_Id);
            
            CreateTable(
                "dbo.OpeningTemplateEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Height = c.Single(nullable: false),
                        Length = c.Single(nullable: false),
                        HeightAboveFloor = c.Single(nullable: false),
                        Name = c.String(),
                        ComponentType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WallEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Height = c.Single(nullable: false),
                        Width = c.Single(nullable: false),
                        BearerBlueprint_Id = c.Guid(),
                        From_Id = c.Guid(),
                        To_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlueprintEntities", t => t.BearerBlueprint_Id)
                .ForeignKey("dbo.PointEntities", t => t.From_Id)
                .ForeignKey("dbo.PointEntities", t => t.To_Id)
                .Index(t => t.BearerBlueprint_Id)
                .Index(t => t.From_Id)
                .Index(t => t.To_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WallEntities", "To_Id", "dbo.PointEntities");
            DropForeignKey("dbo.WallEntities", "From_Id", "dbo.PointEntities");
            DropForeignKey("dbo.WallEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities");
            DropForeignKey("dbo.OpeningEntities", "Template_Id", "dbo.OpeningTemplateEntities");
            DropForeignKey("dbo.OpeningEntities", "Position_Id", "dbo.PointEntities");
            DropForeignKey("dbo.OpeningEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities");
            DropForeignKey("dbo.ColumnEntities", "Position_Id", "dbo.PointEntities");
            DropForeignKey("dbo.ColumnEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities");
            DropForeignKey("dbo.SignatureEntities", "BlueprintEntity_Id", "dbo.BlueprintEntities");
            DropForeignKey("dbo.SignatureEntities", "Signer_UserName", "dbo.UserEntities");
            DropForeignKey("dbo.BlueprintEntities", "Owner_UserName", "dbo.UserEntities");
            DropIndex("dbo.WallEntities", new[] { "To_Id" });
            DropIndex("dbo.WallEntities", new[] { "From_Id" });
            DropIndex("dbo.WallEntities", new[] { "BearerBlueprint_Id" });
            DropIndex("dbo.OpeningEntities", new[] { "Template_Id" });
            DropIndex("dbo.OpeningEntities", new[] { "Position_Id" });
            DropIndex("dbo.OpeningEntities", new[] { "BearerBlueprint_Id" });
            DropIndex("dbo.ColumnEntities", new[] { "Position_Id" });
            DropIndex("dbo.ColumnEntities", new[] { "BearerBlueprint_Id" });
            DropIndex("dbo.SignatureEntities", new[] { "BlueprintEntity_Id" });
            DropIndex("dbo.SignatureEntities", new[] { "Signer_UserName" });
            DropIndex("dbo.UserEntities", new[] { "UserName" });
            DropIndex("dbo.BlueprintEntities", new[] { "Owner_UserName" });
            DropIndex("dbo.BlueprintEntities", new[] { "Id" });
            DropTable("dbo.WallEntities");
            DropTable("dbo.OpeningTemplateEntities");
            DropTable("dbo.OpeningEntities");
            DropTable("dbo.CostPriceEntities");
            DropTable("dbo.PointEntities");
            DropTable("dbo.ColumnEntities");
            DropTable("dbo.SignatureEntities");
            DropTable("dbo.UserEntities");
            DropTable("dbo.BlueprintEntities");
        }
    }
}
