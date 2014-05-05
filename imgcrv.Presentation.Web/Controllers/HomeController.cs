using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using imgcrv.Business.Services;
using System.IO;
using imgcrv.Data.DataEntities.Dto;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using imgcrv.Presentation.Web.Models;

namespace imgcrv.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string submitButton)
        {
            if (file != null && file.ContentLength > 0)
            {
                FileHandlerService fileHandler = new FileHandlerService("~\\Content\\");
                var model = new CarveViewModel();
                model.imageName = fileHandler.GenerateRandomNameAddExtention(Path.GetExtension(file.FileName));
                model.originalPath = fileHandler.GetOrigninalUploadLocation() + model.imageName;
                file.SaveAs(Server.MapPath(model.originalPath));
                model.carvedPath = fileHandler.GetCarvedUploadLocation() + model.imageName;
                file.SaveAs(Server.MapPath(model.carvedPath));
                model.displayPath = fileHandler.GetCarvedUploadLocation() + model.imageName;
                
                return RedirectToAction("Carve", model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Carve(CarveViewModel model, string submitButton)
        {
            if (submitButton == "Carve")
            {
                ImageHandlerService imageHandler = new ImageHandlerService();
                imageHandler.CarveAndSaveImage(model.carvedPath, model.imageHeight, model.imageWidth);
                
            }
            else if (submitButton == "Reset")
            {
                ImageHandlerService imageHandler = new ImageHandlerService();
                imageHandler.ResetCarvedToOriginal(model.originalPath, model.carvedPath);
                
                submitButton = null;
            }

            //Method goes here if photo has just been uploaded or reset
            if (submitButton == null)
            {
                ImageHandlerService imageHandler = new ImageHandlerService();
                Tuple<int, int> size = imageHandler.ReturnSize(Server.MapPath(model.carvedPath));
                model.imageHeight = size.Item1;
                model.imageWidth = size.Item2;
            }
            
            return View(model);
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}
