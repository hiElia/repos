using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Taxonomy;
using MyFirstAddInWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstAddInWeb.Helpers
{
    public class ProductHelper
    {
       

        public static List<Product> GetProducts(ClientContext ctx)
        {
            TermStore termStore = ctx.Site.GetDefaultSiteCollectionTermStore();//taxonomySession.TermStores.GetByName("TAXONOMY TERM STORE");
            TermGroup termGroup = termStore.Groups.GetByName("Elias4");
            TermSet termSet = termGroup.TermSets.GetByName("Product1");
            TermCollection termColl = termSet.Terms;
            ctx.Load(termColl);
            ctx.ExecuteQuery();

            List<Product> products = new List<Product>();
            foreach (var term in termColl)
            {
                Product p = new Product();
                p.ProductName = term.Name;
                p.ProductId = term.Id.ToString();
                products.Add(p);

            }
            //foreach (Term term in termColl)
            //{
                         
                
               
            //}

           
            
            
            
            // loop through termcoll
            // create new product Product p = new Product()
            // move id and name from term to product objecct
            // add product to products.


            return products;
        }


    }
}