using TNS.API.ApiDataObjects;
using TNS.DbDAL;
using Infra.Bus;


namespace TNS.BL
{
    /// <summary>
    /// Deals with all the issues involved with getting position data from the Broker,
    ///  and build all the position data of the UNLs contract.
    /// </summary>
    public class PositionsDataBuilder:UnlMemberBaseManager
    {
        public PositionsDataBuilder(ITradingApi apiWrapper, MainSecurity mainSecurity) : base(apiWrapper, mainSecurity)
        {

        }
        public override void HandleMessage(IMessage message)
        {
            base.HandleMessage(message);

        }

    }
}