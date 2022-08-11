using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class HelperClass
    {
        //Helper Fanction to convert from unix epoch time human DateTime
        public DateTime GetDateTimeFromEpohc(double Epoch)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, 0); //from start epoch time
            start = start.AddSeconds(Epoch);//add the second to the start DateTime
            return start;
        }

    }
}
