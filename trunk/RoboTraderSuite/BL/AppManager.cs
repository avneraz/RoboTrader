using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TNS.API.ApiDataObjects;
using TNS.API.IBApiWrapper;
using TNS.BrokerDAL;
using TNS.DbDAL;
using TNS.Global;
using TNS.Global.PopUpMessages;

namespace TNS.BL
{
    public class AppManager
    {
        /// <summary>
        /// Must be called once application is up by the main GUI object
        /// </summary>
        public void InitializeAppManager(Form mainForm)
        {
            ParentForm = mainForm;
            ConfigurationBuilder.BuildAndInitializeConfiguration();
            Configurations = AllConfigurations.AllConfigurationsObject;
        }

        Form ParentForm { get; set; }

        public ITradingApi APIWrapper { get; private set; }


        /// <summary>
        /// Called when the application ready for connect to the broker.<para></para>
        /// The broker server must be up (TWS or other.)
        /// </summary>
        public void ConnectToBroker()
        {
            Distributer = new Distributer();

            //Change the wrapper object according to the actual broker, 
            //for now it's Interactive Broker.
                APIWrapper = new IBApiWrapper(
                Configurations.Application.DefaultHost, 
                Configurations.Application.AppPort, 
                Configurations.Application.AppClientId, 
                Distributer, 
                Configurations.Application.MainAccount);
            APIWrapper.ConnectToBroker();
            Distributer.ExceptionThrown += DistributerOnExceptionThrown;
        }
        //RequestAccountData
        private void DistributerOnExceptionThrown(ExceptionData exceptionData)
        {
            if (!(exceptionData.ThrownException is SocketException)) return;

            if (ParentForm.InvokeRequired)
            {
                Action action = () =>
                {
                    PopupMessageForm.ShowMessage(exceptionData.ToString(), Color.Red, ParentForm, 5, withSiren: true);
                };
                ParentForm.Invoke(action);
            }
        }

        #region Managers Properties
    
        public Distributer Distributer { get; set; }

        public PositionsDataBuilder PositionsDataBuilder { get; private set; }

        public AccountManager AccountManager { get; private set; }

        //public ContractManager ContractManager { get; private set; }

        public OptionsManager OptionsManager { get; private set; }

        public AllConfigurations Configurations { get; private set; }
        #endregion


    }
}
