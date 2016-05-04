using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrabCarMVC.Models;

namespace GrabCarMVC.Controllers
{
    public class DitclTestController : Controller
    {
        private deshConnection db = new deshConnection();

        // GET: /DitclTest/
        public ActionResult Index()
        {
            return View(db.ditcltests.ToList());
        }

        // GET: /DitclTest/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ditcltest ditcltest = db.ditcltests.Find(id);
            if (ditcltest == null)
            {
                return HttpNotFound();
            }
            return View(ditcltest);
        }

        // GET: /DitclTest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DitclTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,name")] ditcltest ditcltest)
        {
            if (ModelState.IsValid)
            {
                db.ditcltests.Add(ditcltest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ditcltest);
        }

        // GET: /DitclTest/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ditcltest ditcltest = db.ditcltests.Find(id);
            if (ditcltest == null)
            {
                return HttpNotFound();
            }
            return View(ditcltest);
        }

        // POST: /DitclTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,name")] ditcltest ditcltest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ditcltest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ditcltest);
        }

        // GET: /DitclTest/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ditcltest ditcltest = db.ditcltests.Find(id);
            if (ditcltest == null)
            {
                return HttpNotFound();
            }
            return View(ditcltest);
        }

        // POST: /DitclTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ditcltest ditcltest = db.ditcltests.Find(id);
            db.ditcltests.Remove(ditcltest);
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
