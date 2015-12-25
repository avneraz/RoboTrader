﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Infra.Enum;
using IMessage = Infra.Bus.IMessage;

namespace TNS.API.ApiDataObjects
{
    public enum ConnectionStatus
    {
        Connected,
        Disconnected
    }
    public class BrokerConnectionStatusMessage : IMessage
    {
        public BrokerConnectionStatusMessage(ConnectionStatus status, APIMessageData messageData)
        {
            Status = status;
            MessageData = messageData;
        }

        public ConnectionStatus Status { get; }
        public APIMessageData MessageData { get;  }

        public EapiDataTypes APIDataType => EapiDataTypes.BrokerConnectionStatus;


    }
}
