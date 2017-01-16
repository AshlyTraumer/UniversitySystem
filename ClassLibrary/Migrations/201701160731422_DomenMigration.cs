namespace ClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DomenMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subject", "Form", c => c.String());
            AlterColumn("dbo.Entrant", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Entrant", "DateOfBirth", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Subject", "Form", c => c.String(maxLength: 30));
        }
    }
}
