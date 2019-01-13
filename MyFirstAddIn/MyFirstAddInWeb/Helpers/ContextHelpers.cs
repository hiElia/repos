using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstAddInWeb.Helpers
{
    public class ContextHelpers
    {
        public static void AddNewCustomAction(ClientContext ctx)
        {
           

            ctx.Web.AddNavigationNode("AddNewCustomer", new Uri("https://folkis2017.sharepoint.com/sites/EliasClassic/Lists/Customers1/AllItems.aspx"), "Google", OfficeDevPnP.Core.Enums.NavigationType.QuickLaunch);

        }

        public static ClientContext GetContext()

        {

            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext.Current);

            return spContext.CreateUserClientContextForSPHost();



        }
    }
}