namespace ClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migra : DbMigration
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
                .ForeignKey("dbo.Departament", t => t.DepartamentId, cascadeDelete: true)
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
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Professor", t => t.ProfessorId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.ProfessorId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 30),
                        Form = c.String(maxLength: 30),
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
                .ForeignKey("dbo.Entrant", t => t.EntrantId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.EntrantId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Entrant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Passport = c.String(nullable: false, maxLength: 10),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                        EnrollmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enrollment", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        RegistrationStatus = c.Int(nullable: false),
                        EntrantId = c.Int(nullable: false),
                        SpecializationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specialization", t => t.SpecializationId, cascadeDelete: true)
                .Index(t => t.SpecializationId);
            
            CreateTable(
                "dbo.Specialization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        freeCount = c.Int(nullable: false),
                        payCount = c.Int(nullable: false),
                        DepartamentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departament", t => t.DepartamentId, cascadeDelete: true)
                .Index(t => t.DepartamentId);
            
            CreateTable(
                "dbo.SpecializationSubjects",
                c => new
                    {
                        Specialization_Id = c.Int(nullable: false),
                        Subject_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Specialization_Id, t.Subject_Id })
                .ForeignKey("dbo.Specialization", t => t.Specialization_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.Subject_Id, cascadeDelete: true)
                .Index(t => t.Specialization_Id)
                .Index(t => t.Subject_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Specialization", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.Professor", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.Schedule", "ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.Schedule", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Result", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Result", "EntrantId", "dbo.Entrant");
            DropForeignKey("dbo.Enrollment", "SpecializationId", "dbo.Specialization");
            DropForeignKey("dbo.SpecializationSubjects", "Subject_Id", "dbo.Subject");
            DropForeignKey("dbo.SpecializationSubjects", "Specialization_Id", "dbo.Specialization");
            DropForeignKey("dbo.Entrant", "Id", "dbo.Enrollment");
            DropIndex("dbo.SpecializationSubjects", new[] { "Subject_Id" });
            DropIndex("dbo.SpecializationSubjects", new[] { "Specialization_Id" });
            DropIndex("dbo.Specialization", new[] { "DepartamentId" });
            DropIndex("dbo.Enrollment", new[] { "SpecializationId" });
            DropIndex("dbo.Entrant", new[] { "Id" });
            DropIndex("dbo.Result", new[] { "SubjectId" });
            DropIndex("dbo.Result", new[] { "EntrantId" });
            DropIndex("dbo.Schedule", new[] { "ProfessorId" });
            DropIndex("dbo.Schedule", new[] { "SubjectId" });
            DropIndex("dbo.Professor", new[] { "DepartamentId" });
            DropTable("dbo.SpecializationSubjects");
            DropTable("dbo.Specialization");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Entrant");
            DropTable("dbo.Result");
            DropTable("dbo.Subject");
            DropTable("dbo.Schedule");
            DropTable("dbo.Professor");
            DropTable("dbo.Departament");
        }
    }
}
