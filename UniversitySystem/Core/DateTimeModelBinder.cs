using System.Web.Mvc;
using UniversitySystem.Models;


namespace UniversitySystem.Core
{
    public class DateTimeModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(ScheduleModel))
            {
                var request = controllerContext.HttpContext.Request;

                return new ScheduleModel
                {
                    Classroom = request.Form.Get("ClassRoom"),
                    ProfessorId = int.Parse(request.Form.Get("ProfessorId")),
                    SubjectId = int.Parse(request.Form.Get("SubjectId")),
                    Date = string.Join(".", new []{ request.Form.Get("Day"), request.Form.Get("Month"), request.Form.Get("Year") })
                };
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }

    }
}