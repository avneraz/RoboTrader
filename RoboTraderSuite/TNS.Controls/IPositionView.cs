using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.API.ApiDataObjects;
using TNS.BL;
using TNS.BL.Interfaces;
using TNS.BL.UnlManagers;

namespace TNS.Controls
{
    public interface IPositionView
    {
         void SendSellOrder(OptionData optionData , int quantity);
       
         void SendBuyOrder(OptionData optionData , int quantity);

        List<OptionData> OptionsDataList { get; set; }

    }
}
