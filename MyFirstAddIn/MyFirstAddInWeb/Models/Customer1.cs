using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstAddInWeb.Models
{
    public class Customer1
    {
        //[Key]
        //public int Id { get; set; }
        public string Title { get; set; }
        public string CustomerLogo { get; set; }
        public string Address { get; set; }
        public string MainContactperson { get; set; }
        public int OfficePhone { get; set; }
        public int MobilePhone { get; set; }
        public string  Email { get; set; }
        public DateTime LastContacted { get; set; }
        public DateTime lastOrderDate { get; set; }

    }
}