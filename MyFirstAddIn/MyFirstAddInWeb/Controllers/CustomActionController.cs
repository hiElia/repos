using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Search.Query;
using Microsoft.SharePoint.Client.Taxonomy;
using MyFirstAddInWeb.HelperModel.Models;
using MyFirstAddInWeb.Helpers;

using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstAddInWeb.Controllers
{
    public class CustomActionController : Controller
    {
        // GET: CustomAction
        [SharePointContextFilter]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string custactionType)
        {
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (var ctx = spContext.CreateUserClientContextForSPHost())
            {

                Uri appUrl = Request.Url;

                List list = ctx.Web.GetListByTitle("Customers1");

                if (custactionType == "Remove")
                {
                    ctx.Load(list.UserCustomActions);
                    ctx.ExecuteQuery();

                    foreach (var a in list.UserCustomActions)
                    {
                        if (a.Name == "CustomName")
                        {
                            a.DeleteObject();
                            ctx.ExecuteQuery();
                        }
                    }
                }
                else
                {
                    //UserCustomAction action = list.UserCustomActions.Add();
                    //action.Title = "GoToOrder";
                    //action.Url = "https://folkis2017.sharepoint.com/sites/EliasClassic/Lists/Orderlists/AllItems.aspx";


                    UserCustomAction action = list.UserCustomActions.Add();
                    action.Title = "GoToCustomerCard";
                    action.Name = "CustomName";
                    action.Url = appUrl.Scheme + "://" + appUrl.Authority + "/CustomAction/ReadFromSharepoint" + appUrl.Query + "&ListId={ListId}&ListItemId={ItemId}";
                    action.Location = "EditControlBlock";
                    action.Sequence = 1;
                    action.Update();
                    ctx.ExecuteQuery();

                }

            }

            return View();
        }
        


        public static void CreateCustomerListView(ClientContext ctx)
        {
            List list = ctx.Web.GetListByTitle("CustomerlistTest");
            ctx.Load(list.DefaultView);
            ctx.ExecuteQuery();

            list.DefaultView.ViewFields.Add("Customer Logo1");
            list.DefaultView.ViewFields.Add("Address1");
            list.DefaultView.ViewFields.Add("Main Contact person1");
            list.DefaultView.ViewFields.Add("Office Phone1");
            list.DefaultView.ViewFields.Add("Mobile Phone1");
            list.DefaultView.ViewFields.Add("Email1");
            list.DefaultView.ViewFields.Add("Last Contacted1");
            list.DefaultView.ViewFields.Add("Last Order made1");

            list.DefaultView.Update();
            ctx.ExecuteQuery();





        }
        //[SharePointContextFilter]
        //public ActionResult Index(int? itemid)
        //{


        //    List<CustomerLists> customerlists = new List<CustomerLists>();
        //    using (ClientContext ctx = ContextHelpers.GetContext())
        //    {
        //        if (ctx != null)
        //        {
        //            List list = ctx.Web.GetListByTitle("Customers1");

        //            list.GetItemById(1);
        //            foreach (var item in customerlists)
        //            {
        //                customerlists.Add(new CustomerLists()
        //                {
        //                    Title = item.Title,
        //                    CustomerLogo = item.CustomerLogo,
        //                    Address = item.Address,
        //                    MainContactperson = item.MainContactperson,
        //                    OfficePhone = item.OfficePhone,
        //                    MobilePhone = item.MobilePhone,
        //                    Email = item.Email,
        //                    LastContacted = item.LastContacted,
        //                    LastOrderDate = item.LastOrderDate
        //                });
        //            }


        //        }


        //    }
        //    return View();
        //}

        [SharePointContextFilter]
        public ActionResult ReadFromSharepoint(string ListId, int ListItemId)
        {
            ViewBag.ListId = ListId;

            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (var ctx = spContext.CreateUserClientContextForSPHost())
            {
                if (ctx != null)
                {
                    List list = ctx.Web.GetListById(ListId.ToGuid());
                    ListItem item = list.GetItemById(ListItemId);
                    ctx.Load(item);
                    //ctx.Load(list);
                    ctx.ExecuteQuery();
                    CustomerList customerlist = new CustomerList();
                   customerlist.ID = item.Id;
                    customerlist.Title = item["Title"].ToString();


                    FieldUrlValue FieldImage = item["Customer_x0020_Logo1"] as FieldUrlValue;
                    customerlist.CustomerLogo = FieldImage.Url;
                    //customerlist.CustomerLogo = item["Customer_x0020_Logo11"].ToString();
                    customerlist.OfficePhone = item["Office_x0020_Phone1"].ToString();
                    customerlist.MainContactperson = item["Main_x0020_Contact_x0020_person1"].ToString();
                    customerlist.MobilePhone = item["Mobile_x0020_Phone1"].ToString();
                    customerlist.Address = item["Address1"].ToString();
                    customerlist.Email = item["Email1"].ToString();
                    customerlist.LastContacted = DateTime.Parse(item["Last_x0020_Contacted1"].ToString());
                    customerlist.LastOrderDate = DateTime.Parse(item["Last_x0020_Order_x0020_made1"].ToString());
                    //
                    customerlist.Orders = new List<OrderList>();
                    //List orderlist = ctx.Web.GetListByTitle("OrderList 



                    List OrderList = ctx.Web.GetListByTitle("OrderLists");
                    CamlQuery camlQuery = new CamlQuery();

                    camlQuery.ViewXml =

                        @"<View>  

                        <Query> 
                        <Where>
                             <Eq>
                                <FieldRef Name='DA_Customer' LookupId='True' />
                                <Value Type='Lookup'>" + ListItemId + @"</Value>
                             </Eq>
                          </Where> 

                        </Query> 
                   <ViewFields><FieldRef Name='Title' /><FieldRef Name='DA_Customer' /><FieldRef Name='Amount' /><FieldRef Name='SA_Product1' /></ViewFields> 

                  </View>";
                    ListItemCollection items = OrderList.GetItems(camlQuery);
                    ctx.Load(items);
                    ctx.ExecuteQuery();
                    foreach (ListItem i in items)
                    {
                        OrderList order = new HelperModel.Models.OrderList();
                        order.Title = i["Title"].ToString();                        
                        order.Customer = (i["DA_Customer"] as FieldLookupValue).LookupValue;
                        order.Amount = i["Amount"].ToString();                      
                        TaxonomyFieldValue taxonomyfieldvalue = i["SA_Product1"] as TaxonomyFieldValue;
                        order.Product = taxonomyfieldvalue.Label;
                        customerlist.Orders.Add(order);




                    }

                    // get orders from orders list based from customerid
                    // caml query




                    // loop through orders and add to customerlist.orders

                    //
                    //ctx.Load(customerlist, c =>c.CustomerLogo);
                    return View(customerlist);

                }


            }
            return View();

        } 


                }

            }




   

    

