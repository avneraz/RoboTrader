using Infra.Bus;
using Infra.Enum;

namespace TNS.API.ApiDataObjects
{
    public class OptionsPositionData : PositionData
    {
        public OptionsPositionData()
        {

        }
        public OptionsPositionData(OptionContract contract, int position, double averageCost)
            : base(position, averageCost)
        {
            OptionContract = contract;
        }


        public OptionContract OptionContract { get; set; }


        public override ContractBase GetContract()
        {
            return OptionContract;
        }

        public override void SetContract(ContractBase contract)
        {
            OptionContract = (OptionContract)contract;
        }
    }
}
