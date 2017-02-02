using System.Data.SqlClient;
using System.Globalization;
using System.IO;
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

        public ActionResult Import()
        {
            return View();
        }

        public ActionResult ImportFile()
        {
            foreach (string upload in Request.Files)
            {
                var httpPostedFileBase = Request.Files[upload];
                if (httpPostedFileBase == null) continue;
                var fileStream = httpPostedFileBase.InputStream;
                var fileLength = httpPostedFileBase.ContentLength;
                var fileData = new byte[fileLength];
                fileStream.Read(fileData, 0, fileLength);

                var wrapper = new CsvWrapper(
                new CommonRepository(new RepositoryContext()),
                new CsvHelper(),
                new CsvZipper());

                wrapper.Import(fileData);

            }

            return RedirectToAction("Login","Start");
        }
    }
}