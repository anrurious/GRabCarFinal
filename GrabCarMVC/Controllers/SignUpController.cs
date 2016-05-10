using GrabCarMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user_driver user_driver, FormCollection fc, List<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file == null)
                {
                    return View();
                }
            }

            int fName = 10;

            string finalFileName = "";
            string dt = DateTime.Now.ToString("yyyyMMddHHmmss");
            //user_driver.picture = files[0].FileName;

           

            var xy="";
            var photopath = "D:/ICSE/x/";

            #region WorkWithImages

            foreach (var file in files)
            {
                if (file==files[0])
                {
                    xy = "pho";
                    finalFileName = xy + dt + fName.ToString();
                    user_driver.picture = finalFileName;
                }

                if (file == files[1])
                {
                    xy = "lic";
                    finalFileName = xy + dt + fName.ToString();
                    user_driver.license_image = finalFileName;
                }

                if (file == files[2])
                {
                    xy = "nid";
                    finalFileName = xy + dt + fName.ToString();
                    user_driver.nid_image = finalFileName;
                }

                if (file == files[3])
                {
                    xy = "brt";
                    finalFileName = xy + dt + fName.ToString();
                    user_driver.brtc_image = finalFileName;
                }

                if (file == files[4])
                {
                    xy = "ins";
                    finalFileName = xy + dt + fName.ToString();
                    user_driver.insurance_image = finalFileName;
                }
                

                if (file.ContentLength > 0)
                {
                    if (file.ContentType == "image/jpeg")
                    {
                        finalFileName = finalFileName + ".jpg";
                    }
                    if (file.ContentType == "image/gif")
                    {
                        finalFileName = finalFileName + ".gif";
                    }

                    if (file.ContentType == "image/png")
                    {
                        finalFileName = finalFileName + ".png";
                    }

                    //Again Updating DB fields
                    if (file == files[0])
                    {
                        user_driver.picture = finalFileName;
                    }

                    if (file == files[1])
                    {
                        user_driver.license_image = finalFileName;
                    }

                    if (file == files[2])
                    {                      
                        user_driver.nid_image = finalFileName;
                    }

                    if (file == files[3])
                    {                       
                        user_driver.brtc_image = finalFileName;
                    }

                    if (file == files[4])
                    {                      
                        user_driver.insurance_image = finalFileName;
                    }

                    //Updating DB fields End Here
                    var path = Path.Combine(photopath, finalFileName.ToString());

                    file.SaveAs(path);

                    //string pathSave = "~/Content/Img/" + finalFileName;                 
                    //pi.ImgUrl = finalFileName;
                }
                fName = fName + 1;
            }
            #endregion


            if (ModelState.IsValid)
            {
                user_driver.phone = "01725674880";
                user_driver.first_name = "firstName";
                user_driver.password = "0cc175b9c0f1b6a831c399e269772661";
                user_driver.token = "7e2e6b255d44b8392c24a028a3ff0fb7";

                user_driver.token_expiry = 0;
                user_driver.dog_id = 0;

                user_driver.status = 0;
                db.user_driver.Add(user_driver);
                db.SaveChanges();
                return View();
            }
            
            // var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string user,string pass)
        {
            if (user == "ankur")
            {
                return RedirectToAction("DriverHome", "SignUp", new { id = 1 });
            }
            else
            {
                return View();
            }
        }

        public ActionResult DriverHome(int? id)
        {
            return View();
        }

      
        public ActionResult PassengerRegistration()
        {
            return View();
        }
	}
}