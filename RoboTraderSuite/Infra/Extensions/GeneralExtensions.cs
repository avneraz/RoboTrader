using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infra.Extensions
{
    public static class GeneralExtensions
    {
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
            if (obj.InvokeRequired)
            {
                obj.Invoke(action, args);
            }
            else
            {
                action();
            }
        }
    }
}
