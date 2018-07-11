using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Extensions;
using TNS.API.ApiDataObjects;
using TNS.BL.DataObjects;
using TNS.BL.UnlManagers;
using static System.Math;

namespace TNS.BL.Analysis
{
    public class WhatIfAnalayzer
    {


        public WhatIfAnalayzer(string symbol)
        {
            _symbol = symbol;
            InitializeMembers();
        }
        private void InitializeMembers()
        {
            UnlManager = AppManager.UNLManagerDic[_symbol] as UNLManager;
            if (UnlManager == null) throw new Exception("The symbol is not exist!!");

            UnlTradingData = UnlManager.UnlTradingData;
            WhatIfUnlTradingData =
                new UnlTradingData(UnlTradingData.ManagedSecurity) {UnlSecurityData = UnlTradingData.UnlSecurityData};


        }
        private AppManager AppManager => AppManager.AppManagerSingleTonObject;
        private readonly string _symbol;
        private UNLManager UnlManager { get; set; }

        public PositionsSummaryData WhatIfPositionsSummaryData { get; set; }
        /// <summary>
        /// Get or Set the change on the left daye to expiry.
        /// </summary>
        public int DaysLeftChange { get; set; }

        /// <summary>
        /// Get or Set the change on the IV
        /// </summary>
        public double IVChange { get; set; }

        public UnlTradingData UnlTradingData { get; set; }
        public UnlTradingData WhatIfUnlTradingData { get; set; }


        public UnlTradingData CalculateWhatIf(double ivChange, int daysLeftChange)
        {
            IVChange = ivChange;
            DaysLeftChange = daysLeftChange;
            var positionList = UnlManager.PositionsDataBuilder.PositionDataDic.Values;
            List<BnSCalculationData> bnSCalculationDataList = new List<BnSCalculationData>();
            BnSCalcHelpper bnSCalcHelpper = new BnSCalcHelpper();

            foreach (OptionsPositionData position in positionList)
            {
                BnSCalculationData bnSCalculationData =
                    bnSCalcHelpper.CalculateValuesByBnS(position.OptionData, DaysLeftChange, IVChange);
                bnSCalculationData.Position = position.Position;
                bnSCalculationDataList.Add(bnSCalculationData);

            }
            WhatIfPositionsSummaryData =
                new PositionsSummaryData
                {
                    CostTotal = bnSCalculationDataList.Sum(pd => pd.Cost),
                    DeltaTotal = bnSCalculationDataList.Sum(pd => pd.DeltaTotal),
                    GammaTotal = bnSCalculationDataList.Sum(pd => pd.GammaTotal),
                    ThetaTotal = bnSCalculationDataList.Sum(pd => pd.ThetaTotal),
                    VegaTotal = bnSCalculationDataList.Sum(pd => pd.VegaTotal),
                    MarketValue = bnSCalculationDataList.Sum(pd => pd.PositionPrice),
                    Shorts = bnSCalculationDataList.Where(pd => pd.Position < 0).Sum(pd => Abs(pd.Position)),
                    Longs = bnSCalculationDataList.Where(pd => pd.Position > 0).Sum(pd => pd.Position),
                    IVWeightedAvg = bnSCalculationDataList.Sum(pd => pd.ImpliedVolatilitiesForCalc * pd.Quantity) /
                                    bnSCalculationDataList.Sum(pd => pd.Quantity)
                };

            WhatIfUnlTradingData.PositionsSummaryData = WhatIfPositionsSummaryData;
            return WhatIfUnlTradingData;
        }
      

    }
}
