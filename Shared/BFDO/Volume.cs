using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Shared.BFDO
{
    public class Volume
    {
        public int RefreshNr { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }
        public Util.VolType Type { get; set; }
    }
}
