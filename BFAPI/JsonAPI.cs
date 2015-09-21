using BFAPI;
using Shared;
using Shared.BFDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;

namespace BFAPI
{

    public class JsonAPI:ServiceI
    {
         private BetfairClient client = new BetfairClient(Exchange.UK);
         //private static ConcurrentQueue<MarketCatalogue> Markets = new ConcurrentQueue<MarketCatalogue>();
         private static List<MarketCatalogue> Markets = new List<MarketCatalogue>();

         public void login()
         {
             client.Login("nur1euro", "niedero", "nur1euro");
         }


         public List<MarketCatalogue> GetMarkets()
         {
             Markets= client.ListMarketCatalogue(
                                    BFUtil.HorseRaceFilter("GB"),
                                    BFUtil.HorseRaceProjection(),
                                    MarketSort.FIRST_TO_START,
                                    100).Result.Response;
             return Markets;
         }

         public MarketBook GetMarketBook(string marketId)
         {
             return client.ListMarketBook(
                     new List<string>() { marketId },
                     BFUtil.HorseRacePriceProjection(),
                     null,
                     null
                 ).Result.Response[0];
         }

         public List<MarketBook> GetMarketBooks(List<string> marketIdLst)
         {
             return client.ListMarketBook(
                     marketIdLst,
                     BFUtil.HorseRacePriceProjection(),
                     null,
                     null
                 ).Result.Response;
         }


    }
}
