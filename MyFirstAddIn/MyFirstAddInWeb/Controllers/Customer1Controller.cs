using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstAddInWeb.Controllers
{
    public class Customer1Controller : Controller
    {
        // GET: Customer1
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer1/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
