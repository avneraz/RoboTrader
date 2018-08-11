using System;
using System.Net.Http.Headers;
using Infra;
using Infra.Bus;
using Infra.Enum;
using Infra.Extensions;
using static System.Math;


namespace TNS.API.ApiDataObjects
{
    public class OptionData : BaseSecurityData
    {
        /// <summary>
        /// The largest allowed offset from ATM option == 0.07;
        /// </summary>
        private static readonly double MaxDeltaOffsetAllowed =
            AllConfigurations.AllConfigurationsObject.Trading.MaxDeltaOffsetAllowed;
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
        public double DeltaAbsValue => Abs(Delta);

        /// <summary>
        /// Get the delta when the underline price is change by 1 precent.
        /// </summary>
        public double NormalizedDelta => CalculateNormalizedDelta();
        //Get the differnce of the delta and ATM delta (50 is the ideal.)
        public double DeltaOffsetFromATM => Abs(DeltaAbsValue - 0.5);

        public bool IsDeltaOutOfATMLimit => DeltaOffsetFromATM > MaxDeltaOffsetAllowed;
        public double Gamma { get; set; }

        public double Vega { get; set; }

        public double Theta { get; set; }

        public double ImpliedVolatility { get; set; }
      
        public double ModelPrice { get; set; }

        public double UnderlinePrice { get; set; }

        public string OptionKey => OptionContract.OptionKey;
        public string Symbol => OptionContract.Symbol;

        public DateTime Expiry => OptionContract.Expiry;

        public int DaysLeft2 => Expiry.GetDaysToExpired();
        public double CalculatedOptionPrice
        {
            get
            {
               var optionPrice = (Ask <= 0) || Bid <= 0
                    ? (LastPrice <= 0 && ModelPrice >= 0
                        ? ModelPrice
                        : LastPrice)
                    : (Ask + Bid) / 2;
                return optionPrice;
            }
        }
        /// <summary>
        /// Calculate the delta when the underline price is change by 1 precent.
        /// Assuming that Gamma remain unchanged during the iteration.
        /// </summary>
        /// <returns></returns>
        private double CalculateNormalizedDelta()
        {
            double currentUNL = UnderlinePrice;
            var multiplier = (this.Delta < 0) ? -1 : 1;//delta
            double maxUNL = UnderlinePrice * 1.01;//change of 1 %
            double divider = 1;
            double unlForLoop = Math.Floor(maxUNL);
            //assuming Delta> 0 ==> CALL:
            //if (Delta < 0) return 0;

            double delta10 = Math.Abs(Delta) / divider;
            double currentDelta = delta10;
            double totalDelta = 0;// = currentDelta;
            double gamma10 = Gamma / divider;

            while (currentUNL <= unlForLoop)
            {
                totalDelta += currentDelta;
                currentDelta += gamma10;
                currentUNL += 1;

            }
            var fructionDelta = (maxUNL - unlForLoop) * (currentDelta + gamma10);
            return (totalDelta + fructionDelta) * multiplier;



            //double currentUNL = UnderlinePrice;
            //var multiplier = (this.Delta < 0) ? -1 : 1;//delta
            //double maxUNL = UnderlinePrice * 1.01;//change of 1 %
            //double currentDelta = Math.Abs(Delta)/ 10;
            //double totalDelta = 0;// = currentDelta;
            //while (currentUNL <= maxUNL)
            //{
            //    totalDelta += currentDelta;
            //    currentDelta += Gamma/10;
            //    currentUNL += 0.1;

            //}
            //return totalDelta * multiplier;
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
