using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public UnlTradingData()
        {
        }

        public UnlTradingData(string symbol)
        {
            Symbol = symbol;
            SetLastUpdate();
        }
        public EapiDataTypes APIDataType => EapiDataTypes.UnlTradingData;

        #region Object Identification characteristics
        public string Symbol { get; set; }

        /// <summary>
        /// Holding the last date time that data and calculated values were updated.
        /// </summary>
        public DateTime LastUpdate { get; set; }

        public void SetLastUpdate()
        {
            LastUpdate = DateTime.Now;
        }

        public ETradingState TradingState { get; set; }
        #endregion

        #region Greek


        public double DeltaTotal { get; set; }
        public double GammaTotal { get; set; }
        public double ThetaTotal { get; set; }
        public double VegaTotal { get; set; }
        public double MarginTotal { get; set; }

        /// <summary>
        /// Hold the calculated IV of all positions taking part on trading.<para></para>
        /// = SumOfAll[IV(option)X Position#] / SumOfAll(Position#).
        /// </summary>
        public double IVWeightedAvg { get; set; }
        /// <summary>
        /// The last known VIX, normally it's updated by the associated manager (TradingManager).
        /// </summary>
        public double VIX  { get; set; }
        public double UnderlinePrice  { get; set; }
        #endregion

        public double MarketValue { get; set; }
        public double CostTotal { get; set; }
        public double PnLTotal => MarketValue + CostTotal;
        public double CommisionTotal{ get; set; }
        public double LastDayPnL { get; set; }
        public double DailyPnL => PnLTotal - LastDayPnL;

        #region Trading Limitation parameters
        /// <summary>
        /// Gets The max absolute delta allowed on normal trading according the configuration and Margin.
        /// </summary>
        public int MaxAbsoluteDelta => (int)Math.Max(((AllConfigurations.AllConfigurationsObject.Trading.DeltaLossThreshold / 100) * Margin), 100);

        /// <summary>
        /// Gets or sets the actual margin for this underline.
        /// </summary>
        public double Margin { get; set; }
        
        #endregion


    }
}
