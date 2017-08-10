using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.API.ApiDataObjects;

namespace TNS.API.IBApiWrapper
{
    class IBOrderStatusWrapper
    {
        public IBOrderStatusWrapper(OrderStatusData data)
        {
            Data = data;
        }

        public OrderStatusData Data { get; set; }
        public string ExecId { get; set; }
    }
}
