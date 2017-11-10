using System;
using System.Linq;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    /// <summary>
    /// Hold all the trading summary data of all positions of Specific underline managedSecurity.
    /// </summary>
    public class UnlTradingData : SecurityData
    {
        private double _dailyPnL;
        private SecurityData _unlSecurityData;
        private double _margin;
        private PositionsSummaryData _positionsSummaryData;

        /// <summary>
        /// Used for mapping:
        /// </summary>
        public UnlTradingData()
        {
        }


        public UnlTradingData(ManagedSecurity managedSecurity, SecurityData unlSecurityData)
        {
            //Symbol = managedSecurity.Symbol;
            ManagedSecurity = managedSecurity;
            UnlSecurityData = unlSecurityData;
            SetLastUpdate();
        }

        public UnlTradingData(ManagedSecurity managedSecurity)
        {
            ManagedSecurity = managedSecurity;
        }

        public new int Id { get; protected set; }
        public override EapiDataTypes APIDataType => EapiDataTypes.UnlTradingData;

        #region Managed Security

        public ManagedSecurity ManagedSecurity { get; protected set; }
        //public string Symbol => ManagedSecurity.Symbol;

        public double LastDayPnL => ManagedSecurity.LastDayPnL;

        public double MaxAllowedMargin => ManagedSecurity.MarginMaxAllowed;

        #endregion  Managed Security

        #region SecurityData

        public SecurityData UnlSecurityData
        {
            get => _unlSecurityData;
            set
            {
                SetLastUpdate();
                _unlSecurityData = value;
                var props = typeof(SecurityData).GetProperties()
                    .Where(p => p.CanWrite && !p.GetIndexParameters().Any());
                foreach (var prop in props)
                {
                    //if (prop.Name == "Symbol" || prop.Name == "MainInfo" || prop.Name == "APIDataType") continue;
                    prop.SetValue(this, prop.GetValue(value));
                }
            }
        }


        #endregion SecurityData


        #region Object Identification characteristics

        public void SetLastUpdate()
        {
            LastUpdate = DateTime.Now;
            //var x = this.ImVolOnCallATM;
        }

        public ETradingState TradingState { get; set; }

        #endregion

        #region Underline Properties

        public double DailyPnL
        {
            get
            {
                _dailyPnL = CostTotal + MarketValue;
                return _dailyPnL;
            }
            set => _dailyPnL = value;
        }

        #endregion

        #region Position Data

        public PositionsSummaryData PositionsSummaryData
        {
            get => _positionsSummaryData;
            set
            {
                SetLastUpdate();
                _positionsSummaryData = value;
            }
        }

        public double DeltaTotal => PositionsSummaryData?.DeltaTotal ?? 0;
        public double GammaTotal => PositionsSummaryData?.GammaTotal ?? 0;
        public double ThetaTotal => PositionsSummaryData?.ThetaTotal ?? 0;
        public double VegaTotal => PositionsSummaryData?.VegaTotal ?? 0;
        public double MarketValue => PositionsSummaryData?.MarketValue ?? 0;
        public double CostTotal => PositionsSummaryData?.CostTotal ?? 0;
        public double PnLTotal => PositionsSummaryData?.PnLTotal ?? 0;
        public double CommisionTotal => PositionsSummaryData?.CommisionTotal ?? 0;
        public int Shorts => PositionsSummaryData?.Shorts ?? 0;

        public int Longs => 0;// PositionsSummaryData.Longs;
        /// <summary>
        /// Hold the calculated IV of all positions taking part on trading.<para></para>
        /// = SumOfAll[IV(option)X Position#] / SumOfAll(Position#).
        /// </summary>
        public double IVWeightedAvg => PositionsSummaryData?.IVWeightedAvg ?? 0;
        /// <summary>
        /// The IV on the Call ATM option.
        /// </summary>
        public double ImVolOnCallATM => PositionsSummaryData?.ImVolOnCallATM ?? 0;

        /// <summary>
        /// The IV on the Put ATM option.
        /// </summary>
        public double ImVolOnPutATM => PositionsSummaryData?.ImVolOnPutATM ?? 0;

        #endregion Position Data

        #region Trading Limitation parameters

        /// <summary>
        /// Gets or sets the actual margin for this underline.
        /// </summary>
        public double Margin
        {
            get => _margin;
            set
            {
                SetLastUpdate();
                _margin = value;
            }
        }

        #endregion

        public override string MainInfo => $"{base.MainInfo} " +        $"Margin:{Margin:##,###}.     IVWeightedAvg:{IVWeightedAvg:N}.         PnLTotal:{PnLTotal:##,###}.";

       
    }
}
