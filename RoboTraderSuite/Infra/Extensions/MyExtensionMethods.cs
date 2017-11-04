using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Infra.Custom;

namespace Infra.Extensions
{
    public static class MyExtensionMethods
    {

        /*
        /// <summary>
        /// Gets the quarter:
        /// Jan to March   - Q1
        /// April to June  - Q2
        /// July to Sep    - Q3
        /// Oct to Dec     - Q4
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static int GetQuarter(this DateTime dateTime)
        {
            if (dateTime.Month <= 3)
                return 1;

            if (dateTime.Month <= 6)
                return 2;

            if (dateTime.Month <= 9)
                return 3;

            return 4;
        }

        public static string GetQuarterName(this DateTime dateTime)
        {
            string quarterName = 
                 string.Format("{0}-{1:yy}", GetQuarter(dateTime), dateTime);
            return quarterName;
        }
        //*/

        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        /// <exception cref="System.ArgumentException">The type must be serializable.;source</exception>
        public static T Clone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);;
            }
        }

        public static IEnumerable<TT> DistinctBy<TT>(this IEnumerable<TT> list, Func<TT, object> propertySelector)
        {
            return list.GroupBy(propertySelector).Select(x => x.First());
        }
        public static void SetBestFitAllColumns(this DevExpress.XtraGrid.Views.Grid.GridView theGridView)
        {
            try
            {
                foreach (GridColumn column in theGridView.Columns)
                {
                    column.BestFit();
                }
            }
            catch (Exception)
            {
                return;
            }
        }

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
          var hostingScreen =  Screen.FromRectangle(new Rectangle(theForm.Location, theForm.Size));
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
            theForm.Left = hostingScreen.WorkingArea.Left + (hostingScreen.Bounds.Size.Width/2) -
                           (theForm.Size.Width/2);
            theForm.Top = hostingScreen.WorkingArea.Top + (hostingScreen.Bounds.Size.Height/2) -
                          (theForm.Size.Height/2);
        }
        /// <summary>
        /// Create and show given control within form
        /// </summary>
        /// <param name="control">The control being shown.</param>
        /// <param name="parentForm">The Parent form that this control should be display within parent form borders.</param>
        /// <param name="floating">indicate if the control has no caption and can be floating. </param>
        /// <returns></returns>
        public static Form ShowControl(this Control control, Form parentForm, bool floating = false)
        {
            var containerForm = floating ? new FloatingForm() : new Form();
            containerForm.Size = control.Size;

            control.Dock = DockStyle.Fill;
            containerForm.Controls.Add(control);
            containerForm.Show();
            containerForm.SetFormOnSameScreen(parentForm);
            return containerForm;
        }

        public static void ShowControlInContainer(this Control control, Control container)
        {
            int top = container.Top + ( container.Height - control.Height ) /2;
            int left = container.Left + (container.Width - control.Width) / 2;
            control.Location = new Point(left, top);
            container.Controls.Add(control);
            control.BringToFront();
            control.Visible = true;
        }
    }
}
