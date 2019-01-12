using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstAddInWeb.Helpers;

namespace MyFirstAddInWeb.Controllers
{
    public class SPController : Controller
    {
        // GET: SP
        public ActionResult Index()
        {
        //    List<SpLists> splists = new List<SpLists>();

        //    using (ClientContext ctx = ContextHelpers.GetContext())
        //    {
        //        if (ctx != null)
        //        {
        //            ListCollection lists = ctx.Web.Lists;
        //            ctx.Load(lists,
        //                lsts => lsts.Include(l => l.Id),
        //                lsts => lsts.Include(l => l.Title),
        //                lsts => lsts.Include(l => l.DefaultViewUrl));
        //            ctx.ExecuteQuery();
        //            foreach (List list in lists)
        //            {
        //                splists.Add(new SpLists() { ListId = list.Id, Title = list.Title, Url = list.DefaultViewUrl });

        //            }

        //        }


        //    }
            return View();



        }

        // GET: SP/Details/5
        public ActionResult Details(string listId)
        {
            using (ClientContext ctx = ContextHelpers.GetContext())
            {
                //
                //List list = ctx.Web.

                

                

                   
                    



                    return View();

                }


            }

        

        // GET: SP/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: SP/Create
        [HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: SP/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SP/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: SP/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SP/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


    }
} 
