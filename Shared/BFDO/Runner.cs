using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections;

namespace Shared.BFDO
{
    [Serializable]
    public class Runner
    {
        public Runner()
        {
        }

        public Runner Clone()
        {
            return (Runner)MemberwiseClone();
        }


        public MarketBook MarketBook { get; set; }
        public Runner LastPrices { get; set; }

        [JsonProperty(PropertyName = "selectionId")]
        public long SelectionId { get; set; }

        [JsonProperty(PropertyName = "handicap")]
        public double? Handicap { get; set; }

        [JsonProperty(PropertyName = "status")]
        public RunnerStatus Status { get; set; }

        [JsonProperty(PropertyName = "adjustmentFactor")]
        public double? AdjustmentFactor { get; set; }

        [JsonProperty(PropertyName = "lastPriceTraded")]
        public double? LastPriceTraded { get; set; }

        [JsonProperty(PropertyName = "totalMatched")]
        public double TotalMatched { get; set; }

        [JsonProperty(PropertyName = "removalDate")]
        public DateTime? RemovalDate { get; set; }

        [JsonProperty(PropertyName = "sp")]
        public StartingPrices StartingPrices { get; set; }

        [JsonProperty(PropertyName = "ex")]
        public ExchangePrices ExchangePrices { get; set; }

        [JsonProperty(PropertyName = "orders")]
        public List<Order> Orders { get; set; }

        [JsonProperty(PropertyName = "matches")]
        public List<Match> Matches { get; set; }

        public int RefreshNr { get; set; }
        public string RunnerName { get; set; }
        public double ActMatched { get; set; }
        public double MatchedVol { get; set; }
        public double TotalExposure { get; set; }
        public double RelativeExposure { get; set; }
        public double AvgPrice { get; set; }
        public double VolPrice { get; set; }
        public double ToBackTotal { get; set; }
        public double ToLayTotal { get; set; }
        public double BackLayRatio { get; set; }
        public double VolumeBack { get; set; }
        public double VolumeLay { get; set; }
        public double InsMoneyBack { get; set; }
        public double InsMoneyLay { get; set; }

        public double Indikator1 { get; set; }
        public double Indikator2 { get; set; }

        public List<PriceSize> TradedVol { get; set; }
        public List<Volume> ActTradedVol = new List<Volume>();

        public double RegAngle { get; set; }
        public List<double> priceIdx = new List<double>();
        public List<double> PriceIdx
        {
            get { return priceIdx; }
            set
            {
                priceIdx = value;
                if (priceIdx.Count > 15)
                {
                    priceIdx.RemoveAt(0);
                }
            }
        }
        public List<double> lptMA = new List<double>();
        public List<double> LPTMA
        {
            get { return lptMA; }
            set
            {
                lptMA = value;
                if (lptMA.Count > 15)
                {
                    lptMA.RemoveAt(0);
                }
            }
        }



        static int cnt = 0;





        public bool isGambler()
        {
            return (Indikator1 > 0 && Indikator1 < 0.4) && (Indikator2 > 0 && Indikator2 < 0.75);
            // return (Indikator1 > 0 && Indikator1 < 0.75);
        }

        public bool calcRunnerValues()
        {
            //ActTradedVol= new List<Volume>();

            VolPrice = LastPrices.VolPrice;
            TotalExposure = LastPrices.TotalExposure;
            VolumeBack = LastPrices.VolumeBack;
            VolumeLay = LastPrices.VolumeLay;
            InsMoneyBack = LastPrices.InsMoneyBack;
            InsMoneyLay = LastPrices.InsMoneyLay;
            PriceIdx = LastPrices.PriceIdx;
            LPTMA = LastPrices.LPTMA;
            MatchedVol = LastPrices.MatchedVol;
            if (LastPriceTraded == null || LastPriceTraded == 0)
            {
                LastPriceTraded = ExchangePrices.AvailableToBack.Count > 0 ? ExchangePrices.AvailableToBack.First().Price : 0;
            }

            PriceIdx.Add(BFUtil.GetPriceIdx((double)LastPriceTraded));
            LPTMA.Add(Util.getMA(PriceIdx, 16, TicTacTec.TA.Library.Core.MAType.Ema));
            RegAngle = Util.getLinearRegAngle(LPTMA, 16);

            ToBackTotal = Math.Round(ExchangePrices.AvailableToBack.Sum(a => a.Size), 2);
            ToLayTotal = Math.Round(ExchangePrices.AvailableToLay.Sum(a => a.Size), 2);
            BackLayRatio = ToBackTotal > 0 ? Math.Round(ToBackTotal / (ToBackTotal + ToLayTotal), 2) : LastPrices.BackLayRatio;

            TradedVol = ExchangePrices.TradedVolume.Except(LastPrices.ExchangePrices.TradedVolume, new PriceSizeComparer()).ToList();
            if (TradedVol.Count() > 0)
            {

                double exposure = 0;
                double total = 0;
                foreach (PriceSize ps in TradedVol)
                {
                     //Check ob gültiger BFPrice
                    if (BFUtil.IsValidPrice(ps.Price))
                    {
                        Volume actVol = new Volume();
                        actVol.Size = ps.Size - (LastPrices.ExchangePrices.TradedVolume.Count > 0 && LastPrices.ExchangePrices.TradedVolume.Find(a => a.Price == ps.Price) != null
                        ? LastPrices.ExchangePrices.TradedVolume.Find(a => a.Price == ps.Price).Size : 0);

                        actVol.Price = ps.Price;
                        actVol.RefreshNr = this.RefreshNr;

                        exposure = exposure + (actVol.Price * actVol.Size);
                        total = total + actVol.Size;

                        if (LastPrices.ExchangePrices.AvailableToBack != null && LastPrices.ExchangePrices.AvailableToBack.Count > 0 &&
                            (LastPrices.ExchangePrices.AvailableToBack.Find(a => a.Price == actVol.Price) != null ||
                            actVol.Price <= LastPrices.ExchangePrices.AvailableToBack.Last().Price))
                        {

                            VolumeBack = Math.Round(VolumeBack + actVol.Size, 2);
                            if (this.BackLayRatio > 0.5 && RegAngle < 0)
                            {
                                InsMoneyBack = Math.Round(InsMoneyBack + actVol.Size, 2);
                            }
                            actVol.Type = Util.VolType.TVOLB;
                        }
                        else if (LastPrices.ExchangePrices.AvailableToLay != null && LastPrices.ExchangePrices.AvailableToLay.Count > 0 &&
                            (LastPrices.ExchangePrices.AvailableToLay.Find(a => a.Price == actVol.Price) != null ||
                            actVol.Price > LastPrices.ExchangePrices.AvailableToLay.Last().Price))
                        {
                            VolumeLay = Math.Round(VolumeLay + actVol.Size, 2);
                            if (this.BackLayRatio < 0.5 && RegAngle > 0)
                            {
                                InsMoneyLay = Math.Round(InsMoneyLay + actVol.Size, 2);
                            }
                            actVol.Type = Util.VolType.TVOLL;
                        }
                        if (RefreshNr > 1) { 
                            ActTradedVol.Add(actVol);
                        }
                    }
                }

                VolPrice = Math.Round(exposure / total, 2);
                ActMatched = Math.Round(total, 2);
                TotalExposure = Math.Round(TotalExposure + exposure, 2);
                MatchedVol = MatchedVol + total;
            }
            RelativeExposure = Math.Round(MarketBook.TotalMatched - MatchedVol - TotalExposure, 2);
            AvgPrice = MatchedVol > 0 ? Math.Round(TotalExposure / MatchedVol, 2) : LastPrices.AvgPrice;
            Indikator1 = MatchedVol == 0 || AvgPrice == 0 ? 0 : Math.Round((MarketBook.TotalMatched / MatchedVol) / AvgPrice, 2);
            Indikator2 = RelativeExposure == 0 ? 0 : Math.Round(Math.Abs(MarketBook.TotalMatched / RelativeExposure), 2);

            //if ("Subcontinent".Equals(this.RunnerName) && ActMatched > 0)
            //{
            //    ++cnt;
            //    Console.Out.WriteLine(this.RefreshNr + " " + this.RunnerName + " Steigung :" + RegAngle + "BackLayRatio: " + BackLayRatio);
            //}
            return TradedVol.Count() > 0;

        }
        public override string ToString()
        {
            var sb = new StringBuilder().AppendFormat("SelectionId={0}", SelectionId)
                        .AppendFormat(" : Handicap={0}", Handicap)
                        .AppendFormat(" : Status={0}", Status)
                        .AppendFormat(" : AdjustmentFactor={0}", AdjustmentFactor)
                        .AppendFormat(" : LastPriceTraded={0}", LastPriceTraded)
                        .AppendFormat(" : TotalMatched={0}", TotalMatched)
                        .AppendFormat(" : RemovalDate={0}", RemovalDate);

            if (StartingPrices != null)
            {
                sb.AppendFormat(": {0}", StartingPrices);
            }

            if (ExchangePrices != null)
            {
                sb.AppendFormat(": {0}", ExchangePrices);

            }

            if (Orders != null && Orders.Count > 0)
            {
                int idx = 0;
                foreach (var order in Orders)
                {
                    sb.AppendFormat(" : Order[{0}]={1}", idx++, order);
                }
            }

            if (Matches != null && Matches.Count > 0)
            {
                int idx = 0;
                foreach (var match in Matches)
                {
                    sb.AppendFormat(" : Match[{0}]={1}", idx++, match);
                }
            }

            return sb.ToString();
        }
    }
}
