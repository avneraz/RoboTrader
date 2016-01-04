using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.API.ApiDataObjects
{
    public static class PositionDataFactory
    {
        public static PositionData CreatePoisitionData(ContractBase contract, int position,
            double avgCost)
        {
            if(contract is OptionContract) 
                return new OptionsPositionData((OptionContract)contract, position, avgCost);
            else if (contract is SecurityContract)
                return new StocksPositionData((SecurityContract) contract, position, avgCost);
            else
                throw new Exception($"Invalid contract for position {contract}");
        }
    }
}
