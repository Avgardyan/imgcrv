﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using imgcrv.Business.Services;
using System.IO;
using imgcrv.Data.DataEntities.Dto;

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

            FileHandlerService fileHandler = new FileHandlerService(Server.MapPath("~/App_Data/"));
            if (file.ContentLength > 0)
            {

                string fileName = fileHandler.GenerateRandomNameAddExtention(Path.GetExtension(file.FileName));
                ViewData["imageName"] = fileName;

                string path = fileHandler.GetOrigninalUploadLocation() + fileName;
                file.SaveAs(path);
                ViewData["originalPath"] = path;


                /*
                ImageMagick.MagickImage image = new ImageMagick.MagickImage(path);

                ImageMagick.Percentage wp = 80, hp = 100;
                ImageMagick.MagickGeometry geom = new ImageMagick.MagickGeometry(wp, hp);
                image.LiquidRescale(geom);
                image.Write(path);
                */

                path = fileHandler.GetCarvedUploadLocation() + fileName;

                ImageHandlerService imageHandler = new ImageHandlerService();
                file.SaveAs(path);
                int width;
                int.TryParse(Request["width"].ToString(), out width);
                int height;
                int.TryParse(Request["height"].ToString(), out height);

                imageHandler.CarveAndSaveImage(path, height, width);
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
