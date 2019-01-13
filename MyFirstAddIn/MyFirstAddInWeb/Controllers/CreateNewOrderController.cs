using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Taxonomy;
using MyFirstAddInWeb.HelperModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstAddInWeb.Helpers;


namespace MyFirstAddInWeb.Controllers
{
    public class CreateNewOrderController : Controller
    {
        // GET: CreateNewOrder
        public ActionResult Create()
        {
            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            using (var ctx = spContext.CreateUserClientContextForSPHost())
            {
                //TaxonomySession taxonomySession = TaxonomySession.GetTaxonomySession(ctx);

                ViewBag.Products = ProductHelper.GetProducts(ctx);

                
                

                //List<ProductTerm> products = ProductHelper.GetProducts(ctx);
            }
               
            // get the terms from your product termset and put them in the viewbag. 
            // use a model called List<ProductTerm> 
            // List<ProductTerm> products = ProductHelper.GetProducts(ctx)
            return View();

        }
               
        
        [HttpPost]
        
        public ActionResult Create(int? CustomerId, string SPHostUrl, string product, string ListId, string Title, string Amount)
        

        {
          
            
                using (ClientContext ctx = Helpers.ContextHelpers.GetContext())

                {
                   

                    string ProdId = product.Split(",".ToCharArray())[0];
                    string prodName = product.Split(",".ToCharArray())[1];


                    //stitem["CustomerLookupField"] = order.customerID 
                    //tx.Web.CreateList(ListTemplateType.GenericList, OrderCard2, false);


                    List list = ctx.Web.GetListByTitle("OrderLists");
                    ListItemCreationInformation listcreationinformation = new ListItemCreationInformation();
                    ListItem listitem = list.AddItem(listcreationinformation);
                     listitem.SetTaxonomyFieldValue("{08A8080D-5ECA-4637-A1BC-DC61AD4A1B80}".ToGuid(), prodName, ProdId.ToGuid());
               

                    listitem["Title"] = Title;
                    
                    listitem["Amount"] = Amount;
                    listitem["DA_Customer"] = CustomerId;
               
                listitem.Update();
                ctx.ExecuteQuery();

                List customerList = ctx.Web.GetListByTitle("CustomerLists");
                ListItem custItem = customerList.GetItemById(CustomerId.Value);
                ctx.Load(custItem);                
                custItem["Last_x0020_Order_x0020_made1"] = DateTime.Now;
                custItem.Update();
                ctx.ExecuteQuery();







                // CustomerList customerlist = ctx.Web.GetListById(CustomerId);
                // customerlist
                //// ListItem item = list.GetItemById(ListItemId);
                // var item = items.GetById(4)
                // 
                // listitem.Update();
                // ctx.ExecuteQuery();

                //NewList newlist = ctx.Web.GetListById

                // CustomerList customerlist =ctx.Web.GetListById(CustomerId)
                //new CustomerList();
                //customerlist.ID = listitem.Id;



                //list = ctx.Web.GetListById(ListId.ToGuid());

                //listitem["Last_x0020_Contacted1"] = DateTime.Now;
                //listitem.Update();
                //ctx.ExecuteQuery();



                //if (ctx!=null)
                //{
                //List list = ctx.Web.GetListById(ListId.ToGuid());
                //ListItem item = list.GetItemById(ListItemId);
                //string ListId;
                //int ListitemId;
                //List list = ctx.Web.GetListById(ListId.ToGuid)


                //}




                //List list = ctx.Web.getitembyid


                // get customer list and item by id
                // update the last created order to datetime.now

                //



                //oListItem["Modified"] = Convert.ToDateTime(LastModifiedDate);

                //oListItem.Update();

                // clientContext.ExecuteQuery();



                //TaxonomyFieldValue taxonomyfieldvalue = listitem["SA_Product1"] as TaxonomyFieldValue;
                //order.Product = taxonomyfieldvalue.Label;                    




                //stitem
                //der.l
                //stItemID = (listitem["DA_Customer"] as FieldLookupValue).LookupValue;
                //der.Customer = (i["DA_Customer"] as FieldLookupValue).LookupValue;
                //der.Customer = (listitem["DA_Customer"] as FieldLookupValue).LookupValue;









            }



            return RedirectToAction("ReadFromSharepoint", "CustomAction", new { SPHostUrl = SPHostUrl, ListId = ListId, ListItemId  = CustomerId});

               // return RedirectToAction("Create", new { SPHostUrl = SPHostUrl });

                //@Html.ActionLink("Edit", "LanguageEdit", "Country", new { id = item.LanguageId }

       

        }
    }

    internal class ProductTerm
    {
    }
}