namespace ClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnCascadeMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Professor", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.Specialization", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.Schedule", "ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.Schedule", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Result", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectSpecialization", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Result", "EntrantId", "dbo.Entrant");
            DropForeignKey("dbo.SubjectSpecialization", "SpecializationId", "dbo.Specialization");
            AddForeignKey("dbo.Professor", "DepartamentId", "dbo.Departament", "Id");
            AddForeignKey("dbo.Specialization", "DepartamentId", "dbo.Departament", "Id");
            AddForeignKey("dbo.Schedule", "ProfessorId", "dbo.Professor", "Id");
            AddForeignKey("dbo.Schedule", "SubjectId", "dbo.Subject", "Id");
            AddForeignKey("dbo.Result", "SubjectId", "dbo.Subject", "Id");
            AddForeignKey("dbo.SubjectSpecialization", "SubjectId", "dbo.Subject", "Id");
            AddForeignKey("dbo.Result", "EntrantId", "dbo.Entrant", "Id");
            AddForeignKey("dbo.SubjectSpecialization", "SpecializationId", "dbo.Specialization", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectSpecialization", "SpecializationId", "dbo.Specialization");
            DropForeignKey("dbo.Result", "EntrantId", "dbo.Entrant");
            DropForeignKey("dbo.SubjectSpecialization", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Result", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Schedule", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Schedule", "ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.Specialization", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.Professor", "DepartamentId", "dbo.Departament");
            AddForeignKey("dbo.SubjectSpecialization", "SpecializationId", "dbo.Specialization", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Result", "EntrantId", "dbo.Entrant", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectSpecialization", "SubjectId", "dbo.Subject", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Result", "SubjectId", "dbo.Subject", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Schedule", "SubjectId", "dbo.Subject", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Schedule", "ProfessorId", "dbo.Professor", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Specialization", "DepartamentId", "dbo.Departament", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Professor", "DepartamentId", "dbo.Departament", "Id", cascadeDelete: true);
        }
    }
}
