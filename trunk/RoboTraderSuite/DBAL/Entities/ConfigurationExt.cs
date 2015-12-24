using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Enum;
using TNS.DbDAL;

// ReSharper disable once CheckNamespace
//It has to be the same name-space of the other part of the class!
namespace TNS.DbDAL
{
    public partial class Configuration
    {
        public EConfigurationCategory ConfigurationCategory
        {
            get
            {
                if (Category != null) return (EConfigurationCategory)Category.Value;
                return EConfigurationCategory.Unknown;
            }
            set { Category = (int)value; }
        }
    }
}
