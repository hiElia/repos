using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportAssignmentTest.Models
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxNumOfPassangers { get; set; }
        public int SizeInMeter { get; set; }

        public int? PilotId { get; set; }  //Foreign Key(I should have this one)
        public Pilot Pilot { get; set; }//(he added this one)

        public int? CoPilotId { get; set; }  //Foreign Key(i should have this one)
        public Pilot CoPilot { get; set; }

        public AirplaneType AirplaneType { get; set; }
        public int? AirplaneTypeId { get; set; }  //Foreign Key

        public int? AirportId { get; set; }
        public Airport Airport { get; set; }
        public virtual List<AirplaneType> AirplaneTypes { get; set; }
        public virtual List<Pilot> Pilots   {  get; set; }
    }
}