using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using imgcrv.Business.Services;
using System.IO;

namespace imgcrv.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            FileHandlerService fileHandler = new FileHandlerService();
            if (file.ContentLength > 0)
            {

                string fileName = fileHandler.GenerateRandomNameAddExtention(Path.GetExtension(file.FileName));
                ViewData["imageName"] = fileName;

                string path = fileHandler.GetOrigninalUploadLocation() + fileName;
                file.SaveAs(path);
                ViewData["originalPath"] = path;


                path = fileHandler.GetCarvedUploadLocation() + fileName;
                file.SaveAs(path);
                ViewData["carvedPath"] = path;
            }

            return RedirectToAction("Index");
        }


        public ActionResult DisplayImage()
        {
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}
