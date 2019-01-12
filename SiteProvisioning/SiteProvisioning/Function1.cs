using System;
using System.Configuration;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.SharePoint.Client;

namespace SiteProvisioning
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("newitem", Connection = "AzureWebJobsStorage")]string itemId, TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {itemId}");
            Helpers.SiteProvisioningHelper.CreateSite(int.Parse(itemId));

            //Helpers.SiteProvisioningHelper.GetTemplateProvisioning();

            
            
            
            
            
            
            
            
            
            
            
            
            
            //string siteurl = ConfigurationManager.AppSettings["sharepointurl"];
            //using (ClientContext ctx= Helpers.ContextHelper.GetContext(siteurl))
            //{
            //    Web web = ctx.Web;
            //    ctx.Load(web, w => w.Title);
            //    ctx.ExecuteQuery();


            //    log.Info($"you are connected to" + web.Title);


            //}
        }
    }
}
