namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contextChange : DbMigration
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
                        LastSignDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Owner_Id = c.Guid(),
                        Signature_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserEntities", t => t.Owner_Id)
                .ForeignKey("dbo.UserEntities", t => t.Signature_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Signature_Id);
            
            CreateTable(
                "dbo.WallEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Height = c.Single(nullable: false),
                        Width = c.Single(nullable: false),
                        Blueprint_Id = c.Guid(),
                        From_Id = c.Guid(),
                        To_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlueprintEntities", t => t.Blueprint_Id)
                .ForeignKey("dbo.PointEntities", t => t.From_Id)
                .ForeignKey("dbo.PointEntities", t => t.To_Id)
                .Index(t => t.Blueprint_Id)
                .Index(t => t.From_Id)
                .Index(t => t.To_Id);
            
            CreateTable(
                "dbo.PointEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CoordX = c.Single(nullable: false),
                        CoordY = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WallEntities", "To_Id", "dbo.PointEntities");
            DropForeignKey("dbo.WallEntities", "From_Id", "dbo.PointEntities");
            DropForeignKey("dbo.WallEntities", "Blueprint_Id", "dbo.BlueprintEntities");
            DropForeignKey("dbo.BlueprintEntities", "Signature_Id", "dbo.UserEntities");
            DropForeignKey("dbo.BlueprintEntities", "Owner_Id", "dbo.UserEntities");
            DropIndex("dbo.WallEntities", new[] { "To_Id" });
            DropIndex("dbo.WallEntities", new[] { "From_Id" });
            DropIndex("dbo.WallEntities", new[] { "Blueprint_Id" });
            DropIndex("dbo.BlueprintEntities", new[] { "Signature_Id" });
            DropIndex("dbo.BlueprintEntities", new[] { "Owner_Id" });
            DropTable("dbo.PointEntities");
            DropTable("dbo.WallEntities");
            DropTable("dbo.BlueprintEntities");
        }
    }
}
