using System.Collections.Generic;
using IBApi;
using Infra.Bus;
using Infra.Enum;
using TNS.API.ApiDataObjects;

namespace TNS.BL
{
    /// <summary>
    /// Deal with all Main Securities data. Retrieves contract and market data.
    /// </summary>
    public class MainSecuritiesManager : SimpleBaseLogic
    {
        protected override void HandleMessage(IMessage message)
        {
            switch (message.APIDataType)
            {
                case EapiDataTypes.SecurityData:
                    var securityData = message as SecurityData;

                    Contract = securityData.Contract;
                    LastPrice = securityData.LastPrice;
                    AskPrice = securityData.AskPrice;
                    BidPrice = securityData.BidPrice;
                    HighestPrice = securityData.HighestPrice;
                    LowestPrice = securityData.LowestPrice;
                    OpeningPrice = securityData.BasePrice;
                    AskSize = securityData.BasePrice;
                    BidSize = securityData.BasePrice;
                    Volume = securityData.BasePrice;
                    break;
            }
        }

        private Dictionary<Contract, SecurityData> securities_;

        /// <summary>
        /// Index or underline data (symbol, currency, etc.)
        /// </summary>
        public ContractBase Contract { get; set; }

        /// <summary>
        /// Final price at which the security was traded (current day)
        /// </summary>
        public double LastPrice { get; set; }

        /// <summary>
        /// Highest price made for the security (current day)
        /// </summary>
        public double HighestPrice { get; set; }

        /// <summary>
        /// Lowest price made for the security (current day)
        /// </summary>
        public double LowestPrice { get; set; }

        /// <summary>
        /// Open quote (current day)
        /// </summary>
        public double BasePrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double OpeningPrice { get; set; }

        /// <summary>
        /// Price a seller is willing to accept for a security
        /// </summary>
        public double AskPrice { get; set; }

        /// <summary>
        /// An offer made by an investor, a trader or a dealer to buy a security
        /// </summary>
        public double BidPrice { get; set; }

        

        /// <summary>
        /// 
        /// </summary>
        public double AskSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double BidSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Volume { get; set; }

    }

}