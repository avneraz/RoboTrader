using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public class MarginData :IMessage
    {
        public MarginData(string symbol)
        {
            Symbol = symbol;
        }

        public EapiDataTypes APIDataType => EapiDataTypes.MarginData;

        public string  Symbol { get; set; }
        //public double FullMaintMarginReq { get; set; }
        //public double NetLiquidation { get; set; }

        //public double GammaTotal { get; set; }

        public double UnlGammaTotal { get; set; }

        public double MarginGammaRatio { get; set; }

        /// <summary>
        /// the maximum margin allowed for this underline. as it exists in db.
        /// </summary>
        public double MarginMaxAllowed { get; set; }
        /// <summary>
        /// The actual margin due to the underline positions (gamma).
        /// </summary>
        public double Margin => MarginGammaRatio  * UnlGammaTotal;

    }
}
