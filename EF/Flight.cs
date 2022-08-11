using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace EF
{
    public class Flight
    {
        public FlightDetails flight { get; set; }
        public DateTime Date { get; set; }
    }
}
