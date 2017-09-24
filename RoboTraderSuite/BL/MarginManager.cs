using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using DAL;
using Infra.Bus;
using Infra.Enum;
using log4net;
using NHibernate;
using NHibernate.Linq;
using TNS.API.ApiDataObjects;
using TNS.BL.UnlManagers;

namespace TNS.BL
{
    /// <summary>
    /// Responsible on margin of the Trader. Calculate the rate of the requierd Margin, <para></para>
    /// In reference with the whole maintenance margin that the broker calculates and send to us via AccountManager.
    /// Each UNL has its calculated margin.
    /// The calculation relys on the following consumptions:
    /// 1. Selling one option ATM (At The Money) Selling one option without a nate on the opposite short (Call vs. Put),
    ///    requierd margin equel to loss of 25% precents on the adequate direction. (Put=> UNL is down, Call => UNL is up.)
    /// 2. Selling one option that has already a mate on the opposite short, 
    ///    requierd margin equel to loss of 10% precents on the adequate direction. 
    /// </summary>
    public class MarginManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(MarginManager));
        public MarginManager()
        {
            _appManager = AppManager.AppManagerSingleTonObject;
            Distributer = _appManager.Distributer;
            UnlSymbolList = _appManager.UNLManagerDic.Keys.ToList();
            InitializeItems();
        }

        private const double NoMateLossPercantag = .245;
        private const double WithMateLossPercantag = .06;

        private AppManager _appManager;
        private SimpleBaseLogic Distributer { get; }
        private List<string> UnlSymbolList { get; }
        public Dictionary<string, MarginData> MarginDataDic { get; set; }
        private double FullMaintMarginReq { get; set; }
        private double NetLiquidation { get; set; }
        private void InitializeItems()
        {
            ISession session = DBSessionFactory.Instance.OpenSession();
            List<ManagedSecurity> activeUNLList = session.Query<ManagedSecurity>().Where(contract => contract.IsActive && contract.OptionChain).ToList();

            MarginDataDic = new Dictionary<string, MarginData>();
            foreach (var symbol in UnlSymbolList)
            {
                var marginData = new MarginData(symbol);
                var managedSecurity = activeUNLList.FirstOrDefault(unl => unl.Symbol == symbol);
                if (managedSecurity != null)
                    marginData.MarginMaxAllowed = managedSecurity.MarginMaxAllowed;

                MarginDataDic[symbol] = marginData;
            }
        }
        public void UpdateAccountData(AccountSummaryData accountSummaryData)
        {
            NetLiquidation = accountSummaryData.NetLiquidation;
            FullMaintMarginReq = accountSummaryData.FullInitMarginReq;
        }
        public void UpdateUnlTradingData(UnlTradingData unlTradingData)
        {
            //MarginDataDic[unlTradingData.Symbol].UnlGammaTotal = unlTradingData.GammaTotal;
            CalculateAllRequierdMargin();
        }
        private void CalculateAllRequierdMargin()
        {
            foreach (var marginData in MarginDataDic.Values)
            {
                CalculateUNLRequierdMargin(marginData.Symbol);
                Distributer.Enqueue(marginData);
            }
        }

        public double CalculateUNLRequierdMargin(string symbol)
        {
            //if (!symbol.Equals("AMZN")) return;//For testing only!!!!
            var posList = GetPositionList(symbol);


            var callList = new List<OptionsPositionData>();
            var putList = new List<OptionsPositionData>();
            foreach (var pos in posList)
            {
                if (pos.OptionType == EOptionType.Call)
                    callList.Add(pos);
                else putList.Add(pos);
            }

            var marginData = MarginDataDic[symbol];
            marginData.CallPositionCount = Math.Abs(callList.Sum(p => p.Position));
            marginData.PutPositionCount = Math.Abs(putList.Sum(p => p.Position));

            double marginSum = 0;

            try
            {
                var unlRate = _appManager.ManagedSecuritiesManager.Securities[symbol].LastPrice;
                if (marginData.PutPositionCount >= marginData.CallPositionCount)
                {
                    //First calculate the Put List
                    marginSum = putList.Sum(posData => CalculateMargin(unlRate,
                                                           posData.OptionData.OptionContract.Strike, false,
                                                           EOptionType.Put) * Math.Abs(posData.Position));
                    //Than calculate the call, as a mate.
                    marginSum += callList.Sum(posData => CalculateMargin(unlRate,
                                                             posData.OptionData.OptionContract.Strike, true,
                                                             EOptionType.Call) * Math.Abs(posData.Position));
                }
                else
                {
                    //First calculate the Calls List
                    marginSum = callList.Sum(posData => CalculateMargin(unlRate,
                                                            posData.OptionData.OptionContract.Strike, false,
                                                            EOptionType.Call) * Math.Abs(posData.Position));
                    //Than calculate the puts, as a mate.
                    marginSum += putList.Sum(posData => CalculateMargin(unlRate,
                                                            posData.OptionData.OptionContract.Strike, true,
                                                            EOptionType.Put) * Math.Abs(posData.Position));
                }
            }
            catch (Exception ex)
            {
                Logger.Error("OptionData is null", ex);
            }

            marginData.Margin = marginSum;
            return marginSum;
        }

        private Dictionary<string, OptionsPositionData>.ValueCollection GetPositionList(string symbol)
        {
            var unlManager = _appManager.UNLManagerDic[symbol] as UNLManager;

            if (unlManager == null)
            {
                throw new Exception($"There is no UNLManager for '{symbol}'!");
            }

            Debug.Assert(unlManager.UnlTradingData.Longs == 0, "The position contains not allowed long option");
            var posList = unlManager.PositionsDataBuilder.PositionDataDic.Values;
            return posList;
        }

        /// <summary>
        /// Calculate the margin requierd to sell 1 option of the given position data.
        /// It calculates considering the situation and relations of entire positions of the given UNL.
        /// </summary>
        /// <param name="positionData"></param>
        /// <returns></returns>
        public double OnePositionSellMargin(OptionsPositionData positionData)
        {
            var symbol = positionData.OptionData.Symbol;
            CalculateUNLRequierdMargin(symbol);
            var marginData = MarginDataDic[symbol];
            //double unlRate = positionData.OptionData.UnderlinePrice;
            var unlRate = _appManager.ManagedSecuritiesManager.Securities[symbol].LastPrice;
            double strike = positionData.OptionContract.Strike;
            EOptionType type = positionData.OptionType;
            bool mate = false;
            switch (marginData.PutCallPositionRelation)
            {
                case EPutCallPositionRelation.Equel:
                    mate = false;
                    break;
                case EPutCallPositionRelation.PutGCall:
                    if (type == EOptionType.Call)
                        mate = true;
                    break;
                case EPutCallPositionRelation.CallGPut:
                    if (type == EOptionType.Put)
                        mate = true;
                    break;
            }
            var result = CalculateMargin(unlRate, strike, mate, type);
            return result;
        }

        public double CalculateMargin(double unlRate, double strike, bool mate, EOptionType type = EOptionType.Call)
        {
            double lossPercantag = mate ? WithMateLossPercantag : NoMateLossPercantag;
            //lossPercantag = 0.06;
            //lossPercantag = 0.245;
            double requierdMargin = 0;
            const int multiplier = 100;

            requierdMargin = 
                type == EOptionType.Call ?
                (unlRate * (1 + lossPercantag) - strike) * multiplier :
                (strike - unlRate * (1 - lossPercantag)) * multiplier;

            return requierdMargin;
        }

        /// <summary>
        /// Get the margin requierd for sell 2 mate options (couple). where the strike at the money!
        /// </summary>
        /// <param name="unlRate"></param>
        /// <returns></returns>
        public double GetMarginForOneCoupleMateOptions(double unlRate)
        {
            double strike = unlRate;
            double margin = 0;
            margin += CalculateMargin(unlRate, strike, false);
            margin += CalculateMargin(unlRate, strike, true, EOptionType.Put);
            return margin;
        }

        /// <summary>
        /// Calculates the number of the mate couples of given UNL (symbol), 
        /// Also return the single options (without mate and the type of the singl).
        /// </summary>
        /// <param name="symbol">The UNL symbol</param>
        /// <param name="singleCount">The number of single options, that have no adequate mate.</param>
        /// <param name="optionType">The option type of the single.</param>
        /// <returns></returns>
        public int GetCoupleMateOptionsCount(string symbol, out int singleCount, out EOptionType optionType)
        {
            var posList = GetPositionList(symbol);
            var callPositionsCount = Math.Abs(posList.Where(pd=>pd.OptionType == EOptionType.Call).Sum(pd => pd.Position));
            var putPositionsCount = Math.Abs(posList.Where(pd => pd.OptionType == EOptionType.Put).Sum(pd => pd.Position));

            var result = Math.Min(callPositionsCount, putPositionsCount);
            singleCount = Math.Abs(callPositionsCount - putPositionsCount);
            optionType = callPositionsCount >= putPositionsCount ? EOptionType.Call : EOptionType.Put;

            return result;

        }
    }

  }
