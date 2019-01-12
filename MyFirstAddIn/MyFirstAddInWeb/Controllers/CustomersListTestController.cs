using Microsoft.SharePoint.Client;
using MyFirstAddInWeb.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstAddInWeb.Controllers
{
    public class CustomersListTestController : Controller
    {
        // GET: CustomersListTest
        [SharePointContextFilter]
        public ActionResult Index(
           )
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string customeractionType)
        //(int? itemid)
        {
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (var ctx = spContext.CreateUserClientContextForSPHost())
            {

                Uri appUrl = Request.Url;

                List list = ctx.Web.GetListByTitle("Customers1");

                if (customeractionType == "Remove")
                {
                    ctx.Load(list.UserCustomActions);
                    ctx.ExecuteQuery();

                    foreach (var a in list.UserCustomActions)
                    {
                        if (a.Name == "CustomNames")
                        {
                            a.DeleteObject();
                            ctx.ExecuteQuery();
                        }
                    }
                }
                else
                {
                    UserCustomAction action = list.UserCustomActions.Add();
                    action.Title = "Order card";
                    action.Name = "CustomNames";
                    action.Url = appUrl.Scheme + "://" + appUrl.Authority + "/CustomersListTest" + appUrl.Query + "&ListId={ListId}&ListItemId={ItemId}";
                    action.Location = "EditControlBlock";
                    action.Sequence = 1;
                    action.Update();
                    ctx.ExecuteQuery();

                    //UserCustomAction action = list.UserCustomActions.Add();
                    //action.Title = "Customer Card test";
                    //action.Name = "CustomName";
                    //action.Url = appUrl.Scheme + "://" + appUrl.Authority  +"/CustomerListTest" + appUrl.Query + "&ListId={ListId}&ListItemId={ItemId}";
                    //action.Location = "EditControlBlock";
                    //action.Sequence = 1;
                    //action.Update();
                    //ctx.ExecuteQuery();


                }



            }
            return View();
        }
        [SharePointContextFilter]
        //public ActionResult Index(int? itemid)
        {


            //List<Models.CustomerLists> customerlists = new List<CustomerLists>();
            //using (ClientContext ctx = ContextHelpers.GetContext())
            //{
            //    if (ctx != null)
            //    {
            //        List list = ctx.Web.GetListByTitle("Customers1");

            //        list.GetItemById(1);
            //        foreach (var item in customerlists)
            //        {
            //            customerlists.Add(new CustomerLists()
            //            {
            //                Title = item.Title,
            //                CustomerLogo = item.CustomerLogo,
            //                Address = item.Address,
            //                MainContactperson = item.MainContactperson,
            //                OfficePhone = item.OfficePhone,
            //                MobilePhone = item.MobilePhone,
            //                Email = item.Email,
            //                LastContacted = item.LastContacted,
            //                LastOrderDate = item.LastOrderDate
            //            });
            //        }


            //    }


            }
           // return View();
        }
    }}
