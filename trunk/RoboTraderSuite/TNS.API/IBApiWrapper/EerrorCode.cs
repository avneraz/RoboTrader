using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.API.IBApiWrapper
{
    public enum EtwsErrorCode
    {
        Unknown = 0,

        UndefinedError = -1,

        

        TWSDisconnection = -1000,
        /// <summary>
        /// No security definition has been found for the request. Code=200. AdditionalInfo=194.
        /// </summary>
        NoSecurityFound = 200,
        /// <summary>
        /// Can't find Entity Id with (tickerId:185). Code=300. AdditionalInfo=185.
        /// </summary>
        EntityIdNotFound = 300,
        //System Message Codes:
        /// <summary>
        /// 1100=Connectivity between IB and TWS has been lost.
        /// </summary>
        IbTWSConnectivityLost = 1100,
        /// <summary>
        /// 1101=Connectivity between IB and TWS has been restored- data lost.
        /// </summary>
        IbTWSConnectivityRestoredDataLost = 1101,
        /// <summary>
        /// 1102=Connectivity between IB and TWS has been restored- data maintained.
        /// </summary>
        IbTWSConnectivityRestoredDataMaintained = 1102,
        //Warning Message Codes:
        MarketDataFarmDisconnected = 2103,
        MarketDataFarmConnected = 2104,
        HistoricalDataFarmDisconnected = 2105,
        HistoricalDataFarmConnected = 2106,
        /// <summary>
        /// Connectivity between TWS and server is broken. It will be restored automatically. = 2110
        /// </summary>
        ConnectivityTwsServerBroken = 2110,


    }

    /*
    
Code	Description
2103	A market data farm is disconnected.
2104	A market data farm is connected.
2105	A historical data farm is disconnected.
2106	A historical data farm is connected.

1100	Connectivity between IB and TWS has been lost.
1101	Connectivity between IB and TWS has been restored- data lost.*
1102	Connectivity between IB and TWS has been restored- data maintained.
1300	
TWS socket port has been reset and this connection is being dropped.

    */
}
