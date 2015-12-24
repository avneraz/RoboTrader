using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Infra.Extensions
{

    public static class Log4NetExtensions
    {
        #region Notice Level

        static readonly log4net.Core.Level NoticeLevel = new log4net.Core.Level(50000, "Notice");

        public static void Notice(this ILog log, string message)
        {
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                NoticeLevel, message, null);
        }

        public static void NoticeFormat(this ILog log, string message, params object[] args)
        {
            string formattedMessage = string.Format(message, args);
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                NoticeLevel, formattedMessage, null);
        }
        #endregion

        #region Alert Level

        static readonly log4net.Core.Level AlertLevel = new log4net.Core.Level(100000, "Alert");

        public static void Alert(this ILog log, string message)
        {
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                AlertLevel, message, null);
        }

        public static void AlertFormat(this ILog log, string message, params object[] args)
        {
            string formattedMessage = string.Format(message, args);
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                AlertLevel, formattedMessage, null);
        }

        #endregion

        #region Emergency Level

        static readonly log4net.Core.Level EmergencyLevel = new log4net.Core.Level(120000, "Emergency");

        public static void Emergency(this ILog log, string message)
        {
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                EmergencyLevel, message, null);
        }

        public static void EmergencyFormat(this ILog log, string message, params object[] args)
        {
            string formattedMessage = string.Format(message, args);
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                EmergencyLevel, formattedMessage, null);
        }
        #endregion

        #region TWS_Error Level

        static readonly log4net.Core.Level TWSErrorLevel = new log4net.Core.Level(120000, "TWS_Error");

        public static void TWS_Error(this ILog log, string message)
        {
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                TWSErrorLevel, message, null);
        }

        public static void TWS_ErrorFormat(this ILog log, string message, params object[] args)
        {
            string formattedMessage = string.Format(message, args);
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                TWSErrorLevel, formattedMessage, null);
        }

        #endregion
       
        #region Trading Level ==> Buy or sell

        static readonly log4net.Core.Level TradingLevel = new log4net.Core.Level(51000, "Trading");

        public static void Trading(this ILog log, string message)
        {
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                TradingLevel, message, null);
        }

        public static void TradingFormat(this ILog log, string message, params object[] args)
        {
            string formattedMessage = string.Format(message, args);
            log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                TradingLevel, formattedMessage, null);
        }

        #endregion
    }
}
