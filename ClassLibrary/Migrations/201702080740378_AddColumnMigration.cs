namespace ClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Professor", "ExamCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Professor", "ExamCount");
        }
    }
}
