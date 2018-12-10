using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportAssignmentTest.Models
{
    public class AirplaneType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Airplane Airplane { get; set; }
    }
}