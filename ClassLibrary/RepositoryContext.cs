using ClassLibrary.Authorization;
using System;
using System.Collections.Generic;
using System.Data.Entity;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext() : base("UniversitySystem")
        {
          
        }      
               
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Entrant> Entrants { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectSpecialization> SubjectsSpecialization { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartamentConfiguration());
            modelBuilder.Configurations.Add(new EnrollmentConfiguration());
            modelBuilder.Configurations.Add(new EntrantConfiguration());
            modelBuilder.Configurations.Add(new ProfessorConfiguration());
            modelBuilder.Configurations.Add(new ResultConfiguration());
            modelBuilder.Configurations.Add(new ScheduleConfiguration());
            modelBuilder.Configurations.Add(new SpecializationConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
            modelBuilder.Configurations.Add(new SubjectSpecializationConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
