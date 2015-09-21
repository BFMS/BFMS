using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Shared.BFDO;
using Shared;
using MySql.Data.MySqlClient;
using System.Data;
using log4net;
using System.Data.Entity.Core.EntityClient;
using System.Data.Common;
namespace DB
{
    public class DBAccess
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(DBAccess));
        //private MySqlHandler mySql = new MySqlHandler();

        public void InsertMarketCat(List<MarketCatalogue> marketCatalogues)
        {
            try
            {
                foreach (MarketCatalogue mc in marketCatalogues)
                {
                    if (!MarketCatExist(mc.MarketId))
                    {
                        //create command and assign the cmd.CommandText and connection from the constructor
                        using (var ctx = new bfmsEntities())
                        {
                            string query = "INSERT INTO marketcatalogue (MarketId, MarketName,MarketDescr,IsMarketDataDelayed,LocalStartTime) VALUES " +
                                      "(@MarketId,@MarketName,@MarketDescr,@IsMarketDataDelayed,@LocalStartTime);";

                            List<MySqlParameter> parms = new List<MySqlParameter>();

                            parms.Add(new MySqlParameter("@MarketId", mc.MarketId));
                            parms.Add(new MySqlParameter("@MarketName", mc.MarketName));
                            parms.Add(new MySqlParameter("@MarketDescr", mc.MarketDescr));
                            parms.Add(new MySqlParameter("@IsMarketDataDelayed", mc.IsMarketDataDelayed.ToString()));
                            parms.Add(new MySqlParameter("@LocalStartTime", mc.Description.MarketTime));


                            //Execute command
                            //mySql.ExecNonQuery(query, parms.ToArray());


                            int noOfRows = ctx.Database.ExecuteSqlCommand(query, parms.ToArray());

                        }
                        using (var ctx = new bfmsEntities())
                        {
                            string query = "INSERT INTO marketdescription (MarketId, IsPersistenceEnabled,IsBspMarket,MarketTime," +
                                  "IsTurnInPlayEnabled,MarketType,MarketBaseRate,IsDiscountAllowed,Wallet,Rules,RulesHasDate,Clarifications) VALUES " +
                                  "(@MarketId,@IsPersistenceEnabled,@IsBspMarket,@MarketTime," +
                                  "@IsTurnInPlayEnabled,@MarketType,@MarketBaseRate,@IsDiscountAllowed,@Wallet,@Rules,@RulesHasDate,@Clarifications);";

                            List<MySqlParameter> parms = new List<MySqlParameter>();
                            parms.Add(new MySqlParameter("@MarketId", mc.MarketId));
                            parms.Add(new MySqlParameter("@IsPersistenceEnabled", mc.Description.IsPersistenceEnabled.ToString()));
                            parms.Add(new MySqlParameter("@IsBspMarket", mc.Description.IsBspMarket.ToString()));
                            parms.Add(new MySqlParameter("@MarketTime", mc.Description.MarketTime));
                            //parms.Add(new MySqlParameter("@SuspendTime", mc.Description.SuspendTime));
                            //parms.Add(new MySqlParameter("@SettleTime", mc.Description.SettleTime));
                            parms.Add(new MySqlParameter("@IsTurnInPlayEnabled", mc.Description.IsTurnInPlayEnabled.ToString()));
                            parms.Add(new MySqlParameter("@MarketType", mc.Description.MarketType));
                            parms.Add(new MySqlParameter("@MarketBaseRate", mc.Description.MarketBaseRate));
                            parms.Add(new MySqlParameter("@IsDiscountAllowed", mc.Description.IsDiscountAllowed.ToString()));
                            parms.Add(new MySqlParameter("@Wallet", mc.Description.Wallet));
                            parms.Add(new MySqlParameter("@Rules", mc.Description.Rules));
                            parms.Add(new MySqlParameter("@RulesHasDate", mc.Description.RulesHasDate.ToString()));
                            parms.Add(new MySqlParameter("@Clarifications", mc.Description.Clarifications));


                            //Execute command
                            //mySql.ExecNonQuery(query, parms.ToArray());
                            int noOfRows = ctx.Database.ExecuteSqlCommand(query, parms.ToArray());

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Fatal(Util.FormatExc(ex));

            }

        }

        private bool MarketCatExist(String marketId)
        {
            bool result = false;
            try
            {
                using (var ctx = new bfmsEntities())
                {
                    string query = @"SELECT EXISTS(SELECT 1 FROM MarketCatalogue WHERE MarketId=@MarketId LIMIT 1)";
                    List<MySqlParameter> parms = new List<MySqlParameter>();
                    parms.Add(new MySqlParameter("@MarketId", marketId));
                    //result = (long)mySql.ExecScalar(query, parms.ToArray()) > 0;
                    var rows = (ctx.Database.SqlQuery<int>(query, parms.ToArray())).ToList<int>();
                    result = rows.Count > 0 && rows[0] > 0;
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(Util.FormatExc(ex));

            }

            return result;
        }


        public void InsertMarketBook(List<MarketBook> marketBooks)
        {

            try
            {
                foreach (MarketBook mb in marketBooks)
                {
                    if (mb.Status == MarketStatus.OPEN && mb.volumeTraded && !mb.IsInplay && mb.Runners != null && mb.Runners.Count > 0)
                    {
                        if (mb.DBRefreshNr == 0)
                        {
                            int lastDBRefreshNr = 0;
                            Dictionary<string, int> RefNr = GetLastRefreshNr(mb.MarketId);
                            if (RefNr.ContainsKey(mb.MarketId))
                            {
                                RefNr.TryGetValue(mb.MarketId, out lastDBRefreshNr);

                            }
                            //MarketBook bereits vorhanden
                            if (mb.DBRefreshNr <= lastDBRefreshNr)
                            {
                                mb.DBRefreshNr = (int)lastDBRefreshNr;
                            }
                        }
                        mb.DBRefreshNr = ++mb.DBRefreshNr;
                        mb.RefreshTS = DateTime.Now;

                        using (var ctx = new bfmsEntities())
                        {
                            string query = "INSERT INTO marketbook (MarketId, RefreshNr,RefreshTS,IsMarketDataDelayed,Status,BetDelay,IsInplay,NumberOfWinners,NumberOfRunners,NumberOfActiveRunners,TotalMatched,TotalAvailable,OVRBack,OVRLay) VALUES " +
                                    "(@MarketId,@RefreshNr,@RefreshTS,@IsMarketDataDelayed,@Status,@BetDelay,@IsInplay,@NumberOfWinners,@NumberOfRunners,@NumberOfActiveRunners,@TotalMatched,@TotalAvailable,@OVRBack,@OVRLay);";

                            List<MySqlParameter> parms = new List<MySqlParameter>();
                            parms.Add(new MySqlParameter("@MarketId", mb.MarketId));
                            parms.Add(new MySqlParameter("@RefreshNr", mb.DBRefreshNr));
                            parms.Add(new MySqlParameter("@RefreshTS", mb.RefreshTS));
                            parms.Add(new MySqlParameter("@IsMarketDataDelayed", mb.IsMarketDataDelayed.ToString()));
                            parms.Add(new MySqlParameter("@Status", mb.Status.ToString()));
                            parms.Add(new MySqlParameter("@BetDelay", mb.BetDelay));
                            parms.Add(new MySqlParameter("@IsInplay", mb.IsInplay.ToString()));
                            parms.Add(new MySqlParameter("@NumberOfWinners", mb.NumberOfWinners));
                            parms.Add(new MySqlParameter("@NumberOfRunners", mb.NumberOfRunners));
                            parms.Add(new MySqlParameter("@NumberOfActiveRunners", mb.NumberOfActiveRunners));
                            parms.Add(new MySqlParameter("@TotalMatched", mb.TotalMatched));
                            parms.Add(new MySqlParameter("@TotalAvailable", mb.TotalAvailable));
                            parms.Add(new MySqlParameter("@OVRBack", mb.OVRBack));
                            parms.Add(new MySqlParameter("@OVRLay", mb.OVRLay));


                            //Execute command
                            int noOfRows = ctx.Database.ExecuteSqlCommand(query, parms.ToArray());
                        }

                        using (var ctx = new bfmsEntities())
                        {
                            string query = "INSERT INTO runner (MarketId, SelectionId,RefreshNr,Name,RunnerStatus,RemovalDate,Handicap,AdjustmentFactor," +
                                "ToBackTotal,ToLayTotal,BackLayRatio,LastPriceTraded,VolPrice,AvgPrice,Matched,MatchedTotal,VolumeBack,VolumeLay,InsMoneyBack,InsMoneyLay,Indikator1,Indikator2) VALUES ";
                            int cnt = 0;
                            List<MySqlParameter> parms = new List<MySqlParameter>();
                            foreach (Runner runner in mb.Runners)
                            {
                                runner.RefreshNr = mb.DBRefreshNr;
                                query = query + "(@MarketId" + cnt + ",@SelectionId" + cnt + ",@RefreshNr" + cnt + ",@Name" + cnt + ",@RunnerStatus" + cnt + ",@RemovalDate" + cnt + ",@Handicap" + cnt + ",@AdjustmentFactor" + cnt + "," +
                                        "@ToBackTotal" + cnt + ",@ToLayTotal" + cnt + ",@BackLayRatio" + cnt + ",@LastPriceTraded" + cnt + ",@VolPrice" + cnt + ",@AvgPrice" + cnt + ",@Matched" + cnt + ",@MatchedTotal" + cnt + ",@VolumeBack" + cnt + ",@VolumeLay" + cnt + ",@InsMoneyBack" + cnt + ",@InsMoneyLay" + cnt + ",@Indikator1" + cnt + ",@Indikator2" + cnt + "),";

                                //create command and assign the query and connection from the constructor

                                parms.Add(new MySqlParameter("@MarketId" + cnt, mb.MarketId));
                                parms.Add(new MySqlParameter("@SelectionId" + cnt, runner.SelectionId));
                                parms.Add(new MySqlParameter("@RefreshNr" + cnt, runner.RefreshNr));
                                parms.Add(new MySqlParameter("@Name" + cnt, runner.RunnerName));
                                parms.Add(new MySqlParameter("@RunnerStatus" + cnt, runner.Status.ToString()));
                                parms.Add(new MySqlParameter("@RemovalDate" + cnt, runner.RemovalDate));
                                parms.Add(new MySqlParameter("@Handicap" + cnt, runner.Handicap));
                                parms.Add(new MySqlParameter("@AdjustmentFactor" + cnt, runner.AdjustmentFactor));
                                //parms.Add(new MySqlParameter("@ToBackTotal" + cnt, runner.ExchangePrices.AvailableToBack.Count < 3 ? runner.ToBackTotal : Math.Round(runner.ToBackTotal - runner.ExchangePrices.AvailableToBack[2].Size, 2)));
                                //parms.Add(new MySqlParameter("@ToLayTotal" + cnt, runner.ExchangePrices.AvailableToLay.Count < 3 ? runner.ToLayTotal : Math.Round(runner.ToLayTotal - runner.ExchangePrices.AvailableToLay[2].Size, 2)));
                                parms.Add(new MySqlParameter("@ToBackTotal" + cnt, runner.ToBackTotal));
                                parms.Add(new MySqlParameter("@ToLayTotal" + cnt, runner.ToLayTotal));
                                parms.Add(new MySqlParameter("@BackLayRatio" + cnt, runner.BackLayRatio));
                                parms.Add(new MySqlParameter("@LastPriceTraded" + cnt, runner.LastPriceTraded));
                                parms.Add(new MySqlParameter("@VolPrice" + cnt, runner.VolPrice));
                                parms.Add(new MySqlParameter("@AvgPrice" + cnt, runner.AvgPrice));
                                parms.Add(new MySqlParameter("@Matched" + cnt, runner.ActMatched));
                                parms.Add(new MySqlParameter("@MatchedTotal" + cnt, runner.MatchedVol));
                                parms.Add(new MySqlParameter("@VolumeBack" + cnt, runner.VolumeBack));
                                parms.Add(new MySqlParameter("@VolumeLay" + cnt, runner.VolumeLay));
                                parms.Add(new MySqlParameter("@InsMoneyBack" + cnt, runner.InsMoneyBack));
                                parms.Add(new MySqlParameter("@InsMoneyLay" + cnt, runner.InsMoneyLay));
                                parms.Add(new MySqlParameter("@Indikator1" + cnt, runner.Indikator1));
                                parms.Add(new MySqlParameter("@Indikator2" + cnt, runner.Indikator2));

                                //runner.RefreshNr = mb.RefreshNr;
                                InsertVolume(runner, mb);
                                ++cnt;
                            }
                            query = query.Remove(query.Length - 1, 1) + ";";
                            int noOfRows = ctx.Database.ExecuteSqlCommand(query, parms.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(Util.FormatExc(ex));

            }
        }

        private void InsertVolume(Runner runner, MarketBook marketBook)
        {
            try
            {
                if (runner.ActTradedVol != null && runner.ActTradedVol.Count > 0)
                {
                    using (var ctx = new bfmsEntities())
                    {
                        string query = "INSERT INTO volume (MarketId, SelectionId,RefreshNr,Type,Price,Size) VALUES ";
                        int cnt = 0;
                        List<MySqlParameter> parms = new List<MySqlParameter>();
                        foreach (Volume ps in runner.ActTradedVol)
                        {
                            query = query + "(@MarketId" + cnt + ",@SelectionId" + cnt + ",@RefreshNr" + cnt + ",@Type" + cnt + ",@Price" + cnt + ",@Size" + cnt + "),";

                            parms.Add(new MySqlParameter("@MarketId" + cnt, marketBook.MarketId));
                            parms.Add(new MySqlParameter("@SelectionId" + cnt, runner.SelectionId));
                            parms.Add(new MySqlParameter("@RefreshNr" + cnt, runner.RefreshNr));
                            parms.Add(new MySqlParameter("@Type" + cnt, ps.Type.ToString()));
                            parms.Add(new MySqlParameter("@Price" + cnt, ps.Price));
                            parms.Add(new MySqlParameter("@Size" + cnt, ps.Size));

                            ++cnt;
                        }
                        query = query.Remove(query.Length - 1, 1) + ";";
                        int noOfRows = ctx.Database.ExecuteSqlCommand(query, parms.ToArray());
                    }
                }

                if (runner.ExchangePrices != null && runner.ExchangePrices.AvailableToBack.Count > 0)
                {
                    using (var ctx = new bfmsEntities())
                    {
                        string query = "INSERT INTO volume (MarketId, SelectionId,RefreshNr,Type,Price,Size) VALUES ";

                        int cnt = 0;
                        List<MySqlParameter> parms = new List<MySqlParameter>();
                        foreach (PriceSize ps in runner.ExchangePrices.AvailableToBack)
                        {

                            query = query + "(@MarketId" + cnt + ",@SelectionId" + cnt + ",@RefreshNr" + cnt + ",@Type" + cnt + ",@Price" + cnt + ",@Size" + cnt + "),";
                            parms.Add(new MySqlParameter("@MarketId" + cnt, marketBook.MarketId));
                            parms.Add(new MySqlParameter("@SelectionId" + cnt, runner.SelectionId));
                            parms.Add(new MySqlParameter("@RefreshNr" + cnt, runner.RefreshNr));
                            parms.Add(new MySqlParameter("@Type" + cnt, "ATB"));
                            parms.Add(new MySqlParameter("@Price" + cnt, ps.Price));
                            parms.Add(new MySqlParameter("@Size" + cnt, ps.Size));

                            ++cnt;
                        }
                        query = query.Remove(query.Length - 1, 1) + ";";
                        int noOfRows = ctx.Database.ExecuteSqlCommand(query, parms.ToArray());
                    }
                }

                if (runner.ExchangePrices != null && runner.ExchangePrices.AvailableToLay.Count > 0)
                {
                    using (var ctx = new bfmsEntities())
                    {
                        string query = "INSERT INTO volume (MarketId, SelectionId,RefreshNr,Type,Price,Size) VALUES ";
                        int cnt = 0;
                        List<MySqlParameter> parms = new List<MySqlParameter>();
                        foreach (PriceSize ps in runner.ExchangePrices.AvailableToLay)
                        {
                            query = query + "(@MarketId" + cnt + ",@SelectionId" + cnt + ",@RefreshNr" + cnt + ",@Type" + cnt + ",@Price" + cnt + ",@Size" + cnt + "),";
                            parms.Add(new MySqlParameter("@MarketId" + cnt, marketBook.MarketId));
                            parms.Add(new MySqlParameter("@SelectionId" + cnt, runner.SelectionId));
                            parms.Add(new MySqlParameter("@RefreshNr" + cnt, runner.RefreshNr));
                            parms.Add(new MySqlParameter("@Type" + cnt, "ATL"));
                            parms.Add(new MySqlParameter("@Price" + cnt, ps.Price));
                            parms.Add(new MySqlParameter("@Size" + cnt, ps.Size));

                            ++cnt;
                        }
                        query = query.Remove(query.Length - 1, 1) + ";";
                        int noOfRows = ctx.Database.ExecuteSqlCommand(query, parms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(Util.FormatExc(ex));

            }
        }

        public Dictionary<string, int> GetLastRefreshNr(String marketIds)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            try
            {
                string query = null;
                using (var ctx = new bfmsEntities())
                {
                    query = "SELECT MAX(RefreshNr) as RefreshNr,Marketbook.*  from Marketbook where Marketid in (" + marketIds + ") group by marketid";
                    var RefrNrList = ctx.Database.SqlQuery<marketbook>(query).ToList();

                    foreach (var row in RefrNrList)
                    {

                        result.Add(row.MarketId, row.RefreshNr);

                    }
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(Util.FormatExc(ex));

            }
            return result;
        }




        public List<DataView> GetDataSeries(string marketId, long selId, Util.DataSeries ds)
        {
            List<DataView> res = new List<DataView>();
            string query = "";
            try
            {
                using (var ctx = new bfmsEntities())
                {
                    switch (ds)
                    {
                        case Util.DataSeries.PRICE:
                            query = "SELECT AvgPrice as VolPrice,LastPriceTraded,Matched,ToBackTotal,ToLayTotal FROM Runner JOIN Marketbook using (Marketid,RefreshNr) WHERE Runner.marketid='" + marketId +
                                    "' AND Runner.SelectionId =" + selId + " AND Runner.Matched>0 AND Marketbook.RefreshNr>1 AND Marketbook.IsinPlay='False'";
                            break;
                        case Util.DataSeries.VOLUME:
                            Console.WriteLine("Case 2");
                            break;
                    }

                    //var data1 = (from run in ctx.runners
                    //             from book in ctx.marketbooks
                    //             where (book.MarketId == run.MarketId && book.RefreshNr == run.RefreshNr)
                    //             && (book.MarketId == marketId) && (run.SelectionId == selId)
                    //             //select new { book, run=run.AvgPrice as VolPrice,run, vol }).ToList();
                    //             select new { run.AvgPrice, run.LastPriceTraded, run.Matched, run.ToBackTotal, run.ToLayTotal });


                    res.Add(ToDataTable(ctx, query).AsDataView());
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(Util.FormatExc(ex));

            }
            return res;
        }


        public List<RunnerDescription> GetRunnerDesc(string marketId)
        {
            List<RunnerDescription> res = new List<RunnerDescription>();
            try
            {
                using (var ctx = new bfmsEntities())
                {
                    int minRefrNr = (from run in ctx.runners where (run.MarketId == marketId) select run.RefreshNr).Min();
                    var data = (from run in ctx.runners
                                where (run.MarketId == marketId) && (run.RunnerStatus == "ACTIVE") && (run.RefreshNr == minRefrNr)
                                orderby run.AvgPrice                           
                                //select new { book, run=run.AvgPrice as VolPrice,run, vol }).ToList();
                                select new { run } ).ToList();



                    foreach (var row in data)
                    {
                        RunnerDescription rd = new RunnerDescription();
                        rd.SelectionId = row.run.SelectionId;
                        rd.RunnerName = row.run.Name;
                        res.Add(rd);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(Util.FormatExc(ex));

            }



            return res;
        }

        public DataTable ToDataTable(System.Data.Entity.DbContext ctx, string sql)
        {
            IDbCommand cmd = ctx.Database.Connection.CreateCommand();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql,ctx.Database.Connection.ConnectionString);
            DataTable dt = new DataTable("sd");

            try
            {
                cmd.Connection.Open();
                adapter.FillSchema(dt, SchemaType.Source);
                adapter.Fill(dt);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }






    }
}
