using GrabCarMVC.Models;
using GrabCarMVC.Models.ViewModels;
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
            //FareChartVM f = new FareChartVM();
            //var model=db.FairCharts.Join
            //          db.ServiceTypes

            var model = (from fc in db.FairCharts
                        join t in db.ServiceTypes on fc.ServiceType equals t.id
                        join s in db.ServiceTimeSlots on fc.TimeSlot equals s.id

                        select new FareChartVM
                        {
                            ServiceType1 = t.ServiceType1,
                            TimeSlot=s.TimeSlot,
                            PickUp=fc.PickUp,
                            PerKiloCost=fc.PerKiloCost
                        }).ToList();

            return PartialView(model);

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