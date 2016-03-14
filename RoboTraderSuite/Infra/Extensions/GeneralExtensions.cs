using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace Infra.Extensions
{
    public static class GeneralExtensions
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof (GeneralExtensions));

        public static bool In<T>(this T val, params T[] values) where T : struct
        {
            return values.Contains(val);
        }

        /// <summary>
        /// Invoke sent action, with the sent arguments, by using the object invoke method, only if necessary.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="action"></param>
        /// <param name="args"></param>
        public static void InvokeIfRequired(this ISynchronizeInvoke obj,
            MethodInvoker action, object[] args = null)
        {



            try
            {
                if (obj.InvokeRequired)
                {
                    obj.Invoke(action, args);
                }
                else
                {
                    action();
                }
            }
            catch (ObjectDisposedException ex)
            {
                Logger.Error(ex.Message, ex);

            }
        }
    }
}