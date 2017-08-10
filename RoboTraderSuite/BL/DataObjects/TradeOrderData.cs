using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Enum;
using TNS.API.ApiDataObjects;

namespace TNS.BL.DataObjects
{
    public class TradeOrderData
    {
        public OrderType OrderType { get; set; }

        public OrderAction OrderAction { get; set; }

        public string Symbol { get; set; }

        public double Strike { get; set; }

        public DateTime ExpiryDate { get; set; }

        public EOptionType OptionType { get; set; }

        public string OptionTypeText
        {
            set => OptionType = value.Equals("PUT") ? EOptionType.Put : EOptionType.Call;
        }
    }
}
