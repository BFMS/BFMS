using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Collections.Concurrent;
using System.Reflection;
using BFAPI;
using Shared;
using Shared.BFDO;
using System.Resources;

// This example pulls the latest horse races in the UK markets
// and displays them to the console.
public class ConsoleExample
{
    public static ConcurrentQueue<MarketCatalogue> Markets = new ConcurrentQueue<MarketCatalogue>();

   public static void Main()
    {
        // TODO:// replace with your app details and Betfair username/password
       BetfairClient client = new BetfairClient(Exchange.UK);
        client.Login( "nur1euro", "niedero", "nur1euro");

        // find all the upcoming UK horse races (EventTypeId 7)
        var marketFilter = new MarketFilter();
        marketFilter.EventTypeIds = new HashSet<string>() { "7" };
        marketFilter.MarketStartTime = new TimeRange()
        {
            From = DateTime.Now,
            To = DateTime.Now.AddDays(1)
        };
        marketFilter.MarketTypeCodes = new HashSet<String>() { "WIN" };
        var eventTypes = client.ListEventTypes(marketFilter);

        Console.WriteLine("BetfairClient.ListTimeRanges()");
        var timeRanges = client.ListTimeRanges(marketFilter, TimeGranularity.HOURS).Result;
        if (timeRanges.HasError)
            throw new ApplicationException();


          var marketCatalogues = client.ListMarketCatalogue(
            BFUtil.HorseRaceFilter("GB"),
            BFUtil.HorseRaceProjection(),
            MarketSort.FIRST_TO_START,
            100).Result.Response;



        marketCatalogues.ForEach(c =>
        {
            //Markets.Enqueue(c);
            List<String> marketIdList = new List<string>();
            marketIdList.Add(c.MarketId);
            OrderProjection orderProjection = OrderProjection.ALL;
            MatchProjection matchProjection = MatchProjection.NO_ROLLUP;

            var marketBook = client.ListMarketBook(
                marketIdList,
                BFUtil.HorseRacePriceProjection(),
                orderProjection,
                matchProjection
            ).Result.Response;
            Console.WriteLine(BFUtil.checkMarket(c, marketBook[0]));
            //Console.WriteLine(c.MarketName);
        });
        Console.WriteLine();

        var marketListener = MarketListener.Create(client, BFUtil.HorseRacePriceProjection(), 1);

        //while (Markets.Count > 0)
        //{
            AutoResetEvent waitHandle = new AutoResetEvent(false);
            MarketCatalogue marketCatalogue;
            Markets.TryDequeue(out marketCatalogue);

            var marketSubscription = marketListener.SubscribeMarketBook(marketCatalogue.MarketId)
                .SubscribeOn(Scheduler.Default)
                .Subscribe(
                tick =>
                {
                    Console.WriteLine(BFUtil.MarketBookConsole(marketCatalogue, tick, marketCatalogue.Runners));
                },
                () =>
                {
                    Console.WriteLine("Market finished");
                    waitHandle.Set();
                });

            waitHandle.WaitOne();
            marketSubscription.Dispose();
        //}
       
        Console.WriteLine("done.");
        Console.ReadLine();
    }
}
