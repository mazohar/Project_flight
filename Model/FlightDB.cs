using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //An entity that contains relevant details about a flight that is saved in a database
    public class FlightDB
    {
        public string Id { get; set; }
        public string SourceCode { get; set; }
        public string SourceName { get; set; }
        public string DestinationCode { get; set; }
        public string DestinationName { get; set; }
        public string FlightCode { get; set; }
        public DateTime DateToday { get; set; }
    }
}
