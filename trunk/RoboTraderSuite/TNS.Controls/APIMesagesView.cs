using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TNS.API.ApiDataObjects;

namespace TNS.Controls
{
    public partial class APIMesagesView : UserControl
    {
        public APIMesagesView()
        {
            InitializeComponent();
            APIMessageDataList = new List<APIMessageData>();
            _apiMessageDataBindingSource.DataSource = APIMessageDataList;

        }

        public List<APIMessageData> APIMessageDataList { get; }

        public void AddMessage(APIMessageData apiMessageData)
        {
            APIMessageDataList.Add(apiMessageData);
            Action action = () =>
            {
                _apiMessageDataBindingSource.ResetBindings(false);
                //string.Format("{0:T}",DateTime.Now)
            };

            if (InvokeRequired)
                Invoke(action);
            else
                action.Invoke();
        }
    }
}
