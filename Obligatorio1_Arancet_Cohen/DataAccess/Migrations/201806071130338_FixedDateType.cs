namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedDateType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserEntities", "RegistrationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.UserEntities", "LastLoginDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserEntities", "LastLoginDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserEntities", "RegistrationDate", c => c.DateTime(nullable: false));
        }
    }
}
