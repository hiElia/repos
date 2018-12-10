using AirportAssignmentTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportAssignmentTest.Views
{
    public class AirportIndexData
    {
        public IEnumerable<Airport> Airports { get; set; }
        public IEnumerable<Airplane> Airplanes { get; set; }
    }
}