namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredBlueprintForMaterials : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ColumnEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities");
            DropForeignKey("dbo.OpeningEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities");
            DropForeignKey("dbo.WallEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities");
            DropIndex("dbo.ColumnEntities", new[] { "BearerBlueprint_Id" });
            DropIndex("dbo.OpeningEntities", new[] { "BearerBlueprint_Id" });
            DropIndex("dbo.WallEntities", new[] { "BearerBlueprint_Id" });
            AlterColumn("dbo.ColumnEntities", "BearerBlueprint_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.OpeningEntities", "BearerBlueprint_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.WallEntities", "BearerBlueprint_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.ColumnEntities", "BearerBlueprint_Id");
            CreateIndex("dbo.OpeningEntities", "BearerBlueprint_Id");
            CreateIndex("dbo.WallEntities", "BearerBlueprint_Id");
            AddForeignKey("dbo.ColumnEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OpeningEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WallEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WallEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities");
            DropForeignKey("dbo.OpeningEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities");
            DropForeignKey("dbo.ColumnEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities");
            DropIndex("dbo.WallEntities", new[] { "BearerBlueprint_Id" });
            DropIndex("dbo.OpeningEntities", new[] { "BearerBlueprint_Id" });
            DropIndex("dbo.ColumnEntities", new[] { "BearerBlueprint_Id" });
            AlterColumn("dbo.WallEntities", "BearerBlueprint_Id", c => c.Guid());
            AlterColumn("dbo.OpeningEntities", "BearerBlueprint_Id", c => c.Guid());
            AlterColumn("dbo.ColumnEntities", "BearerBlueprint_Id", c => c.Guid());
            CreateIndex("dbo.WallEntities", "BearerBlueprint_Id");
            CreateIndex("dbo.OpeningEntities", "BearerBlueprint_Id");
            CreateIndex("dbo.ColumnEntities", "BearerBlueprint_Id");
            AddForeignKey("dbo.WallEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities", "Id");
            AddForeignKey("dbo.OpeningEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities", "Id");
            AddForeignKey("dbo.ColumnEntities", "BearerBlueprint_Id", "dbo.BlueprintEntities", "Id");
        }
    }
}
