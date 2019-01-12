using Microsoft.SharePoint.Client;
using Newtonsoft.Json;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using RestSharp;
using SiteProvisioning.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteProvisioning.Helpers
{
    class SiteProvisioningHelper
    {

        public static void GetTemplateProvisioning(ClientContext ctx)
        {


          
                OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml.XMLFileSystemTemplateProvider provider = new XMLFileSystemTemplateProvider(connectionString: @"C:\Users\elias\source\repos\SiteProvisioning\SiteProvisioning\Helpers\", container: "");
                string templateName = "GroupSites.xml";

                ProvisioningTemplate template = provider.GetTemplate(templateName);
                ctx.Web.ApplyProvisioningTemplate(template);


            


        }
        public static void CreateSite(int id)
        {
            ItemRequest info = GetItemInfoFromSharepoint(id);

            string groupId = CreateGroup(info);
            string userId = GetUserId(info.OwnerEmail);
            AddOwnerToGroup(groupId, userId);
            Thread.Sleep(5000);
            string url = GetSiteUrl(groupId);

            using (ClientContext newSiteContext = ContextHelper.GetContext(url))
            {
                newSiteContext.Load(newSiteContext.Web);
                newSiteContext.ExecuteQuery();
                string s = newSiteContext.Web.Title;

                GetTemplateProvisioning(newSiteContext);


            }

        }
        private static ItemRequest GetItemInfoFromSharepoint(int id)
        {


            string siteurl = ConfigurationManager.AppSettings["sharepointurl"];
            using (ClientContext ctx = Helpers.ContextHelper.GetContext(siteurl))
            {

              //  ListItem item = ctx.Web.Lists.GetByTitle("").GetItemById(id);
                ListItem item = ctx.Web.Lists.GetByTitle("RequestSite").GetItemById(id);
                //AddItem(new ListItemCreationInformation());
                ctx.Load(item);
                ctx.ExecuteQueryRetry();

                ItemRequest info = new ItemRequest();

                info.Title = item["Title"].ToString();
                info.Id = id;
                info.OwnerEmail = (item["Author"] as FieldUserValue).Email;


                return info;



            }




        }
        private static string CreateGroup(ItemRequest info)

        {

            string acccesToken = ContextHelper.GetAccessToken().Result;



            var groupInfo = new

            {

                description = "new site",

                displayName = info.Title,

                groupTypes = new List<string> { "Unified" },

                mailEnabled = true,

                mailNickname = info.Title.Replace(" ",""),

                securityEnabled = false,

                Visibility = "private"

            };

            var client = new RestClient("https://graph.microsoft.com");

            var request = new RestRequest("/v1.0/groups", Method.POST);

            request.RequestFormat = DataFormat.Json;

            request.AddBody(groupInfo);

            request.AddHeader("Authorization", "Bearer " + acccesToken);

            request.AddHeader("Content-Type", "application/json");

            request.AddHeader("Accept", "application/json");



            var response = client.Execute(request);

            var content = response.Content;



             NewUnifiedGroup group = JsonConvert.DeserializeObject<NewUnifiedGroup>(content);




            return group.id;

        }
        public static string GetUserId(string Email)

        {

            string acccesToken = ContextHelper.GetAccessToken().Result;



            var client = new RestClient("https://graph.microsoft.com");

            var request = new RestRequest("/v1.0/users/" + Email, Method.GET);

            request.RequestFormat = DataFormat.Json;



            request.AddHeader("Authorization", "Bearer " + acccesToken);

            request.AddHeader("Content-Type", "application/json");

            request.AddHeader("Accept", "application/json");



            var response = client.Execute(request);

            var content = response.Content;



            GraphUser user = JsonConvert.DeserializeObject<GraphUser>(content);



            return user.id;
        }
        private static void AddOwnerToGroup(string groupId, string ownerId)

        {

            string acccesToken = ContextHelper.GetAccessToken().Result;

            var userInfo = "{'@odata.id': 'https://graph.microsoft.com/v1.0/users/" + ownerId + "'}";



            var client = new RestClient("https://graph.microsoft.com");

            var request = new RestRequest("/v1.0/groups/{" + groupId + "}/owners/$ref", Method.POST);

            request.RequestFormat = DataFormat.Json;

            request.AddParameter("jsonpayload", userInfo, "application/json", ParameterType.RequestBody);





            request.AddHeader("Authorization", "Bearer " + acccesToken);

            request.AddHeader("Content-Type", "application/json");

            request.AddHeader("Accept", "application/json");



            var response = client.Execute(request);

            var content = response.Content;

        }
        public static string GetSiteUrl(string GroupId)

        {

            string acccesToken = ContextHelper.GetAccessToken().Result;



            var client = new RestClient("https://graph.microsoft.com");

            var request = new RestRequest("/v1.0/groups/" + GroupId + "/sites/root/weburl", Method.GET);

            request.RequestFormat = DataFormat.Json;



            request.AddHeader("Authorization", "Bearer " + acccesToken);

            request.AddHeader("Content-Type", "application/json");

            request.AddHeader("Accept", "application/json");



            var response = client.Execute(request);

            var content = response.Content;



            ValueObject site = JsonConvert.DeserializeObject<ValueObject>(content);



            return site.value;

        }


    }
}
