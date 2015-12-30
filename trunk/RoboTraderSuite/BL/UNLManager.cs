using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Repository.Hierarchy;
using TNS.API.ApiDataObjects;
using TNS.DbDAL;
using Infra.Bus;
using Infra.Enum;
using log4net;

namespace TNS.BL
{
    public class UNLManager : SimpleBaseLogic
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(UNLManager));
        public UNLManager(MainSecurity mainSecurity, ITradingApi apiWrapper)
        {
            MainSecurity = mainSecurity;
            APIWrapper = apiWrapper;
            
            Logger.InfoFormat("UNLManager({0}) was created!", mainSecurity.Symbol);
        }

        private List<UnlMemberBaseManager> _memberManagersList;
        private ITradingApi APIWrapper { get; }
        private MainSecurity MainSecurity { get; }
        protected override string ThreadName => MainSecurity.Symbol + "_UNLManager_Work";
        protected override void HandleMessage(IMessage message)
        {
            switch (message.APIDataType)
            {
                case EapiDataTypes.SecurityData:
                    SendToAllComponents(message);
                    break;
                case EapiDataTypes.OptionData:
                    OptionsManager.HandleMessage(message);
                    break;
                case EapiDataTypes.PositionData:
                    PositionsDataBuilder.HandleMessage(message);
                    break;
                case EapiDataTypes.OrderData:
                    OrdersManager.HandleMessage(message);
                    break;
                case EapiDataTypes.BrokerConnectionStatus:
                    var connectionStatusMessage = (BrokerConnectionStatusMessage)message;
                    ConnectionStatus = connectionStatusMessage.Status;
                    SendToAllComponents( message);
                    break;
            }
        }

        private void SendToAllComponents(IMessage message)
        {
            foreach (var manager in _memberManagersList)
            {
                manager.HandleMessage(message);
            }
        }

        private bool IsConnected => ConnectionStatus == ConnectionStatus.Connected;
        private ConnectionStatus ConnectionStatus { get; set; }
        public override void DoWorkAfterConnection()
        {
            _memberManagersList = new List<UnlMemberBaseManager>();
            TradingTimeManager = new TradingTimeManager(APIWrapper, MainSecurity);
            //Pass the connectionStatus that received before the object created:
            TradingTimeManager.HandleMessage(new BrokerConnectionStatusMessage(
                ConnectionStatus.Connected, null));
            _memberManagersList.Add(TradingTimeManager);

            OptionsManager = new OptionsManager(APIWrapper, MainSecurity);
            OptionsManager.HandleMessage(new BrokerConnectionStatusMessage(
                ConnectionStatus.Connected, null));
            _memberManagersList.Add(OptionsManager);

            PositionsDataBuilder = new PositionsDataBuilder(APIWrapper, MainSecurity);
            PositionsDataBuilder.HandleMessage(new BrokerConnectionStatusMessage
                (ConnectionStatus.Connected, null));
            _memberManagersList.Add(PositionsDataBuilder);

            TradingManager = new TradingManager(APIWrapper, MainSecurity);
            TradingManager.HandleMessage(new BrokerConnectionStatusMessage(
                ConnectionStatus.Connected, null));
            _memberManagersList.Add(TradingManager);

            OrdersManager = new OrdersManager(APIWrapper, MainSecurity);
            OrdersManager.HandleMessage(new BrokerConnectionStatusMessage(
                ConnectionStatus.Connected, null));
            _memberManagersList.Add(OrdersManager);

        }

        private OptionsManager OptionsManager { get; set; }
        private PositionsDataBuilder PositionsDataBuilder { get; set; }
        private TradingManager TradingManager { get; set; }
        private TradingTimeManager TradingTimeManager { get; set; }
        private OrdersManager OrdersManager { get; set; }

    }
}