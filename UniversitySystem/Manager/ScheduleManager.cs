using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClassLibrary;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class ScheduleManager : BaseManager<Schedule, ScheduleModel>
    {
        public ScheduleManager(RepositoryContext context) : base (context)
        {
        }

        public List<ScheduleViewModel> Get()
        {
            return Context.Schedules
                .Select(x => new ScheduleViewModel()
                {
                    Id = x.Id,
                    Classroom = x.Classroom,
                    Date = x.Date,
                    ProfessorName = x.Professor.Name,
                    SubjectTitle = x.Subject.Title
                }).ToList();
        }

        public ScheduleModel GetById(int id)
        {
            var schedule = Context.Schedules.Single(x => x.Id == id);

            return new ScheduleModel
            {
                Id = schedule.Id,
                Classroom = schedule.Classroom,
                Date = schedule.Date.ToString("yyyy-MMMM-dd")
            };
        }

        public List<DropDownListItem> GetProfessorList()
        {
            return Context.Professors
                .Select(x => new DropDownListItem
                {
                    Id = x.Id,
                    Title = x.Name
                }).ToList();
        }

        public List<DropDownListItem> GetSubjectList()
        {
            return Context.Subjects
                .Select(x => new DropDownListItem
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList();
        }

        public void Create(ScheduleModel model)
        {
            var schedule = new Schedule
            {
                Date = DateTime.Parse(model.Date),
                Classroom = model.Classroom,
                ProfessorId = model.ProfessorId,
                SubjectId = model.SubjectId
            };

            Context.Schedules.Add(schedule);
            Context.SaveChanges();
        }

        protected override void Update(Schedule entity, ScheduleModel model)
        {
            entity.Date = DateTime.Parse(model.Date);
            entity.Classroom = model.Classroom;
            entity.ProfessorId = model.ProfessorId;
            entity.SubjectId = model.SubjectId;
        }
    }
}