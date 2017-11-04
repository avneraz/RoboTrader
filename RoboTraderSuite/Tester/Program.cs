using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DevExpress.LookAndFeel;
using IBApi;
using Infra;
using log4net;
using TNS.API.ApiDataObjects;
using TNS.API.IBApiWrapper;
using TNS.BL;
using Infra.Bus;
using Infra.Configuration;
using Infra.Enum;
using TNS.API;
using TNS.BL.Analysis;
using UILogic;
using static System.Console;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]



namespace Tester
{
    class Consumer : SimpleBaseLogic
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));
        protected override void HandleMessage(IMessage message)
        {
            Logger.Info(message);
            Console.WriteLine(message);

        }
      
    }

    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    //public class SchoolContext : DbContext
    //{
    //    public SchoolContext() : base()
    //    {

    //    }

    //    public DbSet<OptionData> Students { get; set; }

    //}

        
    class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           

         

            Application.Run(new Form1());
        }
        
    }
}
