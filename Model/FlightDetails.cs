using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.FlightM;

namespace Entities
{
    //An entity that contains detailed information about a flight
    public class FlightDetails
    {
        public string Id { get; set; }
        public string SourceCode { get; set; }
        public string SourceName { get; set; }
        public string DestinationCode { get; set; }
        public string DestinationName { get; set; }
        public double SourceLong { get; set; }
        public double SourceLat { get; set; }
        public double DestinationLong { get; set; }
        public double DestinationLat { get; set; }
        public string TimeOfFly { get; set; }
        public string TimeOfFArrive { get; set; }
        public string FlightCode { get; set; }
        public string PictureOfAirPlane { get; set; }
        public string AirLainName { get; set; }
        public int directionFly { get; set; }
        public List<Trail> Trail { get; set; }
        
    }
}
