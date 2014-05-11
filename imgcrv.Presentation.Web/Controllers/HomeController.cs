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
using System.Net;

namespace imgcrv.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db;
        private UserManager<ApplicationUser> manager;
        private FileHandlerService fileHandler;
        ImageHandlerService imageHandler;
        public HomeController() 
        {
            db = new ApplicationDbContext();
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            fileHandler = new FileHandlerService("~\\Content\\");
            imageHandler = new ImageHandlerService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                Image image = new Image();
                string name;
                name = fileHandler.GenerateRandomNameAddExtention(Path.GetExtension(file.FileName));
                image.originalPath = fileHandler.GetOrigninalUploadLocation() + name;
                file.SaveAs(Server.MapPath(image.originalPath));
                image.carvedPath = fileHandler.GetCarvedUploadLocation() + name;
                file.SaveAs(Server.MapPath(image.carvedPath));
                image.UploadedAt = DateTime.Now;
                var currentUser = manager.FindById(User.Identity.GetUserId());
                image.User = currentUser;
                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("Display","Home", new { id = image.Id });
            }

            return RedirectToAction("Index");
        }

        public ActionResult Display(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            Tuple<int, int> size = imageHandler.ReturnSize(Server.MapPath(image.carvedPath));
            var model =  new CarveViewModel();
            model.Id = image.Id;
            model.imageHeight = size.Item1;
            model.imageWidth = size.Item2;
            model.displayPath = image.carvedPath;
            return View(model);
        }

        [HttpPost]
        public ActionResult Carve(CarveViewModel model)
        {
            if (model.Id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(model.Id);
            if (image == null)
            {
                return HttpNotFound();
            }
            imageHandler.CarveAndSaveImage(Server.MapPath(image.carvedPath), model.imageHeight, model.imageWidth);
            return RedirectToAction("Display", "Home", new { id = model.Id });
        }

        public ActionResult Reset(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            imageHandler.ResetCarvedToOriginal(image.originalPath, image.carvedPath);
            return RedirectToAction("Display", "Home", new { id = image.Id });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}
