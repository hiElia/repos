using Microsoft.SharePoint.Client;
using MyFirstAddInWeb.HelperModel.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstAddInWeb.Helpers
{
    public class CustomerListsHelper
    {
        public static CustomerList GetRequestFromSharepoint(Guid listId, int itemId, ClientContext ctx)
        {
            List list = ctx.Web.GetListById(listId);
            ListItem item = list.GetItemById(itemId);
            ctx.Load(item);

            CustomerList customerlist = new CustomerList();
            customerlist.ID = item.Id;
            customerlist.Title = item["Title"].ToString();
            customerlist.Address = item["Address1"].ToString();
            customerlist.CustomerLogo = item["Customer Logo1"].ToString();
            customerlist.MainContactperson= item["Main Contact person1"].ToString();
            customerlist.OfficePhone = item["Office Phone1"].ToString();
            customerlist.MobilePhone = item["Mobile Phone1"].ToString();
            customerlist.Email = item["Email1"].ToString();
            customerlist.LastContacted = DateTime.Parse(item["Last Contacted1"].ToString());
            customerlist.LastOrderDate = DateTime.Parse(item["Last Order made1"].ToString());



            return customerlist;

        }
    }
}