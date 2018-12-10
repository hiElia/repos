using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportAssignmentTest.Models
{
    public class Pilot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AirplanTypeCanFly { get; set; }
        public Airplane Airplane { get; set; }
    }
}