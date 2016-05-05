using GrabCarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrabCarMVC.Controllers
{
    public class HomeController : Controller
    {
        private deshConnection db = new deshConnection();
        public ActionResult Index()
        {
            TempData["HomeText"] = "Ankur";
            TempData["HomeText"] = db.HomePages.First().HomeText;
            return View();
        }

        public ActionResult FareChart()
        {
            return PartialView();
        }

        public ActionResult Faq()
        {
            var model = db.FAQs.Where(x => x.Flag == 1).ToList();

           // return View(model);

            return PartialView(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}