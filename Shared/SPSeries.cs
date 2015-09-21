using System;
using System.Collections.Generic;
using TicTacTec.TA.Library;
using Shared.BFDO;
namespace Shared
{
    [Serializable]
    public class SPSeries
    {
        public static int PRICEARLEN = 200;
        public enum BFSeriesEnum
        {
            LayOdds,
            BackOdds,
            NearSPPrice,
            LastPriceMatched,
            LastPriceMatchedInc,
            SlowBackOddsInc,
            Volume,
            BackVol,
            LayVol,
            BLRatio,
            SMABackOdds,
            SMAFastBackOdds,
            SMAFastBackOddsInc,
            KAMASlowBackOdds,
            KAMASlowBackOddsInc,
            Plus_DI,
            Minus_DI,
            SMA_Plus_DI,
            SMA_Minus_DI,
            AROON_Up,
            AROON_Down,
            LinRegSlopeFastBackOdds,
            SMALinRegSlopeFastBackOdds,
            LinRegSlopeSlowBackOdds,
            SMALinRegSlopeSlowBackOdds,
            EMABLRatio,
            EMAVolume,
            AVG_ODDS,
            RSI,
            MatchedBackVolumeRatio,
            EMAMatchedBackVolumeRatio

        }
        public List<List<double>> BFSeriesLst;
        //private RMI rmi = new RMI();
        //private VMA vma = new VMA();
        public SPSeries()
        {
            BFSeriesLst = new List<List<double>>();
            foreach (string volume in Enum.GetNames(typeof(BFSeriesEnum)))
            {
                BFSeriesLst.Add(new List<double>(PRICEARLEN));
            }
        }


        public void AddY(BFSeriesEnum series, double yvalue)
        {

            BFSeriesLst[(int)series].Add(yvalue);

            if (BFSeriesLst[(int)series].Count > PRICEARLEN)
            {
                BFSeriesLst[(int)series].RemoveAt(0);
            }
        }

        public double GetLast(BFSeriesEnum series)
        {

            if (BFSeriesLst[(int)series].Count > 0)
            {
                return BFSeriesLst[(int)series][BFSeriesLst[(int)series].Count - 1];
            }
            else return 0;
        }


        public void CalcSeries(Runner runner)
        {

            if ((runner.ActMatched > 0 || BFSeriesLst[(int)BFSeriesEnum.BackOdds].Count < 32) &&
                  runner.ExchangePrices.AvailableToLay.Count > 0 && runner.ExchangePrices.AvailableToBack.Count > 0)
            {
                AddY(BFSeriesEnum.LayOdds, runner.ExchangePrices.AvailableToLay[0].Price);
                AddY(BFSeriesEnum.BackOdds, runner.ExchangePrices.AvailableToBack[0].Price);

                //if (runner.amountMatchedPerRefresh > 0)
                //{
                //    AddY(BFSeriesEnum.LastPriceMatched, runner.lastPriceMatched);
                //    AddY(BFSeriesEnum.LastPriceMatchedInc, Prices.getPriceIdx(runner.lastPriceMatched));
                //}
                //else
                //{   //Außschließlich für die ersten 32 Werte
                //    AddY(BFSeriesEnum.LastPriceMatched, runner.pricesToBack[0].price);
                //    AddY(BFSeriesEnum.LastPriceMatchedInc, Prices.getPriceIdx(runner.pricesToBack[0].price));
                //}

                //AddY(BFSeriesEnum.NearSPPrice, runner.nearSPPrice);
                //AddY(BFSeriesEnum.Volume, runner.amountMatchedPerRefresh);
                //AddY(BFSeriesEnum.AVG_ODDS, runner.avgOdds);
                ////AddY(BFSeriesEnum.AVG_ODDS, market.totalAmountMatched / this.totalAmountMatched);

                //AddY(BFSeriesEnum.BLRatio, Math.Round(runner.backLayRatio * 100));
                //AddY(BFSeriesEnum.EMABLRatio, TA.getMA(BFSeriesLst[(int)BFSeriesEnum.BLRatio], 20, Core.MAType.Ema));
                //AddY(BFSeriesEnum.EMAVolume, TA.getMA(BFSeriesLst[(int)BFSeriesEnum.Volume], 64, Core.MAType.Ema));

                //AddY(BFSeriesEnum.SMABackOdds, TA.getMA(BFSeriesLst[(int)BFSeriesEnum.BackOdds], 16, Core.MAType.Ema));
                //AddY(BFSeriesEnum.SMAFastBackOdds, TA.getMA(BFSeriesLst[(int)BFSeriesEnum.LastPriceMatched], 16, Core.MAType.Ema));
                //AddY(BFSeriesEnum.SMAFastBackOddsInc, TA.getMA(BFSeriesLst[(int)BFSeriesEnum.LastPriceMatchedInc], 16, Core.MAType.Ema));

                //AddY(BFSeriesEnum.KAMASlowBackOdds, TA.getKAMA(BFSeriesLst[(int)BFSeriesEnum.LastPriceMatched], 32));
                //AddY(BFSeriesEnum.KAMASlowBackOddsInc, TA.getMA(BFSeriesLst[(int)BFSeriesEnum.LastPriceMatchedInc], 32, Core.MAType.Ema));

                //AddY(BFSeriesEnum.LinRegSlopeFastBackOdds, TA.getLinearRegAngle(BFSeriesLst[(int)BFSeriesEnum.SMAFastBackOddsInc], 8));
                //AddY(BFSeriesEnum.SMALinRegSlopeFastBackOdds, TA.getMA(BFSeriesLst[(int)BFSeriesEnum.LinRegSlopeFastBackOdds], 16, Core.MAType.Ema));

                //AddY(BFSeriesEnum.LinRegSlopeSlowBackOdds, TA.getLinearRegAngle(BFSeriesLst[(int)BFSeriesEnum.KAMASlowBackOddsInc], 8));
                //AddY(BFSeriesEnum.SMALinRegSlopeSlowBackOdds, TA.getMA(BFSeriesLst[(int)BFSeriesEnum.LinRegSlopeSlowBackOdds], 16, Core.MAType.Ema));

                //AddY(BFSeriesEnum.Plus_DI, TA.getPLUS_DI(BFSeriesLst[(int)BFSeriesEnum.LayOdds], BFSeriesLst[(int)BFSeriesEnum.BackOdds], BFSeriesLst[(int)BFSeriesEnum.LastPriceMatched], 32));
                //AddY(BFSeriesEnum.Minus_DI, TA.getMINUS_DI(BFSeriesLst[(int)BFSeriesEnum.LayOdds], BFSeriesLst[(int)BFSeriesEnum.BackOdds], BFSeriesLst[(int)BFSeriesEnum.LastPriceMatched], 32));

                //AddY(BFSeriesEnum.SMA_Plus_DI, TA.getMA(BFSeriesLst[(int)BFSeriesEnum.Plus_DI], 16, Core.MAType.Ema));
                //AddY(BFSeriesEnum.SMA_Minus_DI, TA.getMA(BFSeriesLst[(int)BFSeriesEnum.Minus_DI], 16, Core.MAType.Ema));

                //TA.Ohlc ohlc = TA.getAROON(BFSeriesLst[(int)BFSeriesEnum.LastPriceMatched], BFSeriesLst[(int)BFSeriesEnum.BackOdds], 32);
                //AddY(BFSeriesEnum.AROON_Up, ohlc.high);
                //AddY(BFSeriesEnum.AROON_Down, ohlc.low);

                ////AddY(BFSeriesEnum.RSI, rmi.Calc(BFSeriesLst[(int)BFSeriesEnum.AVG_ODDS], 32, 16).rmi);
                //AddY(BFSeriesEnum.RSI, (TA.getRSI(BFSeriesLst[(int)BFSeriesEnum.SMAFastBackOdds], 32) + TA.getRSI(BFSeriesLst[(int)BFSeriesEnum.KAMASlowBackOdds], 24) + BFSeriesLst[(int)BFSeriesEnum.BLRatio][BFSeriesLst[(int)BFSeriesEnum.EMABLRatio].Count - 1]) / 3);
                ////AddY(BFSeriesEnum.RSI, (TA.getRSI(BFSeriesLst[(int)BFSeriesEnum.SMAFastBackOdds], 32)));
                ////AddY(BFSeriesEnum.RSI, (TA.getRSI(BFSeriesLst[(int)BFSeriesEnum.SMAFastBackOdds], 16) + TA.getRSI(BFSeriesLst[(int)BFSeriesEnum.KAMASlowBackOdds], 16)) / 2);

                //runner.slowIndikator = BFSeriesLst[(int)BFSeriesEnum.KAMASlowBackOdds][BFSeriesLst[(int)BFSeriesEnum.KAMASlowBackOdds].Count - 1];
                //runner.fastIndikator = BFSeriesLst[(int)BFSeriesEnum.SMAFastBackOdds][BFSeriesLst[(int)BFSeriesEnum.SMAFastBackOdds].Count - 1];
            }
        }




        public bool isSteigend(List<double> series, int count)
        {
            bool result = false;
            if (series.Count > 1)
            {
                if (count > series.Count)
                {
                    count = series.Count;
                }
                result = true;
                for (int j = series.Count - count + 1; j < series.Count; j++)
                {
                    //result = result&&series[j] > series[j - 1];
                    result = result && (getSeriesTrend(series[j]) == TrendEnum.STEI || getSeriesTrend(series[j]) == TrendEnum.SSTEI);
                }
            }
            return result;
        }

        public bool isFallend(List<double> series, int count)
        {
            bool result = false;
            if (series.Count > 1)
            {
                if (count > series.Count)
                {
                    count = series.Count;
                }
                result = true;
                for (int j = series.Count - count + 1; j < series.Count; j++)
                {
                    //result = result&&series[j] > series[j - 1];
                    result = result && (getSeriesTrend(series[j]) == TrendEnum.FALL || getSeriesTrend(series[j]) == TrendEnum.SFALL);
                }
            }
            return result;
        }

        public TrendEnum getSeriesTrend(double value)
        {
            TrendEnum result = TrendEnum.GLEI;
            if (value <= 2 && value >= -2) result = TrendEnum.GLEI;
            else if (value > 2 && value <= 8) result = TrendEnum.STEI;
            else if (value < -2 && value >= -8) result = TrendEnum.FALL;
            else if (value > 8) result = TrendEnum.SSTEI;
            else if (value < -8) result = TrendEnum.SFALL;

            return result;
        }


        public TrendEnum checkOddsTrend(Runner runnerPrices)
        //FastLayOdds	|STEADY	   UP	DOWN	STRONG_UP	STRONG_DOWN
        //-------------------------------------------------------------
        //STEADY	    |STEADY	   UP	DOWN	STRONG_UP   STRONG_DOWN
        //UP		    |          UP			
        //DOWN			|               DOWN		
        //STRONG_UP		|		                STRONG_UP	
        //STRONG_DOWN	|				                    STRONG_DOWN
        {
            TrendEnum result = TrendEnum.GLEI;

            int len = BFSeriesLst[(int)BFSeriesEnum.KAMASlowBackOdds].Count;

            if (((BFSeriesLst[(int)BFSeriesEnum.SMAFastBackOdds][len - 1] > BFSeriesLst[(int)BFSeriesEnum.KAMASlowBackOdds][len - 1] &&
                BFSeriesLst[(int)BFSeriesEnum.SMAFastBackOdds][len - 2] > BFSeriesLst[(int)BFSeriesEnum.KAMASlowBackOdds][len - 2] &&
                BFSeriesLst[(int)BFSeriesEnum.SMAFastBackOdds][len - 3] > BFSeriesLst[(int)BFSeriesEnum.KAMASlowBackOdds][len - 3])
                //&&
                //(BFSeriesLst[(int)BFSeriesEnum.SMAFastBackOdds][len - 1] > BFSeriesLst[(int)BFSeriesEnum.SMAFastBackOdds][len - 2] &&
                //BFSeriesLst[(int)BFSeriesEnum.SMAFastBackOdds][len - 2] > BFSeriesLst[(int)BFSeriesEnum.SMAFastBackOdds][len - 3])
               &&
                (BFSeriesLst[(int)BFSeriesEnum.SMA_Plus_DI][len - 1] > BFSeriesLst[(int)BFSeriesEnum.SMA_Minus_DI][len - 1] &&
                BFSeriesLst[(int)BFSeriesEnum.SMA_Plus_DI][len - 2] > BFSeriesLst[(int)BFSeriesEnum.SMA_Minus_DI][len - 2] &&
                BFSeriesLst[(int)BFSeriesEnum.SMA_Plus_DI][len - 3] > BFSeriesLst[(int)BFSeriesEnum.SMA_Minus_DI][len - 3])
                //&&
                // (BFSeriesLst[(int)BFSeriesEnum.SMA_Plus_DI][len - 1] > BFSeriesLst[(int)BFSeriesEnum.SMA_Plus_DI][len - 2] &&
                // BFSeriesLst[(int)BFSeriesEnum.SMA_Plus_DI][len - 2] > BFSeriesLst[(int)BFSeriesEnum.SMA_Plus_DI][len - 3])
                &&
                (BFSeriesLst[(int)BFSeriesEnum.AROON_Up][len - 1] > 95 &&
                BFSeriesLst[(int)BFSeriesEnum.AROON_Up][len - 2] > 95 &&
                BFSeriesLst[(int)BFSeriesEnum.AROON_Up][len - 3] > 95)
                ))
            {
                //result = true;
            }
            return result;
        }

    }

    public enum TrendEnum
    {
        GLEI = 0,
        STEI = 1,
        FALL = -1,
        SSTEI = 2,
        SFALL = -2,
    }


}
