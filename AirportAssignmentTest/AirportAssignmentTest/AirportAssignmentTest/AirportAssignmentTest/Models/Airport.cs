using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportAssignmentTest.Models
{
    public class Airport
    {
        internal readonly IEnumerable<Airport> Airports;

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public virtual List<Airplane> Airplanes { get; set; }
    }
}