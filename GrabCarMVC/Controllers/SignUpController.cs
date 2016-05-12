using GrabCarMVC.Models;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Routing;
//using Owin;
//using Microsoft.Owin.Security.Cookies;
//using Microsoft.Owin;


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

           // var photopath = "C:/inetpub/wwwroot/deshexpressbd/images/driver/";


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
            if (UserManager(user, pass))
            {
                var ident = new ClaimsIdentity(
                  new[] { 
              // adding following 2 claim just for supporting default antiforgery provider
              new Claim(ClaimTypes.NameIdentifier, user),
              new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),

              new Claim(ClaimTypes.Name,user),

              // optionally you could add roles if any
              new Claim(ClaimTypes.Role, "RoleName"),
              new Claim(ClaimTypes.Role, "AnotherRole"),

             },
                  DefaultAuthenticationTypes.ApplicationCookie);

                HttpContext.GetOwinContext().Authentication.SignIn(
                   new AuthenticationProperties { IsPersistent = false }, ident);

               // return RedirectToAction("DriverHome"); // auth succeed 

                return RedirectToAction("DriverHome", "SignUp", new { id = 4 });

            }
            // invalid username or password
            ModelState.AddModelError("", "invalid username or password");
            return View();
     

            //var result = db.user_driver
            //                .Where(oh => oh.email == user)                            
            //                .Select(oh => new {id = oh.id})
            //                .ToList();

            //if (result.Count>0)
            //{
             //  return RedirectToAction("DriverHome", "SignUp", new { id = result[0].id});
            //}

          
            //else
            //{
            //    return View();
            //}



        }

       
            //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            //  {
            //        // Returns HTTP 401 by default - see HttpUnauthorizedResult.cs.
            //       filterContext.Result = new RedirectToRouteResult(
            //       new RouteValueDictionary 
            //       {
            //          { "action", "YourActionName" },
            //          { "controller", "YourControllerName" },
            //          { "parameterName", "YourParameterValue" }
            //          });
            //  }

            //public void ConfigureAuth(IAppBuilder app)
            //{
            //    app.UseCookieAuthentication(new CookieAuthenticationOptions
            //    {
            //        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //        LoginPath = new PathString("/Home/Index")
            //    });
            //    app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            //}

        private bool UserManager(string username, string password)
        {
            
                
                    // if your users set name is Users
            var result = db.user_driver
                            .Where(oh => oh.email == username)
                            .Select(oh => new { id = oh.id })
                            .ToList();
                if (result.Count > 0)
                {
                    return true;
                }
            else
                {
                    return false;
                }
            
        }

        [Authorize]
        public ActionResult DriverHome(int? id)
        {
            TempData["driv"] = id.ToString();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        
            return View();
            
        }

      
        public ActionResult PassengerRegistration()
        {
            return View();
        }
	}
}