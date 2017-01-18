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
            Subject subject = new Subject
            {
                Title = "История Беларуси",
                Form = "Экзамен"
            };

            context.Departaments.AddOrUpdate
            (
                new Departament
                {
                    Title = "Исторический",
                    Professors = new List<Professor>
                    {
                      new Professor { Name = "Иванов И. И" },
                      new Professor { Name = "Петров Г. Г." }
                    },
                    Specializations = new List<Specialization>
                    {
                        new Specialization
                        {
                            Title = "Археология",
                            PayCount = 20,
                            FreeCount = 10,
                            Subjects = new List<Subject>
                            {
                                new Subject
                                {
                                    Title = "Всемирная история",
                                    Form = "ЦТ"
                                },
                                subject
                            }
                        }
                    }
                },
                new Departament
                {
                    Title = "Филологический",
                    Specializations = new List<Specialization>
                    {
                        new Specialization
                        {
                            Title = "Переводчик",
                            FreeCount = 12,
                            PayCount = 14,
                            Subjects = new List<Subject>
                            {
                                subject,
                                new Subject
                                {
                                    Title = "Русский язык",
                                    Form = "Экзамен"
                                }

                            }
                        }
                    }
                }
            );

            context.Subjects.AddOrUpdate(
                new Subject
                {
                    Title = "Математика",
                    Form = "ЦТ"
                }
            );
            //
        }
    }
}
