using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.API.ApiDataObjects
{
    /// <summary>
    /// Hold all the names of the API Data objects that derived from IMassage.
    /// </summary>
    public static class APIDataTypes
    {
        public static string AccountSummaryData => "AccountSummaryData";
        public static string ExceptionData => "ExceptionData";
        public static string OptionData => "OptionData";
        public static string OrderData => "OrderData";
        public static string PositionData => "PositionData";
    }
}
