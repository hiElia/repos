using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstAddInWeb.HelperModel.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}