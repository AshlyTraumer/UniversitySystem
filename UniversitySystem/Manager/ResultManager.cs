using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using ClassLibrary;
using UniversitySystem.Models;

namespace UniversitySystem.Manager
{
    public class ResultManager : BaseManager<Result, ResultModel>
    {
        public ResultManager(RepositoryContext context) :base (context)
        {
        }

        public List<ResultViewModel> Get()
        {
            return Context.Results
                .Select(x => new ResultViewModel
                {
                    Id = x.Id,
                    SubjectTitle = x.Subject.Title,
                    EntrantName = x.Entrant.Name,
                    Points = x.Points
                }).ToList();
        }

        public ResultModel GetById(int id)
        {
            return Context.Results
                .Select(x => new ResultModel
                {
                    Id = x.Id,
                    SubjectId = x.SubjectId,
                    EntrantName = x.Entrant.FirstName,
                    Points = x.Points
                })
                .Single(t => t.Id == id);
            
        }

        public List<DropDownListItem> GetList()
        {
            return Context.Subjects
                .Select(x => new DropDownListItem
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList();
        }

       protected override void Update(Result entity, ResultModel model)
        {
            entity.SubjectId = model.SubjectId;
            entity.Points = model.Points;
        }
    }
}