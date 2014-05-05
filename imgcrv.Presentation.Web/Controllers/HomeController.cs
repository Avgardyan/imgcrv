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
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                FileHandlerService fileHandler = new FileHandlerService("~\\Content\\");
                var model = new CarveViewModel();
                model.imageName = fileHandler.GenerateRandomNameAddExtention(Path.GetExtension(file.FileName));
                //string fileName = fileHandler.GenerateRandomNameAddExtention(Path.GetExtension(file.FileName));
                //ViewData["imageName"] = fileName;

                model.originalPath = fileHandler.GetOrigninalUploadLocation() + model.imageName;
                model.displayPath = fileHandler.GetOrigninalUploadLocation() + model.imageName;
                //string path = fileHandler.GetOrigninalUploadLocation() + fileName;
                //file.SaveAs(path);
                //ViewData["originalPath"] = path;
                file.SaveAs(Server.MapPath(model.originalPath));


                /*
                ImageMagick.MagickImage image = new ImageMagick.MagickImage(path);

                ImageMagick.Percentage wp = 80, hp = 100;
                ImageMagick.MagickGeometry geom = new ImageMagick.MagickGeometry(wp, hp);
                image.LiquidRescale(geom);
                image.Write(path);
                */

                //path = fileHandler.GetCarvedUploadLocation() + fileName;
                model.carvedPath = fileHandler.GetCarvedUploadLocation() + model.imageName;
                file.SaveAs(Server.MapPath(model.carvedPath));

                //ImageHandlerService imageHandler = new ImageHandlerService();
                //file.SaveAs(path);
                //int width;
                //int.TryParse(Request["width"].ToString(), out width);
                //int height;
                //int.TryParse(Request["height"].ToString(), out height);

                //imageHandler.CarveAndSaveImage(path, height, width);
                //ViewData["carvedPath"] = path;
                return RedirectToAction("Carve", model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Carve(CarveViewModel model)
        {
            ImageHandlerService imageHandler = new ImageHandlerService();
            Tuple<int, int> size = imageHandler.ReturnSize(Server.MapPath(model.carvedPath));
            model.imageHeight = size.Item1;
            model.imageWidth = size.Item2;
            return View(model);
        }

        [HttpPost]
        public ActionResult Carve(CarveViewModel model)
        {
            ImageHandlerService imageHandler = new ImageHandlerService();
            imageHandler.CarveAndSaveImage(model.carvedPath, model.imageHeight, model.imageWidth);
            return View(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}
