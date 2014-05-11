using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using imgcrv.Presentation.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IO;

namespace imgcrv.Presentation.Web.Controllers
{
    public class ImageController : Controller
    {
        private ApplicationDbContext db;
        private UserManager<ApplicationUser> manager;
        public ImageController()
        {
            db = new ApplicationDbContext();
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }
        // GET: /Image/
        public ActionResult Index()
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (currentUser == null) return View(db.Images.ToList().Where((image => image.User == null)));
            return View(db.Images.ToList().Where((image => image.User.Id == currentUser.Id)));
        }

        public ActionResult Download(string fileName)
        {
            try
            {
                var fs = System.IO.File.OpenRead(Server.MapPath(fileName));
                return File(fs, "application/zip", Path.GetFileName(fileName));
            }
            catch
            {
                throw new HttpException(404, "Couldn't find " + Path.GetFileName(fileName));
            }
        }

        // GET: /Image/Delete/5
        public ActionResult Delete(int? id)
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
            return View(image);
        }

        // POST: /Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
