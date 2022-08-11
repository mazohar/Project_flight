using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EF
{

    public class FlightsContext : DbContext
    {
        public FlightsContext() : base("FlightDB")
        {

        }

        public DbSet<Flight> flights { get; set; }

    }
}
