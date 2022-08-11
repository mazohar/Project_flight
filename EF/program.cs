using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class program
    {
        static void Main(string[] args)
        {

            using (var ctx = new FlightsContext())
            {
                var stud = new Flight();

                ctx.flights.Add(stud);
                ctx.SaveChanges();
            }
        }
    }
}
