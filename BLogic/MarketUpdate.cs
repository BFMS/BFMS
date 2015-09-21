using Shared;
using Shared.BFDO;
using Shared.GDO;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DB;
using BFAPI;
using log4net;

namespace BLogic
{

    public class MarketUpdate
    {
        private const int MaxMarketsGetMB = 8;     //10 Märkte pro GetMarketBook
        private static readonly ILog logger = LogManager.GetLogger(typeof(DBAccess));

        private ServiceI service;
        public ConcurrentDictionary<string, MarketBook> LastBooks = new ConcurrentDictionary<string, MarketBook>();

        public ConcurrentDictionary<string, MarketCatalogue> markets = new ConcurrentDictionary<string, MarketCatalogue>();
        public bool ThreadStop;
        SynchronizationContext uiContext;
        SendOrPostCallback callbackDelegate;
        private DBAccess dba = new DBAccess();

        ManualResetEvent run = new ManualResetEvent(false);

        public MarketUpdate(ServiceI service)
        {
            this.service = service;
        }

        public void AddMarket(MarketCatalogue market)
        {
            if (!markets.ContainsKey(market.MarketId))
            {
                lock (markets)
                {
                    markets.TryAdd(market.MarketId, market);
                    if (Config.IsDBLogging)
                    {
                        dba.InsertMarketCat(new List<MarketCatalogue>() { market });
                    }
                }
                if (markets.Count == 1)
                {
                    run.Set();
                }
            }
        }
        public void CheckMarkets()
        {
            if (markets.Count > 0)
            {
                lock (markets)
                {
                    dba.InsertMarketCat(markets.Values.ToList());

                    string marketIds = null;
                    foreach (MarketCatalogue mc in markets.Values.ToList())
                    {
                        if (marketIds == null)
                            marketIds = marketIds + mc.MarketId;
                        else
                            marketIds = marketIds + "," + mc.MarketId;

                    }

                    Dictionary<string, int> RefNr = dba.GetLastRefreshNr(marketIds);
                    foreach (string marketId in RefNr.Keys)
                    {
                        int refNr;
                        RefNr.TryGetValue(marketId, out refNr);
                        ((MarketBook)LastBooks[marketId]).RefreshNr = refNr;
                        ((MarketBook)LastBooks[marketId]).DBRefreshNr = refNr;
                    }
                }
            }
        }
        public void AddMarkets(List<MarketCatalogue> marketCat)
        {
            lock (markets)
            {
                foreach (MarketCatalogue mc in marketCat)
                {
                    if (!markets.ContainsKey(mc.MarketId))
                    {
                        markets.TryAdd(mc.MarketId, mc);
                        if (markets.Count == 1)
                        {
                            run.Set();
                        }
                    }
                }
                if (Config.IsDBLogging)
                {
                    dba.InsertMarketCat(marketCat);
                }
            }

        }

        public void RemoveMarket(String marketId)
        {
            if (markets.ContainsKey(marketId))
            {
                MarketCatalogue market;
                lock (markets)
                {
                    markets.TryRemove(marketId, out market);
                    if (markets.Count == 0)
                    {
                        run.Reset();
                    }
                }
            }
        }

        public void RemoveMarkets(List<MarketCatalogue> markets)
        {
            foreach (MarketCatalogue mc in markets)
            {
                RemoveMarket(mc.MarketId);
            }
        }

        public void StartMarketUpdate(SynchronizationContext context, SendOrPostCallback callbackDelegate)
        {
            this.uiContext = context as SynchronizationContext;
            this.callbackDelegate = callbackDelegate;
            Thread th =new Thread(this.PerformMarketUpdate);
            th.IsBackground = true;
            th.Start();
        }

        private void PerformMarketUpdate()
        {
            //List<MarketBook> books = new List<MarketBook>();
            List<String> marketsToRemove = new List<String>();
            List<string> marketIds = new List<string>();
            Util.GUIUpdate guiUpdate = new Util.GUIUpdate();

            int runCnt = 0;
            try
            {
                while (!ThreadStop && run.WaitOne())
                {
                    lock (markets)
                    {
                        if (marketsToRemove.Count > 0)
                        {
                            foreach (String market in marketsToRemove)
                            {
                                if (markets.ContainsKey(market))
                                {
                                    RemoveMarket(market);
                                }
                            }
                            marketsToRemove.Clear();
                        }

                        marketIds.Clear();
                        marketIds = (List<string>)markets.Keys.ToList();


                        if (marketIds.Count > 0)
                        {
                            int nrOfMbGets = (marketIds.Count / MaxMarketsGetMB) + 1;
                            for (int j = 0; j < nrOfMbGets; j++)
                            {
                                List<MarketBook> books = service.GetMarketBooks(marketIds.GetRange(j * MaxMarketsGetMB, j == (nrOfMbGets - 1) ? marketIds.Count % MaxMarketsGetMB : MaxMarketsGetMB));

                                //  books.Sort((p1, p2) => DateTime.Compare(markets.First(c => c.MarketId == p1.MarketId).LocalStartTime, markets.First(c => c.MarketId == p2.MarketId).LocalStartTime));
                                foreach (MarketBook book in books)
                                {
                                    MarketCatalogue mc;
                                    markets.TryGetValue(book.MarketId, out mc);
                                    book.marketCatalogue = mc;

                                    //if (!LastBooks.ContainsKey(book.MarketId))
                                    //{
                                    //    LastBooks.TryAdd(book.MarketId, book);
                                    //}
                                    MarketBook lastBook = LastBooks.ContainsKey(book.MarketId) ? LastBooks[book.MarketId] : book;
                                    book.RefreshNr = ++lastBook.RefreshNr;
                                    book.DBRefreshNr = lastBook.DBRefreshNr;
                                    if (book.Status == MarketStatus.OPEN && book.Runners != null && book.Runners.Count > 0)
                                    {
                                        var nearestBacks = book.Runners.Where(c => c.Status == RunnerStatus.ACTIVE)
                                                        .Select(c => c.ExchangePrices.AvailableToBack.Count > 0 ? c.ExchangePrices.AvailableToBack.First().Price : 0.0);
                                        var nearestLays = book.Runners.Where(c => c.Status == RunnerStatus.ACTIVE)
                                                            .Select(c => c.ExchangePrices.AvailableToLay.Count > 0 ? c.ExchangePrices.AvailableToLay.First().Price : 0.0);

                                        book.OVRBack = Math.Round(BFUtil.GetMarketEfficiency(nearestBacks), 3);
                                        book.OVRLay = Math.Round(BFUtil.GetMarketEfficiency(nearestLays), 3);

                                        foreach (Runner runner in book.Runners)
                                        {
                                            runner.MarketBook = book;
                                            runner.RefreshNr = book.RefreshNr;
                                            runner.RunnerName = mc.Runners.Find(c => c.SelectionId == runner.SelectionId).RunnerName;
                                            if (runner.Status == RunnerStatus.ACTIVE)
                                            {
                                                if (LastBooks.ContainsKey(book.MarketId))
                                                {
                                                    //Runner r = lastBook.Runners.Find(c => c.SelectionId == runner.SelectionId);
                                                    runner.LastPrices = lastBook.Runners.Find(c => c.SelectionId == runner.SelectionId);
                                                    //runner.LastPrices = LastBooks[book.MarketId].Runners.Find(c => c.SelectionId == runner.SelectionId);//MEMORY-Leak
                                                    //runner.LastPrices = (Runner)LastBooks[book.MarketId].Runners[0]; 
                                                }
                                                else
                                                {
                                                    runner.LastPrices = new Runner();
                                                    runner.LastPrices.ExchangePrices = new ExchangePrices();
                                                    runner.LastPrices.ExchangePrices.TradedVolume = new List<PriceSize>();
                                                }
                                                if (Config.ServiceMode == Config.Mode.API)
                                                    if (runner.calcRunnerValues() && !book.volumeTraded)
                                                    {
                                                        book.volumeTraded = true;
                                                    }

                                            }
                                        }

                                        LastBooks[book.MarketId] = book;
                                    }
                                    else if (book.Status == MarketStatus.CLOSED)
                                    {
                                        marketsToRemove.Add(book.MarketId);
                                    }

                                    guiUpdate.updateAction = Util.GUIUpdate.UpdateAction.Market;
                                    guiUpdate.market = new Market(book);
                                    uiContext.Post(callbackDelegate, guiUpdate);

                                }
                                if (Config.IsDBLogging)
                                {
                                    dba.InsertMarketBook(books);
                                }

                            }

                        }
                    }

                    //Test
                    //++runCnt;
                    runCnt = (runCnt + 1) % 5;

                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(Util.FormatExc(ex));
            }
        }
        public void RequestStop()
        {
            lock (markets)
            {
                ThreadStop = true;
                run.Set();
            }
        }

    }
}
