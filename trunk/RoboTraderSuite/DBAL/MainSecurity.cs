//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TNS.DbDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MainSecurity
    {
        public string Symbol { get; set; }
        public string SecType { get; set; }
        public string Exchange { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> OptionsChain { get; set; }
        public string Multiplier { get; set; }
        public Nullable<double> MaxMargin { get; set; }
        public Nullable<int> ExpiryDaysMax { get; set; }
        public Nullable<int> ExpiryDaysMin { get; set; }
        public Nullable<int> LowLoadingStrike { get; set; }
        public Nullable<int> HighLoadingStrike { get; set; }
    }
}