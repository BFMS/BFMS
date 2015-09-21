using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.BFDO;
namespace Shared.GDO
{
    public class MarketItem
    {
        public MarketItem()
        {

        }

        public  MarketItem(RunnerDescription rd)
        {
            RunnerName = rd.RunnerName;
            SelectionId = rd.SelectionId;
        }
        public MarketItem(Runner runner,string name)
        {
            SelectionId = runner.SelectionId;
            Status=runner.Status;
            LastPriceTraded = runner.LastPriceTraded == null ? (double)0 : (double)runner.LastPriceTraded;
            TotalMatched = Math.Round(runner.MatchedVol, 0);
            Matched = Math.Round(runner.ActMatched,0);
            RunnerName = name;
            RelativeExposure=runner.RelativeExposure;
            AvgOdds=runner.AvgPrice;
            VolumeBack = Math.Round(runner.VolumeBack,0);
            VolumeLay = Math.Round(runner.VolumeLay,0);
            InsMoneyBack = Math.Round(runner.InsMoneyBack,0);
            InsMoneyLay = Math.Round(runner.InsMoneyLay,0);
            Indikator1=runner.Indikator1;
            Indikator2=runner.Indikator2;
        }

        public MarketItem Clone()
        {
            return (MarketItem)MemberwiseClone();
        }

        public long SelectionId { get; set; }

        public RunnerStatus Status { get; set; }

        public double LastPriceTraded { get; set; }

        public double TotalMatched{ get; set; }
        public double Matched { get; set; }
        public string RunnerName { get; set; }

        public double RelativeExposure { get; set; }
        public double AvgOdds { get; set; }
        public double VolumeBack { get; set; }
        public double VolumeLay { get; set; }
        public double InsMoneyBack { get; set; }
        public double InsMoneyLay { get; set; }
        public double Indikator1 { get; set; }
        public double Indikator2 { get; set; }        
    }
}
