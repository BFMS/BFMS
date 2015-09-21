using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Shared.GDO;

namespace Shared.BFDO
{
    [Serializable]
    public class MarketCatalogue //: IEquatable<MarketCatalogue>
    {

        [JsonProperty(PropertyName = "marketId")]
        public string MarketId { get; set; }

        [JsonProperty(PropertyName = "marketName")]
        public string MarketName { get; set; }

        [JsonProperty(PropertyName = "isMarketDataDelayed")]
        public bool IsMarketDataDelayed { get; set; }

        [JsonProperty(PropertyName = "description")]
        public MarketDescription Description { get; set; }

        [JsonProperty(PropertyName = "runners")]
        public List<RunnerDescription> Runners { get; set; }

        [JsonProperty(PropertyName = "eventType")]
        public EventType EventType { get; set; }

        [JsonProperty(PropertyName = "event")]
        public Event Event { get; set; }

        [JsonProperty(PropertyName = "competition")]
        public Competition Competition { get; set; }

        public String MarketDescr
        {
            get { return this.Event.Name; }
        }

        public String LocalStartTimeHM
        {
            get { return this.Description.MarketTime.ToLocalTime().TimeOfDay.ToString("hh\\:mm"); }
        }
        public DateTime LocalStartTime
        {
            get { return this.Description.MarketTime.ToLocalTime(); }
        }
        public DateTime StartTime
        {
            get { return this.Description.MarketTime; }
        }


        public void CheckRunnerStatus()
        {
            foreach (RunnerDescription rd in Runners)
            {
                if (Description.Clarifications!=null&&
                    Description.Clarifications.Contains("NR:") &&
                    Description.Clarifications.Contains(rd.RunnerName))
                {
                    rd.Status = RunnerStatus.REMOVED;
                }
                else
                {
                    rd.Status = RunnerStatus.ACTIVE;
                }
            }
        }

        public override string ToString()
        {
            // well, don't bother displaying event/event type/competition
            var sb = new StringBuilder().AppendFormat("{0}", "MarketCatalogue")
                        .AppendFormat(" : Market={0}[{1}]", MarketId, MarketName)
                        .AppendFormat(" : IsMarketDataDelayed={0}", IsMarketDataDelayed);

            if (Description != null)
            {
                sb.AppendFormat(" : {0}", Description);
            }

            if (Runners != null && Runners.Count > 0)
            {
                int idx = 0;
                foreach (var runner in Runners)
                {
                    sb.AppendFormat(" : Runner[{0}]={1}", idx++, runner);
                }
            }

            return sb.ToString();
        }

        //public MarketCatalogue Clone(DB.)
        //{
        //    return (Runner)MemberwiseClone();
        //}


        //public override bool Equals(object obj)
        //{
        //    if (obj == null) return false;
        //    MarketCatalogue objAsPart = obj as MarketCatalogue;
        //    if (objAsPart == null) return false;
        //    else return Equals(objAsPart);
        //}

        //public bool Equals(MarketCatalogue other)
        //{
        //    if (other == null) return false;
        //    return (this.MarketId.Equals(other.MarketId));
        //}
    }
}
