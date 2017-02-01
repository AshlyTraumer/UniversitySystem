using System.IO;
using System.Web.Mvc;
using ClassLibrary;
using UniversitySystem.Core.Csvs;

namespace UniversitySystem.Controllers
{
    public class ZipController : Controller
    {
        public FileResult Export()
        {
            var wrapper = new CsvWrapper(
                new CommonRepository(new RepositoryContext()),
                new CsvHelper(), 
                new CsvZipper());

            var data = wrapper.Export();

            return File(
                data, System.Net.Mime.MediaTypeNames.Application.Zip, "fileZip.zip");

        }
    }
}