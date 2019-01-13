using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstAddInWeb.HelperModel.Models
{
    public class CustomerList
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string CustomerLogo { get; set; }
        public string Address { get; set; }
        public string MainContactperson { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public DateTime LastContacted { get; set; }
        public DateTime LastOrderDate { get; set; }

        public List<OrderList> Orders { get; set; }



    }
}