using Shared.BFDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.GDO
{
    public class Market
    {
        public Market()
        {
        }

        public Market(MarketBook book)
        {
            marketCatalogue = book.marketCatalogue;
            MarketId = book.MarketId;
            RefreshNr = book.RefreshNr;
            Status = book.Status.ToString();
            IsInplay = book.IsInplay;
            EventName = book.marketCatalogue.Event.Venue;
            Name = book.marketCatalogue.MarketName;
            Type = book.marketCatalogue.Description.MarketType;
            LocalStartDate = book.marketCatalogue.LocalStartTime.Date;
            LocalStartTime = book.marketCatalogue.LocalStartTime;
            NumberOfWinners = book.NumberOfWinners;
            NumberOfRunners = book.NumberOfRunners;
            NumberOfActiveRunners = book.NumberOfActiveRunners;
            Ovr = book.OVRLay;
            TotalMatched = book.TotalMatched;
            Runners = new List<MarketItem>();
            if (book.Runners != null)
            {
                foreach (Runner runner in book.Runners)
                {
                    MarketItem mi = new MarketItem(runner, book.marketCatalogue.Runners.Find(c => c.SelectionId == runner.SelectionId).RunnerName);
                    Runners.Add(mi);
                    if (runner.LastPrices != null)
                    {
                        runner.LastPrices = null;
                    }

                }
            }
        }

        public Market(MarketCatalogue mc)
        {
            MarketId = mc.MarketId;
            EventName = mc.Event.Venue;
            Name = mc.MarketName;
            Type = mc.Description.MarketType;
            LocalStartDate = mc.LocalStartTime.Date;
            LocalStartTime = mc.LocalStartTime;
            Runners = new List<MarketItem>();
            mc.CheckRunnerStatus();
            foreach (RunnerDescription runner in mc.Runners)
            {
                if (runner.Status == RunnerStatus.ACTIVE)
                {
                    MarketItem mi = new MarketItem(runner);
                    Runners.Add(mi);
                }
            }
        }



        public void Copy(Market market)
        {
            marketCatalogue = market.marketCatalogue;
            MarketId = market.MarketId;
            RefreshNr = market.RefreshNr;
            Ovr = market.Ovr;
            Status = market.IsInplay && "OPEN".Equals(market.Status) ? "IN_PLAY" : market.Status.ToString();
            IsInplay = market.IsInplay;
            EventName = market.marketCatalogue.Event.Venue;
            Name = market.marketCatalogue.MarketName;
            Type = market.marketCatalogue.Description.MarketType;
            LocalStartDate = market.marketCatalogue.LocalStartTime.Date;
            LocalStartTime = market.marketCatalogue.LocalStartTime;
            NumberOfWinners = market.NumberOfWinners;
            NumberOfRunners = market.NumberOfRunners;
            NumberOfActiveRunners = market.NumberOfActiveRunners;
            TotalMatched = market.TotalMatched;
            List<MarketItem> nonRunners = new List<MarketItem>();
            foreach (MarketItem item in Runners)
            {
                MarketItem mi = market.Runners.Find(c => c.SelectionId == item.SelectionId);
                if (mi == null)
                {//Teilnehmer furde zurückgezogen ->Nichtstarter
                    item.Status = RunnerStatus.REMOVED;
                    item.LastPriceTraded = 0;
                    item.Matched = 0;
                    item.TotalMatched = 0;
                    item.VolumeBack = 0;
                    item.VolumeLay = 0;
                    item.InsMoneyBack = 0;
                    item.InsMoneyLay = 0;
                    item.RelativeExposure = 0;
                    item.AvgOdds = 0;
                    item.Indikator1 = 0;
                    item.Indikator2 = 0;
                    nonRunners.Add(item);
                }
                else
                {
                    item.SelectionId = mi.SelectionId;
                    item.Status = mi.Status;
                    item.LastPriceTraded = mi.LastPriceTraded;
                    item.Matched = mi.Matched;
                    item.TotalMatched = mi.TotalMatched;
                    item.VolumeBack = mi.VolumeBack;
                    item.VolumeLay = mi.VolumeLay;
                    item.InsMoneyBack = mi.InsMoneyBack;
                    item.InsMoneyLay = mi.InsMoneyLay;
                    item.RelativeExposure = mi.RelativeExposure;
                    item.AvgOdds = mi.AvgOdds;
                    item.Indikator1 = mi.Indikator1;
                    item.Indikator2 = mi.Indikator2;
                }
            }
            if (nonRunners.Count > 0)
            {
                foreach (MarketItem item in nonRunners)
                {
                    Runners.Remove(item);
                    Runners.Add(item);
                }
            }
        }

        public Market Clone()
        {
            Market market = (Market)MemberwiseClone();
            market.Runners = new List<MarketItem>();
            foreach (MarketItem marketItem in this.Runners)
            {
                MarketItem mi = marketItem.Clone();
                market.Runners.Add(mi);
            }

            return market;
        }

        public MarketCatalogue marketCatalogue { get; set; }

        public string MarketId { get; set; }
        public int RefreshNr { get; set; }
        public string Status { get; set; }
        public bool IsInplay { get; set; }
        public string EventName;       // Rennbahnname lang
        public string Name;            // 2m Juv Hrd
        public string Type;            // WIN, PLACE
        public double Ovr;             // Overround
        public DateTime LocalStartDate;
        public DateTime LocalStartTime;
        public TimeSpan TimeToStart;
        public int NumberOfWinners { get; set; }
        public int NumberOfRunners { get; set; }
        public int NumberOfActiveRunners { get; set; }
        public double TotalMatched { get; set; }
        public List<MarketItem> Runners { get; set; }
    }
}
