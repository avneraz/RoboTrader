using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Enum;

namespace Infra
{
    public class AllConfigurations
    {

        public AllConfigurations()
        {
            Application = new ApplicationConfiguration();
            Trading = new TradingConfiguration();
            Session = new SessionConfiguration();
            TradingAlarm = new TradingAlarmConfiguration();
        }

        /// <summary>
        /// Gets the main configurations object.
        /// </summary>
        /// <value>
        /// All configurations.
        /// </value>
        public static AllConfigurations AllConfigurationsObject { get; set; }

        public ApplicationConfiguration Application { get; private set; }
        public TradingConfiguration Trading { get; private set; }
        public SessionConfiguration Session { get; private set; }
        public TradingAlarmConfiguration TradingAlarm { get; private set; }

        public class ApplicationConfiguration
        {
            public int AppClientId { get; set; }

            public int AppPort { get; set; }

            public string DefaultHost { get; set; }

            public int WDAppClientId { get; set; }

            public string MainAccount { get; set; }
            public TimeSpan DBWritePeriod { get; set; }
            public bool AllowAutoTrading { get; set; }
        }

        public class TradingConfiguration
        {
            /// <summary>
            /// The max offset of the retrieving options from the "On The Money - 50" Delta.
            /// Only options between will be loaded.(If offset = 20,the only options with delta betwee 30 to 70 will be loaded!)
            /// </summary>
            public int AllowedDeltaOffset { get; set; }
            /// <summary>
            /// Contains all the UNL symbols that taking part in trading.e.g: "AAPL;MSFT"
            /// </summary>
            /// <value>
            /// The unl symbols list.
            /// </value>
            public string UNLSymbolsList { get; set; }

            private string[] _unlSymbolsList;

            public string[] UNLSymbolsListForTrading()
            {
                return _unlSymbolsList ?? (_unlSymbolsList = UNLSymbolsList.Split(';')); 
            }

            public double MaxDeltaAllowed { get; set; }
            public double MinDeltaAllowed { get; set; }
            /// <summary>
            /// (%) - The max amount of possible loss due to the delta. It's expressed in percantage of the current margin.
            /// </summary>
            /// <value>
            /// The delta loss thteshold.
            /// </value>
            public double DeltaLossThreshold { get; set; }
            /// <summary>
            /// Gets or sets the risk free interest rate.
            /// </summary>
            /// <value>
            /// The risk free interest rate.
            /// </value>
            public double RiskFreeInterestRate { get; set; }

            /// <summary>
            /// Gets or sets the Out Of the Money (OTM) offset.
            /// e.g. The offset from underlined price when using trading with OTM algorithm.
            /// On Call options.
            /// </summary>
            /// <value>
            /// The otm offset.
            /// </value>
            public int OTMOffsetCall { get; set; }
            /// <summary>
            /// Gets or sets the Out Of the Money (OTM) offset.
            /// e.g. The offset from underlined price when using trading with OTM algorithm.
            /// On Put options.
            /// </summary>
            /// <value>
            /// The otm offset.
            /// </value>
            public int OTMOffsetPut { get; set; }
            /// <summary>
            /// Gets or sets the type of the algorithm.
            /// </summary>
            /// <value>
            /// The type of the algorithm.
            /// </value>
            public int AlgorithmType { get; set; }

            /// <summary>
            /// Gets or sets the type of the algorithm. with the Enum.
            /// </summary>
            /// <value>
            /// The type of the algorithm.
            /// </value>
            public EAlgorithmType AlgorithmTypeE
            {
                get { return (EAlgorithmType)AlgorithmType; }
                set { AlgorithmType = (int)value; }
            }
            /// <summary>
            /// The minimum step in Dolar for trading price.
            /// </summary>
            public double MinPriceStep { get; set; }
            /// <summary>
            /// Gets or sets the initialize net liquidation.
            /// </summary>
            /// <value>
            /// The initialize net liquidation.
            /// </value>
            public double InitNetLiquidation { get; set; }
            /// <summary>
            /// The interval between 2 successive orders
            /// </summary>
            public int OrderInterval { get; set; }

            public TimeSpan OrderIntervalTimeSpan => TimeSpan.FromMilliseconds(OrderInterval);
            /// <summary>
            /// Gets or sets the USA interest rate percentage = 0.25;
            /// </summary>
            /// <value>
            /// The usa interest percentage.
            /// </value>
            public double USAInterestPercentage { get; set; }

            /// <summary>
            /// Gets or sets the statistics save interval IN seconds; Current value = 300 seconds;
            /// </summary>
            /// <value>
            /// The statistics save interval sec.
            /// </value>
            public int StatisticsSaveIntervalSec { get; set; }

            /// <summary>
            /// Gets or sets Policy used currently by the traders.
            /// </summary>
            /// <value>
            /// The policy identifier.
            /// </value>
            public int PolicyID { get; set; }

            /// <summary>
            /// Gets or sets The range for the statistics AAPL underline price="100;160".
            /// </summary>
            /// <value>
            /// The aapl underlined range.
            /// </value>
            public string AAPLUnderlinedRange { get; set; }

            ///// <summary>
            ///// Gets or sets The max absolute delta allowed on normal trading.
            ///// </summary>
            ///// <value>
            ///// The maximum absolute delta.
            ///// </value>
            //public int MaxAbsoluteDelta { get; set; } //Obsulite

            ///// <summary>
            ///// Gets or sets The max gama allowed on normal trading.
            ///// </summary>
            ///// <value>
            ///// The maximum gamma.
            ///// </value>
            //public int MaxGamma { get; set; }

            /// <summary>
            /// Gets or sets the typical maximum margin as default.
            /// </summary>
            /// <value>
            /// The maximum margin typical.
            /// </value>
            public int MaxMarginTypical { get; set; }

            /// <summary>
            /// Gets or sets the hedge span:
            /// The strike span for buying long hedge
            /// </summary>
            /// <value>
            /// The hedge span.
            /// </value>
            public int HedgeSpan { get; set; }

            /// <summary>
            /// Gets or sets the trading start mode.
            /// 1=Manual ==> Start by user. 2=Auto ==>Start automatically by the AutoTrader
            /// </summary>
            /// <value>
            /// The trading start mode.
            /// </value>
            public int TradingStartMode { get; set; }

            /// <summary>
            /// Gets the trading start mode enum.
            /// </summary>
            /// <value>
            /// The trading start mode enum.
            /// </value>
            public ETradingStartMode TradingStartModeEnum
            {
                get { return (ETradingStartMode)TradingStartMode; }
            }
        }

        public class SessionConfiguration
        {
      
            /// <summary>
            /// The upper limit of the strike being load in percentage of the underline security.
            /// </summary>
            public int HighStrikePercentage { get; set; }
            /// <summary>
            /// The lower limit of the strike being load in percentage of the underline security
            /// </summary>
            public int LowStrikePercentage { get; set; }
            /// <summary>
            /// The minimum days of expiration of the loaded session expiry.
            /// </summary>
            public int MinimumDaysToExpiration { get; set; }
            /// <summary>
            /// The maximum days of expiration of the loaded session expiry.
            /// </summary>
            public int MaxmumDaysToExpiration { get; set; }
            /// <summary>
            /// Gets or sets the LOW strike for loading in OptionManager.(usually 90)
            /// </summary>
            /// <value>
            /// The aapl low loading strike.
            /// </value>
            public double AAPLLowLoadingStrike { get; set; }

            /// <summary>
            /// Gets or sets the high strike for loading in OptionManager.(usually 180)
            /// </summary>
            /// <value>
            /// The aapl high loading strike.
            /// </value>
            public double AAPLHighLoadingStrike { get; set; }

            /// <summary>
            /// Gets or sets the sessions that will be loaded.= "20150821;20151016;20160115"
            /// </summary>
            /// <value>
            /// The aapl sessions to load.
            /// </value>
            public string AAPLSessionsToLoad { get; set; }
            //public double AAPL_HIGH_LOADING_STRIKE { get; set; }

            private string[] _sessionToLoad;// = Configurations.Session.AAPLSessionsToLoad.Split(';');

            public string[] SessionToLoad
            {
                get { return _sessionToLoad ?? (_sessionToLoad = AAPLSessionsToLoad.Split(';')); }
            }

        }

        public class TradingAlarmConfiguration
        {

        }
        /*Categories:
          Unknown = 0,
        Application = 1,
        Trading = 2,
        Session = 3,
        TradingAlarm = 4, 
         */



    }
}
