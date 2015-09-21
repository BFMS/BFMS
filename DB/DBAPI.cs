using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Shared.BFDO;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Concurrent;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.EntityClient;

namespace DB
{
    public class DBAPI : ServiceI
    {
        //private MySqlHandler mySql = new MySqlHandler();
        private Dictionary<string, long> LastRefreshNr = new Dictionary<string, long>();
        public DBAPI()
        {

        }
        public void login()
        {
            //client.Login("nur1euro", "niedero", "nur1euro");
        }


        public List<MarketCatalogue> GetMarkets()
        {

            List<MarketCatalogue> lmc = new List<MarketCatalogue>();
            try
            {
                using (var ctx = new bfmsEntities())
                {

                    //ctx.Database.Connection.Open();
                    //var ctx = new bfmsEntities();

                    var MarketCatList = (from cat in ctx.marketcatalogues
                                         join desc in ctx.marketdescriptions on cat.MarketId equals desc.MarketId
                                         orderby cat.LocalStartTime
                                         select new { cat, desc }).ToList();

                    string lastMarketId = "";
                    MarketCatalogue mc = null;
                    foreach (var row in MarketCatList)
                    {
                        if (lastMarketId != row.cat.MarketId)
                        {
                            mc = new MarketCatalogue();
                            mc.MarketId = row.cat.MarketId;
                            mc.MarketName = row.cat.MarketName;
                            mc.Description = new MarketDescription();
                            mc.Description.MarketTime = row.cat.LocalStartTime ?? DateTime.Now; 
                            mc.Description.Clarifications = row.desc.Clarifications;
                            mc.Event = new Event();
                            mc.Event.Name = row.cat.MarketDescr;
                            //mc.EventType = (string)rdr["EventType"];
                            mc.IsMarketDataDelayed = "False".Equals(row.cat.IsMarketDataDelayed) ? false : true;

                            mc.Runners = new List<RunnerDescription>();
                            lmc.Add(mc);
                            lastMarketId = mc.MarketId;
                        }

                        //RunnerDescription rd = new RunnerDescription();
                        //rd.SelectionId = (int)row["SelectionId"];
                        //rd.RunnerName = (string)row["Name"];
                        //mc.Runners.Add(rd);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return lmc;
        }

        public MarketBook GetMarketBook(string marketId)
        {
            MarketBook mb = new MarketBook();
            try
            {
                long lastRefreshNr = 0; ;
                if (LastRefreshNr.ContainsKey(marketId))
                {
                    LastRefreshNr.TryGetValue(marketId, out lastRefreshNr);
                }
                else
                {
                    LastRefreshNr.Add(marketId, lastRefreshNr);
                }
                using (var ctx = new bfmsEntities())
                {
                string query = "SELECT * FROM marketbook JOIN runner USING(Marketid,RefreshNr) " +
                                      "JOIN volume USING (Marketid,Refreshnr,Selectionid) " +
                                      "WHERE Marketid=@MarketId  AND refreshNr=" +
                                      "(SELECT MAX(RefreshNr) FROM marketbook WHERE Marketid=@MarketId AND IsInPlay='False')";
                //"(SELECT MIN(RefreshNr) FROM Marketbook WHERE Marketbook.Marketid=@MarketId AND Marketbook.Status='OPEN' AND Marketbook.IsInPlay='False' AND Marketbook.RefreshNr>@LastRefreshNr)";
                var MaxRefrNr = (from book in ctx.marketbooks where book.MarketId == marketId && book.IsInplay=="False" select book.RefreshNr).Max();
                var MarketCatList = (from book in ctx.marketbooks
                                     from run in ctx.runners 
                                     from vol in ctx.volumes
                                     where (book.MarketId==run.MarketId && book.RefreshNr==run.RefreshNr)&&
                                     (run.MarketId==vol.MarketId&&run.SelectionId==vol.SelectionId&&run.RefreshNr==vol.RefreshNr)
                                     && (book.MarketId == marketId) && (book.RefreshNr == MaxRefrNr)
                                     select new {book,run, vol}).ToList();

                    mb.Runners = new List<Runner>();
                    Runner r = null;
                    long lastSelectionId = 0;
                    foreach (var row in MarketCatList)
                    {
                        if (lastSelectionId == 0)
                        {
                            mb.MarketId = row.book.MarketId;
                            mb.RefreshNr =row.book.RefreshNr;
                            mb.RefreshTS = (DateTime)row.book.RefreshTS;
                            mb.IsMarketDataDelayed = "False".Equals(row.book.IsMarketDataDelayed) ? false : true;
                            mb.Status = (MarketStatus)Enum.Parse(typeof(MarketStatus), row.book.Status.ToString());
                            mb.BetDelay = (int)row.book.BetDelay;
                            mb.IsInplay = "False".Equals(row.book.IsInplay) ? false : true;
                            mb.NumberOfWinners = (int)row.book.NumberOfWinners;
                            mb.NumberOfActiveRunners = (int)row.book.NumberOfActiveRunners;
                            mb.NumberOfRunners = (int)row.book.NumberOfRunners;
                            mb.TotalMatched = (double)row.book.TotalMatched;
                            mb.TotalAvailable = (double)row.book.TotalAvailable;
                            mb.OVRBack = (double)row.book.OVRBack;
                            mb.OVRLay = (double)row.book.OVRLay;

                            LastRefreshNr[marketId] = mb.RefreshNr;

                        }
                        if (lastSelectionId != (int)row.run.SelectionId)
                        {
                            r = new Runner();
                            r.ExchangePrices = new ExchangePrices();
                            r.ExchangePrices.AvailableToBack = new List<PriceSize>();
                            r.ExchangePrices.AvailableToLay = new List<PriceSize>();
                            r.ExchangePrices.TradedVolume = new List<PriceSize>();

                            r.SelectionId = (int)row.run.SelectionId;
                            r.RefreshNr = (int)row.run.RefreshNr;
                            r.RunnerName = (string)row.run.Name;
                            r.Status = (RunnerStatus)Enum.Parse(typeof(RunnerStatus), row.run.RunnerStatus.ToString());
                            r.AdjustmentFactor = (double)row.run.AdjustmentFactor;
                            r.ToBackTotal = (double)row.run.ToBackTotal;
                            r.ToLayTotal = (double)row.run.ToLayTotal;
                            r.BackLayRatio = (double)row.run.BackLayRatio;
                            r.LastPriceTraded = row.run.LastPriceTraded.ToString() == "" ? 0 : (double)row.run.LastPriceTraded;
                            r.VolPrice = (double)row.run.VolPrice;
                            r.AvgPrice = (double)row.run.AvgPrice;
                            r.ActMatched = (double)row.run.Matched;
                            r.MatchedVol = (double)row.run.MatchedTotal;//Namenskonflikt mit Marketbook
                            //r.TotalMatched = (double)row[27];
                            r.VolumeBack = (double)row.run.VolumeBack;
                            r.VolumeLay = (double)row.run.VolumeLay;
                            r.InsMoneyBack = (double)row.run.InsMoneyBack;
                            r.InsMoneyLay = (double)row.run.InsMoneyLay;
                            r.Indikator1 = (double)row.run.Indikator1;
                            r.Indikator2 = (double)row.run.Indikator2;
                            lastSelectionId = r.SelectionId;
                            mb.Runners.Add(r);
                        }
                        if (("ATB").Equals(row.vol.Type.ToString()))
                        {
                            PriceSize ps = new PriceSize();
                            ps.Price = (double)row.vol.Price;
                            ps.Size = (double)row.vol.Size;
                            r.ExchangePrices.AvailableToBack.Add(ps);
                        }
                        if (("ATL").Equals(row.vol.Type.ToString()))
                        {
                            PriceSize ps = new PriceSize();
                            ps.Price = (double)row.vol.Price;
                            ps.Size = (double)row.vol.Size;
                            r.ExchangePrices.AvailableToLay.Add(ps);
                        }
                        if (("TVOL").Equals(row.vol.Type.ToString()))
                        {
                            PriceSize ps = new PriceSize();
                            ps.Price = (double)row.vol.Price;
                            ps.Size = (double)row.vol.Size;
                            r.ExchangePrices.TradedVolume.Add(ps);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return mb;

        }

        public List<MarketBook> GetMarketBooks(List<string> marketIdLst)
        {
            List<MarketBook> mb = new List<MarketBook>();
            try
            {
                foreach (string marketId in marketIdLst)
                {
                    mb.Add(GetMarketBook(marketId));
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return mb;

        }


    }
}
