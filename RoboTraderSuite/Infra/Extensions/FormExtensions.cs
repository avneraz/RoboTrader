using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Infra.Extensions
{
    public static class FormExtensions
    {
        public static void SetLocationAtExtendScreen(this Form theForm)
        {
            bool formIsMaximized = false;
            if (theForm.WindowState == FormWindowState.Maximized)
            {
                formIsMaximized = true;
                theForm.WindowState = FormWindowState.Normal;
            }
            var primaryDisplay = Screen.AllScreens.ElementAtOrDefault(0);
            var extendedDisplay = Screen.AllScreens.FirstOrDefault(s => !Equals(s, primaryDisplay)) ?? primaryDisplay;

            if (extendedDisplay != null)
            {
                theForm.Left = extendedDisplay.WorkingArea.Left + (extendedDisplay.Bounds.Size.Width / 2) -
                               (theForm.Size.Width / 2);
                theForm.Top = extendedDisplay.WorkingArea.Top + (extendedDisplay.Bounds.Size.Height / 2) -
                              (theForm.Size.Height / 2);
            }
            if (formIsMaximized)
                theForm.WindowState = FormWindowState.Maximized;
        }

        public static Screen FindCurrentMonitor(this Form theForm)
        {
            var hostingScreen = Screen.FromRectangle(new Rectangle(theForm.Location, theForm.Size));
            //var primaryDisplay = Screen.AllScreens.ElementAtOrDefault(0);
            //var extendedDisplay = Screen.AllScreens.FirstOrDefault(s => !Equals(s, primaryDisplay)) ?? primaryDisplay;
            return hostingScreen;
        }

        /// <summary>
        /// Sets the form on the same screen as the Host Form. 
        /// </summary>
        /// <param name="theForm">The form.</param>
        /// <param name="hostForm">The host form.</param>
        public static void SetFormOnSameScreen(this Form theForm, Form hostForm)
        {
            if (hostForm == null)
                return;
            var hostingScreen = Screen.FromRectangle(new Rectangle(hostForm.Location, hostForm.Size));
            theForm.Left = hostingScreen.WorkingArea.Left + (hostingScreen.Bounds.Size.Width / 2) -
                           (theForm.Size.Width / 2);
            theForm.Top = hostingScreen.WorkingArea.Top + (hostingScreen.Bounds.Size.Height / 2) -
                          (theForm.Size.Height / 2);
        }
    }
}
