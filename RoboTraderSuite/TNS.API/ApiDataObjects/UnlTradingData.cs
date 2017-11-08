using System;
using Infra;
using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    /// <summary>
    /// Hold all the trading summary data of all positions of Specific underline security.
    /// </summary>
    public class UnlTradingData : IMessage
    {
        private double _dailyPnL;

        public UnlTradingData()
        {
        }

        public UnlTradingData(ManagedSecurity security)
        {
            //Symbol = security.Symbol;
            Security = security;
            SetLastUpdate();
        }

        public ManagedSecurity Security { get; protected set; }
        public int Id { get; protected set; }
        public EapiDataTypes APIDataType => EapiDataTypes.UnlTradingData;

        #region Object Identification characteristics

        public string Symbol
        {
            get => Security.Symbol;
            set => Security.Symbol = value;
        }

        /// <summary>
        /// Holding the last date time that data and calculated values were updated.
        /// </summary>
        public DateTime LastUpdate { get; set; }

        public void SetLastUpdate()
        {
            LastUpdate = DateTime.Now;
        }

        public int Shorts { get; set; }
        public int Longs { get; set; }
        public ETradingState TradingState { get; set; }

        #endregion


        #region Greek


        public double DeltaTotal { get; set; }
        public double GammaTotal { get; set; }
        public double ThetaTotal { get; set; }
        public double VegaTotal { get; set; }



        /// <summary>
        /// Hold the calculated IV of all positions taking part on trading.<para></para>
        /// = SumOfAll[IV(option)X Position#] / SumOfAll(Position#).
        /// </summary>
        public double IVWeightedAvg { get; set; }

        /// <summary>
        /// The IV on the Call ATM option.
        /// </summary>
        public double ImVolOnCallATM { get; set; }

        /// <summary>
        /// The IV on the Put ATM option.
        /// </summary>
        public double ImVolOnPutATM { get; set; }
        ///// <summary>
        ///// The last known VIX, normally it's updated by the associated manager (TradingManager).
        ///// </summary>
        //public double VIX  { get; set; }

        #endregion

        #region Underline Properties

        public double Price { get; set; }

        public double OpenningPrice { get; set; }

        public double UnlAsk { get; set; }
        public double UnlBid { get; set; }
        public double UnlChange { get; set; }

        #endregion

        public double MarketValue { get; set; }
        public double CostTotal { get; set; }
        public double PnLTotal => MarketValue + CostTotal;
        public double CommisionTotal { get; set; }

        public double LastDayPnL
        {
            get => Security.LastDayPnL;
            set => Security.LastDayPnL = value;
        }

        public double DailyPnL
        {
            get
            {
                _dailyPnL = CostTotal + MarketValue;
                return _dailyPnL;
            }
            set => _dailyPnL = value;
        }

        #region Trading Limitation parameters

        public double MaxAllowedMargin {
            get => Security.MarginMaxAllowed;
            set => Security.MarginMaxAllowed = value;
        }

        /// <summary>
        /// Gets or sets the actual margin for this underline.
        /// </summary>
        public double Margin { get; set; }

        public double UnlHighestPrice { get; set; }
        public double UnlLowestPrice { get; set; }

        #endregion

        public string MainInfo =>
            $"{UnlChange:P}    Base: {OpenningPrice:N}          Bid: {UnlBid:N}   Ask: {UnlAsk:N}    Highest: {UnlHighestPrice:N},   Lowest: {UnlLowestPrice:N}";

       
    }
}
