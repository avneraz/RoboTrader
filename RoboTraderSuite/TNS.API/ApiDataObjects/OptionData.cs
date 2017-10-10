using System;
using Infra.Bus;
using Infra.Enum;
using Infra.Extensions;


namespace TNS.API.ApiDataObjects
{
    public class OptionData : BaseSecurityData
    {

        public override EapiDataTypes APIDataType => EapiDataTypes.OptionData;
        public override ContractBase GetContract()
        {
            return OptionContract;
        }

        public override void SetContract(ContractBase contract)
        {
            OptionContract = (OptionContract)contract;
        }

        public virtual OptionContract OptionContract { get; set; }

        public double Delta { get; set; }
        public double DeltaAbsValue => Math.Abs(Delta);
        public double Gamma { get; set; }

        public double Vega { get; set; }

        public double Theta { get; set; }

        public double ImpliedVolatility { get; set; }
      
        public double ModelPrice { get; set; }

        public double UnderlinePrice { get; set; }

        public string OptionKey => OptionContract.OptionKey;
        public string Symbol => OptionContract.Symbol;

        public DateTime Expiry => OptionContract.Expiry;
     

        public double CalculatedOptionPrice
        {
            get
            {
               var optionPrice = (AskPrice <= 0) || BidPrice <= 0
                    ? (LastPrice <= 0 && ModelPrice >= 0
                        ? ModelPrice
                        : LastPrice)
                    : (AskPrice + BidPrice) / 2;
                return optionPrice;
            }
        }

        /// <summary>
        /// Return the price of 1 option (Position = 1)
        /// </summary>
        public double PriceOfOneOption => CalculatedOptionPrice*Multiplier;
        /// <summary>
        /// Gets the days left from now to the expiry date.
        /// </summary>
        /// <value>
        /// The days left.
        /// </value>
        public int DaysLeft
        {
            get
            {
                TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");//Israel Standard Time
                DateTime dateTimeInUsa = TimeZoneInfo.ConvertTime(DateTime.Now, est);
                //if(OptionContract == null)
                //    SetContract(this.GetContract());
                return (int)OptionContract.Expiry.Subtract(dateTimeInUsa).TotalDays;
            }
        }

        public virtual string GetOptionKey()
        {
            return $"{OptionContract.Expiry}.{OptionContract.OptionType}.{OptionContract.Strike}";
        }

        //public virtual string OptionKey { get; set; }

        public override string ToString()
        {
            return $"OptionData : [{base.ToString()},  Delta: {Delta}, Gamma:" +
                   $" {Gamma}, Vega: {Vega}, Theta: {Theta}, ImpliedVolatility: {ImpliedVolatility}," +
                   $" ModelPrice: {ModelPrice}]";
        }
    }
}
