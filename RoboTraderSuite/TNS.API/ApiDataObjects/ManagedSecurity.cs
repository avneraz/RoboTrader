using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.API.ApiDataObjects
{
    public class ManagedSecurity
    {
        public virtual int Id { get; protected set; }
        public string Symbol { get; set; }
        public SecurityType SecurityType { get; set; }
        public string Exchange { get; set; }
        public int Multiplier { get; set; }
        public string Currency { get; set; }
        public bool IsActive { get; set; }
        public bool OptionChain { get; set; }
        public double MarginMaxAllowed { get; set; }

    }
}
