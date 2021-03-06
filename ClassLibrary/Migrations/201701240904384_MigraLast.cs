namespace ClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigraLast : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departament",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        DepartamentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departament", t => t.DepartamentId)
                .Index(t => t.DepartamentId);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Classroom = c.String(),
                        Date = c.DateTime(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        ProfessorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .ForeignKey("dbo.Professor", t => t.ProfessorId)
                .Index(t => t.SubjectId)
                .Index(t => t.ProfessorId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 30),
                        Form = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Result",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        EntrantId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entrant", t => t.EntrantId)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => new { t.EntrantId, t.SubjectId }, unique: true, name: "IX_EntrantSubject");
            
            CreateTable(
                "dbo.Entrant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Passport = c.String(nullable: false, maxLength: 10),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectSpecialization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        SpecializationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specialization", t => t.SpecializationId)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => new { t.SpecializationId, t.SubjectId }, unique: true, name: "IX_SubjectSpecialization");
            
            CreateTable(
                "dbo.Specialization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        FreeCount = c.Int(nullable: false),
                        PayCount = c.Int(nullable: false),
                        DepartamentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departament", t => t.DepartamentId)
                .Index(t => t.DepartamentId);
            
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
            DropForeignKey("dbo.Specialization", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.Professor", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.Schedule", "ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.SubjectSpecialization", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectSpecialization", "SpecializationId", "dbo.Specialization");
            DropForeignKey("dbo.Schedule", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Result", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Result", "EntrantId", "dbo.Entrant");
            DropIndex("dbo.Specialization", new[] { "DepartamentId" });
            DropIndex("dbo.SubjectSpecialization", "IX_SubjectSpecialization");
            DropIndex("dbo.Result", "IX_EntrantSubject");
            DropIndex("dbo.Schedule", new[] { "ProfessorId" });
            DropIndex("dbo.Schedule", new[] { "SubjectId" });
            DropIndex("dbo.Professor", new[] { "DepartamentId" });
            DropTable("dbo.Authorization");
            DropTable("dbo.Specialization");
            DropTable("dbo.SubjectSpecialization");
            DropTable("dbo.Entrant");
            DropTable("dbo.Result");
            DropTable("dbo.Subject");
            DropTable("dbo.Schedule");
            DropTable("dbo.Professor");
            DropTable("dbo.Departament");
        }
    }
}
