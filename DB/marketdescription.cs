//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class marketdescription
    {
        public string MarketId { get; set; }
        public string IsPersistenceEnabled { get; set; }
        public string IsBspMarket { get; set; }
        public Nullable<System.DateTime> MarketTime { get; set; }
        public string IsTurnInPlayEnabled { get; set; }
        public string MarketType { get; set; }
        public Nullable<double> MarketBaseRate { get; set; }
        public string IsDiscountAllowed { get; set; }
        public string Wallet { get; set; }
        public string Rules { get; set; }
        public string RulesHasDate { get; set; }
        public string Clarifications { get; set; }
    }
}
