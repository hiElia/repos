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
    public class AirportController : Controller
    {
        private AirportAssignmentTestContext db = new AirportAssignmentTestContext();

        // GET: Airport
        public ActionResult Index(int? id, int?airplaneId)
        {


            var view = new AirportIndexData
            {
                Airports = db.Airports
                .Include(i => i.Airplanes)
                .Include(i => i.Airplanes.Select(a => a.AirplaneTypes))
                .OrderBy(i => i.Name)
            };
            if (id != null)
            {
                ViewBag.AirportId = id.Value;
                ViewBag.AirPlaneId = airplaneId;

                view.Airplanes = view.Airports.Where(i => i.Id == id.Value).Single().Airplanes;
            }

            ViewBag.AirportsToTransferTo = new SelectList(db.Airports, "Id", "Name");

            return View(view);
        }
        [HttpPost]
        public ActionResult TransferAirPlane(int AirportId, int AirplaneId)
        {
            if (ModelState.IsValid)
            {
                Airplane airplane = db.Airplanes.Find(AirplaneId);
                airplane.AirportId = AirportId;
                
                //db.Airplanes.Add(airplan;               
                db.SaveChanges();              
                return RedirectToAction("Index");
            }
            return View();
        }
      
        
        
        
        
        
        
        
        
       

        // GET: Airport/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airport airport = db.Airports.Find(id);
            if (airport == null)
            {
                return HttpNotFound();
            }
            return View(airport);
        }

        // GET: Airport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Airport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City")] Airport airport)
        {
            if (ModelState.IsValid)
            {
                db.Airports.Add(airport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airport);
        }

        // GET: Airport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airport airport = db.Airports.Find(id);
            if (airport == null)
            {
                return HttpNotFound();
            }
            return View(airport);
        }

        // POST: Airport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,City")] Airport airport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airport);
        }

        // GET: Airport/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airport airport = db.Airports.Find(id);
            if (airport == null)
            {
                return HttpNotFound();
            }
            return View(airport);
        }

        // POST: Airport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Airport airport = db.Airports.Find(id);
            db.Airports.Remove(airport);
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
