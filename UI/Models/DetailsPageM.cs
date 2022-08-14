using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using Entities;

namespace UI.Models
{
    //Model of the details page
    class DetailsPageM
    {
        IBL bl;

        public DetailsPageM()
        {
            bl = new BLImp();
        }

        //Flight details by key
        public FlightDetails getFlightData(string key)
        {
            return bl.getFlightData(key);
        }

        //Weather by location

        public Weather GetWeather(double latatiude, double longitude)
        {
            return bl.GetWeather(latatiude, longitude);
        }
    }
}
