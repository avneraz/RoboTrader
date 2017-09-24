using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public class MarginData : IMessage
    {
        public MarginData(string symbol)
        {
            Symbol = symbol;
        }

        public EapiDataTypes APIDataType => EapiDataTypes.MarginData;

        public string Symbol { get; set; }

        /// <summary>
        /// the maximum margin allowed for this underline. as it exists in db.
        /// </summary>
        public double MarginMaxAllowed { get; set; }

        /// <summary>
        /// The actual margin due to the underline positions (gamma).
        /// </summary>
        public double Margin { get; set; }

        public int PutPositionCount { get; set; }
        public int CallPositionCount { get; set; }

        /// <summary>
        /// Get the number relation between call positions and put positions of specific UNL position.
        /// </summary>
        public EPutCallPositionRelation PutCallPositionRelation
        {
            get
            {
                if (PutPositionCount > CallPositionCount)
                    return EPutCallPositionRelation.PutGCall;
                if (CallPositionCount > PutPositionCount)
                    return EPutCallPositionRelation.CallGPut;
                return PutPositionCount == CallPositionCount
                    ? EPutCallPositionRelation.Equel
                    : EPutCallPositionRelation.UnKnown;
            }
        }
}

    public enum EPutCallPositionRelation
    {
        UnKnown = 0,
        /// <summary>
        /// The positions of put and call are equel.
        /// </summary>
        Equel = 1,
        /// <summary>
        /// The Put position count is grater than Call Positions.
        /// </summary>
        PutGCall = 2,
        /// <summary>
        /// The Call position count is grater than Put Positions.
        /// </summary>
        CallGPut
    }
}
