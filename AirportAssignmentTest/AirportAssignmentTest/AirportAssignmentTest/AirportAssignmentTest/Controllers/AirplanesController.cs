using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirportAssignmentTest.Models;
using AirportAssignmentTest.Views;

namespace AirportAssignmentTest.Controllers
{
    public class AirplanesController : Controller
    {
        private AirportAssignmentTestContext db = new AirportAssignmentTestContext();

        // GET: Airplanes
        public ActionResult Index(int? airplaneId)
        {
            ViewBag.AirPlaneId = airplaneId;
            var airplanes = db.Airplanes.Include(a => a.AirplaneType).Include(a => a.Airport).Include(a => a.CoPilot).Include(a => a.Pilot);
            return View(airplanes.ToList());
        }
        public ActionResult TransferAirplane(int?id, int? airportId)
        {
            var view = new AirportIndexData
            {
                Airplanes = db.Airplanes
                .Include(i => i.Airport)
                .Include(i => i.Airport)
                .OrderBy(i => i.Name)


            };
            if (id != null)
            {
               ViewBag.AirplaneId = id.Value;
                view.Airports = view.Airports.Where(i => i.Id == id.Value).Single().Airports;
                //ViewBag.AirportId = id.Value;
                //view.Airplanes = view.Airports.Where(i => i.Id == id.Value).Single().Airplanes;
            }


            return  View(view);


            
        }
        // GET: Airplanes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airplane airplane = db.Airplanes.Find(id);
            if (airplane == null)
            {
                return HttpNotFound();
            }
            return View(airplane);
        }

        // GET: Airplanes/Create
        public ActionResult Create()
        {
            ViewBag.AirplaneTypeId = new SelectList(db.AirplaneTypes, "Id", "Name");
            ViewBag.AirportId = new SelectList(db.Airports, "Id", "Name");
            //ViewBag.CoPilotId = new SelectList(db.Pilots, "Id", "Name");
            //ViewBag.PilotId = new SelectList(db.Pilots, "Id", "Name");
            return View();
        }

        // POST: Airplanes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MaxNumOfPassangers,SizeInMeter,PilotId,CoPilotId,AirplaneTypeId,AirportId")] Airplane airplane)
        {
            if (ModelState.IsValid)
            {
                db.Airplanes.Add(airplane);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AirplaneTypeId = new SelectList(db.AirplaneTypes, "Id", "Name", airplane.AirplaneTypeId);
            ViewBag.AirportId = new SelectList(db.Airports, "Id", "Name", airplane.AirportId);
            ViewBag.CoPilotId = new SelectList(db.Pilots, "Id", "Name", airplane.CoPilotId);
            ViewBag.PilotId = new SelectList(db.Pilots, "Id", "Name", airplane.PilotId);
            return View(airplane);
        }

        // GET: Airplanes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airplane airplane = db.Airplanes.Find(id);
            if (airplane == null)
            {
                return HttpNotFound();
            }
            ViewBag.AirplaneTypeId = new SelectList(db.AirplaneTypes, "Id", "Name", airplane.AirplaneTypeId);
            ViewBag.AirportId = new SelectList(db.Airports, "Id", "Name", airplane.AirportId);
            ViewBag.CoPilotId = new SelectList(db.Pilots, "Id", "Name", airplane.CoPilotId);
            ViewBag.PilotId = new SelectList(db.Pilots, "Id", "Name", airplane.PilotId);
            return View(airplane);
        }

        // POST: Airplanes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MaxNumOfPassangers,SizeInMeter,PilotId,CoPilotId,AirplaneTypeId,AirportId")] Airplane airplane)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airplane).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AirplaneTypeId = new SelectList(db.AirplaneTypes, "Id", "Name", airplane.AirplaneTypeId);
            ViewBag.AirportId = new SelectList(db.Airports, "Id", "Name", airplane.AirportId);
            ViewBag.CoPilotId = new SelectList(db.Pilots, "Id", "Name", airplane.CoPilotId);
            ViewBag.PilotId = new SelectList(db.Pilots, "Id", "Name", airplane.PilotId);
            return View(airplane);
        }

        // GET: Airplanes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airplane airplane = db.Airplanes.Find(id);
            if (airplane == null)
            {
                return HttpNotFound();
            }
            return View(airplane);
        }

        // POST: Airplanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Airplane airplane = db.Airplanes.Find(id);
            db.Airplanes.Remove(airplane);
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
