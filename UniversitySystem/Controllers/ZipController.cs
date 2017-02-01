using System.Globalization;
using System.Net.Mime;
using System.Threading;
using System.Web.Mvc;
using ClassLibrary;
using UniversitySystem.Core.Csvs;

namespace UniversitySystem.Controllers
{
    public class ZipController : Controller
    {
        public FileResult Export()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB",true);
            var wrapper = new CsvWrapper(
                new CommonRepository(new RepositoryContext()),
                new CsvHelper(), 
                new CsvZipper());

            var data = wrapper.Export();

            return File(data, MediaTypeNames.Application.Zip, "fileZip.zip");

        }
    }
}