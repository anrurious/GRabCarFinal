using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrabCarMVC.Models;
using System.IO;

namespace GrabCarMVC.Controllers
{
    public class PassengerController : Controller
    {
        private deshConnection db = new deshConnection();

        // GET: /Passenger/
        public ActionResult Index()
        {
            return View();
           // return View(db.Paxes.ToList());
        }

        public ActionResult SignIn()
        {
            return View();
            // return View(db.Paxes.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(string user,string pass)
        {
            var result = db.Paxes
                          .Where(oh => oh.email == user)
                          .Select(oh => new { id = oh.id })
                          .ToList();

            if (result.Count > 0)
            {
                return RedirectToAction("PassengerHome", "Passenger", new { id = result[0].id });
            }


            else
            {
                return View();
            }
            
            // return View(db.Paxes.ToList());
        }

        public ActionResult PassengerHome(int? id)
        {
            TempData["driv"] = id.ToString();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();

        }


        // GET: /Passenger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pax pax = db.Paxes.Find(id);
            if (pax == null)
            {
                return HttpNotFound();
            }
            return View(pax);
        }

        // GET: /Passenger/Create
        public ActionResult Create()
        {
            TempData["im"] = "";
            return View();
        }

        // POST: /Passenger/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,userName,pass,FName,LName,photo,mob,email,NidNo,NidFront,NidBack,EmerPName,EmerPNo,WhereDesh")] Pax pax, FormCollection fc, List<HttpPostedFileBase> files)
        {
            string err = "1";

            foreach (var file in files)
            {
                if (file == null)
                {
                    return View();
                }
                if (((file.ContentType == "image/jpeg") || (file.ContentType == "image/gif") || (file.ContentType == "image/png"))!=true)
                {
                    return View();
                }
                
            }

            int fName = 10;

            string finalFileName = "";
            string dt = DateTime.Now.ToString("yyyyMMddHHmmss");
            //user_driver.picture = files[0].FileName;
            
            var xy = "";
            var photopath = "D:/ICSE/y/";
            //var photopath = "C:/inetpub/wwwroot/deshexpressbd/images/passanger/";

            //var photopath = "C:/inetpub/wwwroot/deshexpressbd/images/passanger/";
            

            #region WorkWithImages

            foreach (var file in files)
            {
                if (err!="1")
                {
                    TempData["im"] = "Sorry ! Technical Error ! Please Visit after some time !! ";
                    return View();
                }
                if (file == files[0])
                {
                    xy = "pho";
                    finalFileName = xy + dt + fName.ToString();
                    pax.photo = finalFileName;
                }

                if (file == files[1])
                {
                    xy = "nif";
                    finalFileName = xy + dt + fName.ToString();
                    pax.NidFront= finalFileName;
                }

                if (file == files[2])
                {
                    xy = "nib";
                    finalFileName = xy + dt + fName.ToString();
                    pax.NidBack = finalFileName;
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
                        pax.photo = finalFileName;
                    }

                    if (file == files[1])
                    {
                       pax.NidFront = finalFileName;
                    }

                    if (file == files[2])
                    {
                        pax.NidBack = finalFileName;
                    }


                    //Updating DB fields End Here
                    var path = Path.Combine(photopath, finalFileName.ToString());

                    try
                    {
                        file.SaveAs(path);
                    }
                    catch (Exception e)
                    {
                     
                        //throw (ex);
                    }
                    finally
                    {
                        err = "2";
                        TempData["im"] = "1";
                    }

                    //string pathSave = "~/Content/Img/" + finalFileName;                 
                    //pi.ImgUrl = finalFileName;
                }
                fName = fName + 1;
            }
            #endregion

            if (ModelState.IsValid)
            {
                db.Paxes.Add(pax);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pax);
        }

        // GET: /Passenger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pax pax = db.Paxes.Find(id);
            if (pax == null)
            {
                return HttpNotFound();
            }
            return View(pax);
        }

        // POST: /Passenger/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,userName,pass,FName,LName,photo,mob,email,NidNo,NidFront,NidBack,EmerPName,EmerPNo,WhereDesh")] Pax pax)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pax).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pax);
        }

        // GET: /Passenger/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pax pax = db.Paxes.Find(id);
            if (pax == null)
            {
                return HttpNotFound();
            }
            return View(pax);
        }

        // POST: /Passenger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pax pax = db.Paxes.Find(id);
            db.Paxes.Remove(pax);
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
