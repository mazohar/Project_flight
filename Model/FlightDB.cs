using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FlightDB
    {
        public string Id { get; set; }
        public string SourceCode { get; set; }
        public string SourceName { get; set; }
        public string DestinationCode { get; set; }
        public string DestinationName { get; set; }
        //public double SourceLong { get; set; }
        //public double SourceLat { get; set; }
        //public double DestinationLong { get; set; }
        //public double DestinationLat { get; set; }
        public string FlightCode { get; set; }
        //public string PictureOfAirPlane { get; set; }
        //public string AirLainName { get; set; }
        //public int directionFly { get; set; }
        public DateTime DateToday { get; set; }
    }
}
