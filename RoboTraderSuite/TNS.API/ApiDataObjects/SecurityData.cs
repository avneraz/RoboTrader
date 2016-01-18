using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.API.ApiDataObjects
{
    public class SecurityData : BaseSecurityData
    {
        public override ContractBase GetContract()
        {
            return SecurityContract;
        }

        public override void SetContract(ContractBase contract)
        {
            SecurityContract = (SecurityContract)contract;
        }

        public SecurityContract SecurityContract { get; set; }

    }
}
