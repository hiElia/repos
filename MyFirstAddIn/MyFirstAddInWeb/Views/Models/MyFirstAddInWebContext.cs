using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyFirstAddInWeb.Models
{
    public class MyFirstAddInWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MyFirstAddInWebContext() : base("name=MyFirstAddInWebContext")
        {
        }

        public System.Data.Entity.DbSet<MyFirstAddInWeb.Models.CustomerLists> CustomerLists { get; set; }

         //public System.Data.Entity.DbSet<MyFirstAddInWeb.Models.Customer1> Customer1 { get; set; }

        //public System.Data.Entity.DbSet<MyFirstAddInWeb.Models.CustomerLists> CustomerLists { get; set; }
    }
}
