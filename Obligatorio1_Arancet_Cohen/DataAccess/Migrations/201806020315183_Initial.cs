namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Agenda_Id", "dbo.Agenda");
            DropForeignKey("dbo.Agenda", "Owner_Id", "dbo.Users");
            DropIndex("dbo.Agenda", new[] { "Owner_Id" });
            DropIndex("dbo.Users", new[] { "Agenda_Id" });
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Agenda");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Agenda_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Owner_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.UserEntities");
            CreateIndex("dbo.Users", "Agenda_Id");
            CreateIndex("dbo.Agenda", "Owner_Id");
            AddForeignKey("dbo.Agenda", "Owner_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Agenda_Id", "dbo.Agenda", "Id");
        }
    }
}
