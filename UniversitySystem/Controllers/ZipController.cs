using System.Net.Mime;
using System.Web.Mvc;
using ClassLibrary;
using UniversitySystem.Core.Csvs;
using UniversitySystem.Core.Csvs.Interfaces;

namespace UniversitySystem.Controllers
{
    public class ZipController : Controller
    {
        private readonly ICsvWrapper _wrapper;

        public ZipController( ICsvWrapper csvWrapper)
        {
            _wrapper = csvWrapper;
        }

        public FileResult Export()
        {
            var data = _wrapper.Export();

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