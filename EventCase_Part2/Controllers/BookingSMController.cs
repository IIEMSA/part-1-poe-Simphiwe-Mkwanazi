using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity; // Make sure you're using Entity Framework 6
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventCase_Part2.Models;

namespace EventCase_Part2.Controllers
{
    public class BookingSMController : Controller
    {
        private EventCaseDB2Context db = new EventCaseDB2Context();

        // GET: BookingSM
        public ActionResult Index()
        {
            var bookingSMs = db.BookingSMs.Include(b => b.Event_).Include(b => b.VenueSM);
            return View(bookingSMs.ToList());
        }

        // GET: BookingSM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            BookingSM bookingSM = db.BookingSMs
                .Include(b => b.Event_)
                .Include(b => b.VenueSM)
                .FirstOrDefault(b => b.BookingID == id);

            if (bookingSM == null)
                return HttpNotFound();

            return View(bookingSM);
        }

        // GET: BookingSM/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Event_, "EventID", "EventName");
            ViewBag.VenueID = new SelectList(db.VenueSMs, "VenueID", "VenueName");
            return View();
        }

        // POST: BookingSM/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,EventID,VenueID,BookingDate")] BookingSM bookingSM)
        {
            if (ModelState.IsValid)
            {
                db.BookingSMs.Add(bookingSM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Event_, "EventID", "EventName", bookingSM.EventID);
            ViewBag.VenueID = new SelectList(db.VenueSMs, "VenueID", "VenueName", bookingSM.VenueID);
            return View(bookingSM);
        }

        // GET: BookingSM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            BookingSM bookingSM = db.BookingSMs.Find(id);
            if (bookingSM == null)
                return HttpNotFound();

            ViewBag.EventID = new SelectList(db.Event_, "EventID", "EventName", bookingSM.EventID);
            ViewBag.VenueID = new SelectList(db.VenueSMs, "VenueID", "VenueName", bookingSM.VenueID);
            return View(bookingSM);
        }

        // POST: BookingSM/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,EventID,VenueID,BookingDate")] BookingSM bookingSM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingSM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Event_, "EventID", "EventName", bookingSM.EventID);
            ViewBag.VenueID = new SelectList(db.VenueSMs, "VenueID", "VenueName", bookingSM.VenueID);
            return View(bookingSM);
        }

        // GET: BookingSM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            BookingSM bookingSM = db.BookingSMs
                .Include(b => b.Event_)
                .Include(b => b.VenueSM)
                .FirstOrDefault(b => b.BookingID == id);

            if (bookingSM == null)
                return HttpNotFound();

            return View(bookingSM);
        }

        // POST: BookingSM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingSM bookingSM = db.BookingSMs.Find(id);
            if (bookingSM != null)
            {
                db.BookingSMs.Remove(bookingSM);
                db.SaveChanges();
            }
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
