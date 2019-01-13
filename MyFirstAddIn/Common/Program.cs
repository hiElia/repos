using Microsoft.SharePoint.Client;
using MyFirstAddInWeb.HelperModel.Models;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  MyFirstAddInWeb.Helpers;
using OfficeDevPnP.Core.Entities;

namespace Common
{
    class Program
    {
        static void Main(string[] args)
        {
           
            


           // using (var ctx = Common.Helper.ContextHelper.GetClientContext("https://folkis2017.sharepoint.com/sites/EliasClassic"))
            {

                //CustomActionEntity custAction = new CustomActionEntity();

                //custAction.Name = "actionlink";

                //custAction.Sequence = 1008;

                //custAction.Url = "https://folkis2017.sharepoint.com/sites/EliasClassic/Lists/Customers1/AllItems.aspx";

                //custAction.Group = "SiteActions";

                //custAction.Location = "Microsoft.SharePoint.StandardMenu";

                //custAction.Description = "action link";

                //custAction.Title = "AddNewCustomer";



                //ctx.Site.AddCustomAction(custAction);






                //ContextHelpers.AddNewCustomAction(ctx);



                //CustomerListsHelper.GetRequestFromSharepoint();
                //public static void CreateCustomerListView(ClientContext ctx)

                //{
                //List list = ctx.Web.GetListByTitle("CustomerlistTest");
                //ctx.Load(list.DefaultView);
                //ctx.ExecuteQuery();

                //list.DefaultView.ViewFields.Add("Customer Logo1");
                //list.DefaultView.ViewFields.Add("Address1");
                //list.DefaultView.ViewFields.Add("Main Contact person1");
                //list.DefaultView.ViewFields.Add("Office Phone1");
                //list.DefaultView.ViewFields.Add("Mobile Phone1");
                //list.DefaultView.ViewFields.Add("Email1");
                //list.DefaultView.ViewFields.Add("Last Contacted1");
                //list.DefaultView.ViewFields.Add("Last Order made1");

                //list.DefaultView.Update();
                //ctx.ExecuteQuery();





                // }


                //OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml.XMLFileSystemTemplateProvider provider = new XMLFileSystemTemplateProvider(connectionString: @"C:\Users\elias\source\repos\MyFirstAddin\Common", container: "");


                ////string templateName = "TemplateFirstsTest.xml";
                //string templateName = "OrderListTem.xml";

                //ProvisioningTemplate template = provider.GetTemplate(templateName);

                //ctx.Web.ApplyProvisioningTemplate(template);




            }






            //public static CustomerList GetRequestFromSharepoint(Guid listId, int itemId, ClientContext ctx)
            //{
            //    List list = ctx.Web.GetListById(listId);
            //    ListItem item = list.GetItemById(itemId);
            //    ctx.Load(item);

            //    CustomerList customerlist = new CustomerList();
            //    customerlist.ID = item.Id;
            //    customerlist.Title = item["Title"].ToString();
            //    customerlist.CustomerLogo = item["SA_Customerlogo"].ToString();
            //    customerlist.MainContactperson = item["SA_MainContactPerson"].ToString();
            //    customerlist.OfficePhone = item["SA_Officephone"].ToString();
            //    customerlist.MobilePhone = item["SA_Mobilephone"].ToString();
            //    customerlist.Email = item["SA_Email"].ToString();
            //    customerlist.LastContacted = DateTime.Parse(item["SA_LastContacted"].ToString());
            //    customerlist.LastOrderDate = DateTime.Parse(item["SA_LastorderMade"].ToString());



            //    return customerlist;

        }

        public static void GetOrdersFromOrderlist(ClientContext ctx)
        {
            //List list = ctx.Web.GetListByTitle("OrderLists");
            //CamlQuery camlQuery = new CamlQuery();
            //camlQuery.ViewXml =

            //     @"<View>  

            //            <Query> 

            //               <Where><And><Geq><FieldRef Name='DA_Customer' /><Value Type='string'</Value></Geq> 

            //            </Query> 

            //             <ViewFields><FieldRef Name='Title' /><FieldRef Name='DA_Customer' /><FieldRef Name='Amount' /><FieldRef Name='SA_Product1' /></ViewFields> 

            //      </View>";
            //ListItemCollection items = list.GetItems(camlQuery);



            //ctx.Load(items);

            //ctx.ExecuteQuery();



        }
    }
    }

