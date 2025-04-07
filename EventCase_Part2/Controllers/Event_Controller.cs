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
    public class Event_Controller : Controller
    {
        private EventCaseDB2Context db = new EventCaseDB2Context();

        // GET: Event_
        public ActionResult Index()
        {
            var event_ = db.Event_.Include(e => e.VenueSM);
            return View(event_.ToList());
        }

        // GET: Event_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event_ event_ = db.Event_.Find(id);
            if (event_ == null)
            {
                return HttpNotFound();
            }
            return View(event_);
        }

        // GET: Event_/Create
        public ActionResult Create()
        {
            ViewBag.VenueID = new SelectList(db.VenueSMs, "VenueID", "VenueName");
            return View();
        }

        // POST: Event_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventName,EventDate,Description,VenueID")] Event_ event_)
        {
            if (ModelState.IsValid)
            {
                db.Event_.Add(event_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VenueID = new SelectList(db.VenueSMs, "VenueID", "VenueName", event_.VenueID);
            return View(event_);
        }

        // GET: Event_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event_ event_ = db.Event_.Find(id);
            if (event_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.VenueID = new SelectList(db.VenueSMs, "VenueID", "VenueName", event_.VenueID);
            return View(event_);
        }

        // POST: Event_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventName,EventDate,Description,VenueID")] Event_ event_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(event_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VenueID = new SelectList(db.VenueSMs, "VenueID", "VenueName", event_.VenueID);
            return View(event_);
        }

        // GET: Event_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event_ event_ = db.Event_.Find(id);
            if (event_ == null)
            {
                return HttpNotFound();
            }
            return View(event_);
        }

        // POST: Event_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event_ event_ = db.Event_.Find(id);
            db.Event_.Remove(event_);
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
