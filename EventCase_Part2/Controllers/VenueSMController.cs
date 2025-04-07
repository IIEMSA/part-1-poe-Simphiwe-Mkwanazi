using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventCase_Part2.Models;

namespace EventCase_Part2.Controllers
{
    public class VenueSMController : Controller
    {
        private EventCaseDB2Context db = new EventCaseDB2Context();

        // GET: VenueSM
        public ActionResult Index()
        {
            return View(db.VenueSMs.ToList());
        }

        // GET: VenueSM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueSM venueSM = db.VenueSMs.Find(id);
            if (venueSM == null)
            {
                return HttpNotFound();
            }
            return View(venueSM);
        }

        // GET: VenueSM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VenueSM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VenueID,VenueName,Location,Capacity,Image_Url")] VenueSM venueSM)
        {
            if (ModelState.IsValid)
            {
                db.VenueSMs.Add(venueSM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(venueSM);
        }

        // GET: VenueSM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueSM venueSM = db.VenueSMs.Find(id);
            if (venueSM == null)
            {
                return HttpNotFound();
            }
            return View(venueSM);
        }

        // POST: VenueSM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VenueID,VenueName,Location,Capacity,Image_Url")] VenueSM venueSM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venueSM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venueSM);
        }

        // GET: VenueSM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueSM venueSM = db.VenueSMs.Find(id);
            if (venueSM == null)
            {
                return HttpNotFound();
            }
            return View(venueSM);
        }

        // POST: VenueSM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VenueSM venueSM = db.VenueSMs.Find(id);
            db.VenueSMs.Remove(venueSM);
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
