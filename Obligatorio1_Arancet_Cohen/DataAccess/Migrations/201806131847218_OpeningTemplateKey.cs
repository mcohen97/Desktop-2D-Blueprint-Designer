namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OpeningTemplateKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OpeningEntities", "Template_Id", "dbo.OpeningTemplateEntities");
            DropIndex("dbo.OpeningEntities", new[] { "Template_Id" });
            RenameColumn(table: "dbo.OpeningEntities", name: "Template_Id", newName: "Template_Name");
            DropPrimaryKey("dbo.OpeningTemplateEntities");
            AlterColumn("dbo.OpeningEntities", "Template_Name", c => c.String(maxLength: 128));
            AlterColumn("dbo.OpeningTemplateEntities", "Name", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.OpeningTemplateEntities", "Name");
            CreateIndex("dbo.OpeningEntities", "Template_Name");
            CreateIndex("dbo.OpeningTemplateEntities", "Name", unique: true);
            AddForeignKey("dbo.OpeningEntities", "Template_Name", "dbo.OpeningTemplateEntities", "Name");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OpeningEntities", "Template_Name", "dbo.OpeningTemplateEntities");
            DropIndex("dbo.OpeningTemplateEntities", new[] { "Name" });
            DropIndex("dbo.OpeningEntities", new[] { "Template_Name" });
            DropPrimaryKey("dbo.OpeningTemplateEntities");
            AlterColumn("dbo.OpeningTemplateEntities", "Name", c => c.String());
            AlterColumn("dbo.OpeningEntities", "Template_Name", c => c.Guid());
            AddPrimaryKey("dbo.OpeningTemplateEntities", "Id");
            RenameColumn(table: "dbo.OpeningEntities", name: "Template_Name", newName: "Template_Id");
            CreateIndex("dbo.OpeningEntities", "Template_Id");
            AddForeignKey("dbo.OpeningEntities", "Template_Id", "dbo.OpeningTemplateEntities", "Id");
        }
    }
}
