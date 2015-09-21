using Shared.BFDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.GDO 
{
    public class EventItem : MarketCatalogue
    {
        public String MarketDescr
        {
            get { return this.Event.Name; }
         }

        public String StartTime
        {
            get { return this.Description.MarketTime.TimeOfDay.ToString("hh\\:mm"); }
        }


    }
}
