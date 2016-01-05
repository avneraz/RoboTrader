using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.BL;

namespace TNS.Controls
{
    interface IUIData
    {
        UIDataManager UIDataManager { get; set; }
        void SetUIDataManager(UIDataManager uiDataManager);
    }
}
