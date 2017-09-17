using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Global
{
    public class SavedParametersData
    {
        public DateTime LastDBDillution { get; set; }
        public DateTime LastUpdate { get; set; }
        public double LastNetLiquidition { get; set; }
        public int Id { get; protected set; }
    }
}
