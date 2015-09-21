using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Shared.BFDO
{
    public class TimeRange
    {
        public TimeRange(){}
        public TimeRange(DateTime dt)
        {
            From = dt.AddMinutes(-10);
            To = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
        }
        [JsonProperty(PropertyName = "from")]
        public DateTime From { get; set; }

        [JsonProperty(PropertyName = "to")]
        public DateTime To { get; set; }

        public override string ToString()
        {
            return new StringBuilder().AppendFormat("{0}", "TimeRange")
                        .AppendFormat(" : From={0}", From)
                        .AppendFormat(" : To={0}", To)
                        .ToString();
        }
    }
}
