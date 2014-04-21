using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using imgcrv.Business.Services;

namespace imgcrv.Presentation.Web.Controllers
{
    public class DisplayTimeController : Controller
    {
        //
        // GET: /DisplayTime/

        public ActionResult Index()
        {
            FileHandlerService Fhandler = new FileHandlerService();
            ViewData["CurrentTime"] = DateTime.Now.ToString();
            ViewData["Random Name"] = Fhandler.GenerateRandomName();
            return View();
        }



    }
}
