namespace ClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migra2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authorization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(maxLength: 30),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Authorization");
        }
    }
}
