using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstAddInWeb.Controllers
{
    public class HomeController : Controller
    {
        [SharePointContextFilter]
        public ActionResult Index(string listid, int?ItemId)
        {
           // User spUser = null;

            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (ClientContext ctx = spContext.CreateUserClientContextForSPHost())
            {
                //if (ctx != null)
                //{
                //    List list = ctx.Web.GetListById(listid.ToGuid());
                //    ListItem item = list.GetItemById(ItemId.Value);
                //    ctx.Load(item);
                //    ctx.ExecuteQuery();
                   
                    
                //    //ctx.Web.Title = "Elias first Add-in";
                //    //ctx.Web.Update();
                //    //ctx.ExecuteQuery();
                //    //spUser = ctx.Web.CurrentUser;
                    

                //    //ctx.Load(spUser, user => user.Title);

                //    //ctx.ExecuteQuery();

                //    //ViewBag.UserName = spUser.Title;
                //}
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
