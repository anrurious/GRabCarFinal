using GrabCarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrabCarMVC.Controllers
{
    public class SignUpController : Controller
    {
        private deshConnection db = new deshConnection();
        //
        // GET: /SignUp/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            var model = db.FAQs.Where(x => x.Flag == 2).ToList();

            return View(model);
        
        }
        public ActionResult Final()
        {
            return View();
        }
        public ActionResult PassengerRegistration()
        {
            return View();
        }
	}
}