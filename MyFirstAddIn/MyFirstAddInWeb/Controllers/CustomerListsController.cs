using Microsoft.SharePoint.Client;
using MyFirstAddInWeb.HelperModel.Models;
using MyFirstAddInWeb.Helpers;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace MyFirstAddInWeb.Controllers
{
    public class CustomerListsController : Controller
    {
        // GET: CustomerLists
      
        public ActionResult Index(int? itemid)
        {
            List<CustomerList> customerlists = new List<CustomerList>();
            using (ClientContext ctx = ContextHelpers.GetContext())
            {
                if (ctx != null)
                {
                    List list = ctx.Web.GetListByTitle("Customers1");

                    list.GetItemById(1);
                    foreach (var item in customerlists)
                    {
                        customerlists.Add(new CustomerList()
                        {
                            Title = item.Title,
                            CustomerLogo = item.CustomerLogo,
                            Address = item.Address,
                            MainContactperson = item.MainContactperson,
                            OfficePhone = item.OfficePhone,
                            MobilePhone = item.MobilePhone,
                            Email = item.Email,
                            LastContacted = item.LastContacted,
                            LastOrderDate = item.LastOrderDate
                        });
                    }


                }




            }
            return View();
        }
            // ctx.Load(customerlists),
            // custlists => custlists.Include(c => c.),
            //custlists => custlists.Include(c => c.Title),
            //custlists => custlists.Include(c => c.));
            //ctx.ExecuteQuery();

            // ctx.Load(list.DefaultView);

            // ctx.ExecuteQuery();
            //List<CustomerLists> customerlists = new List<CustomerLists>();
            //using(ClientContext ctx= ContextHelpers.GetContext())
            //{
            //    if (ctx!= null)
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


            //         ;



            //List custlists = ctx.Web.Lists.GetByTitle("Customers1");
            //ListItemCollection lstLeaveItems = lstLeaves.GetItems(camlQuery);
            //ListItemCollection custlistsItems = custlists.GetItems(CamlQuery);

            //if (custlists!= null)
            //{
            //    foreach (List list in custlists)
            //    {

            //    }

            //}

            //List lstLeaves = clientContext.Web.Lists.GetByTitle("Leave Requests")
            //}
            //[SharePointContextFilter]
            //public ActionResult ReadFromSharepoint(string ListId, int ListItemId)
            //{
            //    var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            //    using (var ctx = spContext.CreateUserClientContextForSPHost())
            //    {
            //        List list = ctx.Web.GetListById(ListId.ToGuid());
            //        ListItem item = list.GetItemById(ListItemId);
            //        ctx.Load(item);
            //        ctx.ExecuteQuery();

            //        ViewBag.ListItemTitle = item["Title"].ToString();

            //    }
            //    return View();
            //}
        }
}