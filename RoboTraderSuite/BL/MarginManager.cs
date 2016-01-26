using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Infra.Bus;
using NHibernate;
using NHibernate.Linq;
using TNS.API.ApiDataObjects;
using TNS.BL.UnlManagers;

namespace TNS.BL
{
    /// <summary>
    /// Responsible on margin of the Trader. Calculate the rate of MarginToGamma, <para></para>
    /// by using the sum of all positions gamma, and the maintenance margin that the broker calculates and send to us via AccountManager.
    /// </summary>
    public class MarginManager
    {
        public MarginManager(List<string> unlSymbolList, SimpleBaseLogic distributer)
        {
            UnlSymbolList = unlSymbolList;
            Distributer = distributer;
           
            InitializeItems();
        }
        private SimpleBaseLogic Distributer { get;  }
        private List<string> UnlSymbolList { get; }

        public Dictionary<string,MarginData> MarginDataDic { get; private set; }

        public double FullMaintMarginReq { get; set; }
        public double NetLiquidation { get; set; }

        public double MarginGammaRatio => IsGammaTotalHasValue() ? 0: FullMaintMarginReq / GammaTotal;

        public double GammaTotal { get; set; }
        private void CalculateMargin()
        {

            GammaTotal = MarginDataDic.Values.Sum(md => md.UnlGammaTotal);
            //ForTest GammaTotal = 456;
            if (IsGammaTotalHasValue())
                return;

            foreach (var marginData in MarginDataDic.Values)
            {
                marginData.MarginGammaRatio = MarginGammaRatio;
                Distributer.Enqueue(marginData);
            }

        }

        private bool IsGammaTotalHasValue()
        {
            return (Math.Abs(GammaTotal) < 0.01);
        }
        public void UpdateAccountData(AccountSummaryData accountSummaryData)
        {
            NetLiquidation = accountSummaryData.NetLiquidation;
            FullMaintMarginReq = accountSummaryData.FullInitMarginReq;
        }
        public void UpdateUnlTradingData(UnlTradingData unlTradingData)
        {
            MarginDataDic[unlTradingData.Symbol].UnlGammaTotal = unlTradingData.GammaTotal;
            CalculateMargin();
        }
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
    }
}
