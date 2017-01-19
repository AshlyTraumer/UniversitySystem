namespace ClassLibrary.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClassLibrary.RepositoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClassLibrary.RepositoryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Departaments.Add(
                new Departament
                {
                    Title = "������������",
                    Professors = new List<Professor>()
                    {
                        new Professor
                        {
                           Name = "������ �. �."
                        },
                        new Professor
                        {
                            Name = "������ �. �."
                        }
                    },
                    Specializations = new List<Specialization>
                    {
                        new Specialization
                        {
                            Title = "����������",
                            FreeCount = 20,
                            PayCount = 10,
                            SubjectSpecializations = new List<SubjectSpecialization>
                            {
                                new SubjectSpecialization
                                {
                                    Subject = new Subject
                                    {
                                        Title = "�������",
                                        Form = "�������"
                                    }
                                },
                                new SubjectSpecialization
                                {
                                    Subject = new Subject
                                    {
                                        Title = "������� ����",
                                        Form = "��"
                                    }
                                }
                            }

                            }
                        }

                }
                );
        }
    }
}
