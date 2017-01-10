using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public ActionResult Index()
        {
            Customer customer = new Customer() { Age=00,Name="OK"};

            // Получить данные из формы с помощью средств
            // привязки моделей ASP.NET
          //  IValueProvider provider =
          //      new FormValueProvider(ModelBindingExecutionContext);
         //   if (TryUpdateModel<Customer>(customer, provider))
            {
                
                // В этой точке непосредственно начинается работа с Entity Framework

                // Создать объект контекста
                SampleContext context = new SampleContext();
                
                // Вставить данные в таблицу Customers с помощью LINQ
                context.Customers.Add(customer);

                // Сохранить изменения в БД
                context.SaveChanges();
            }
                return View();
        }
    }
}