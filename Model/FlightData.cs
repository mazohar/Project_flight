using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FlightData
    {
        public string Id { get; set; }
        public string SourceId { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public DateTime DataAndTime { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string FlightCode { get; set; }
        public int DirectionFly { get; set; }

        public override string ToString()
        {
            return "flight: " + Id + " from " + Source;
        }

        }
}
