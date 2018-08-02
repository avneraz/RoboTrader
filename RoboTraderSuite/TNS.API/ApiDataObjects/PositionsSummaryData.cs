using System;

namespace TNS.API.ApiDataObjects
{
    public class PositionsSummaryData
    {
        public double DeltaTotal { get; set; }
        public double NormalizedDeltaTotal { get; set; }
        public double GammaTotal { get; set; }
        public double ThetaTotal { get; set; }
        public double VegaTotal { get; set; }
        public double MarketValue { get; set; }
        public double CostTotal { get; set; }

        private double _pnlTotal;
        public double PnLTotal
        {
            get => MarketValue + CostTotal;
            set => _pnlTotal = value;
        }

        public double CommisionTotal { get; set; }
        public int Shorts { get; set; }
        public int Longs { get; set; }
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

    }
}
