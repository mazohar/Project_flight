using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Entities
{
    public class FlightsContext : DbContext
    {
        public FlightsContext() : base("FlightDB")
        {
        }

        public DbSet<FlightDB> flights { get; set; }

    }
}
