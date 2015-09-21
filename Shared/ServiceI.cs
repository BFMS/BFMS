using Shared.BFDO;
using System.Collections.Generic;

namespace Shared
{
    public interface ServiceI
    {
        void login();
        List<MarketCatalogue> GetMarkets();
        MarketBook GetMarketBook(string marketId);
        List<MarketBook> GetMarketBooks(List<string> marketIdLst);
    }
}
