using Microsoft.SharePoint.Client;
using MyFirstAddInWeb.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstAddInWeb.Controllers
{
    public class ListFunController : Controller
    {
        // GET: ListFun
        public ActionResult Index(Boolean? isdone)
        {
            if(isdone.HasValue && isdone.Value)
            {
                ViewBag.Message = " your list has created ";
            }

            return View();
        }
        [HttpPost]

        public ActionResult Index(string NewListTitle, string SPHostUrl)

        {

            try

            {





                using (ClientContext ctx = ContextHelpers.GetContext())

                {
                    ctx.Web.CreateList(ListTemplateType.GenericList, NewListTitle, false);
                    //ctx.Web.createList(ListTemplateType.GenericList, NewListTitle, false);

                }



            }

            catch (Exception ex)

            {

                throw ex;



            }



            return RedirectToAction("index", new { SPHostUrl = SPHostUrl, isSuccess = true });





        }
    }
}