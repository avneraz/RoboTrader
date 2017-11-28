using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DevExpress.Data.Helpers;
using Infra;
using Infra.Configuration;
using Infra.Extensions;
using NHibernate.Linq;
using TNS.API.ApiDataObjects;
using TNS.Controls;

namespace Tester
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            ConfigHandler configHandler = new ConfigHandler();
            //Do the following just in case you want to create the configuration from scratch:

            Configurations = configHandler.ReadConfig();
            //var a = Configurations.Trading.UNLSymbolsListForTrading();
            AllConfigurations.AllConfigurationsObject = Configurations;
        }
        /// <summary>
        /// 
        /// </summary>
        public static AllConfigurations Configurations { get; private set; }
        private async void btnTestDiluter_Click(object sender, EventArgs e)
        {
            try
            {
                DBDiluter dbDiluter = new DBDiluter();
                int count = 0;
                await Task.Run(()=> count = dbDiluter.DiluteFromAllUnLs());
                //DateTime startDate = new DateTime(2017, 8, 21);
                //DateTime endDate = new DateTime(2017, 8, 22);

                //var count = dbDiluter.DiluteOptionsFromAllUnLs(startDate, endDate);
                MessageBox.Show($"{count} Records were diluted!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTestAsync_Click(object sender, EventArgs e)
        {
            MessageBox.Show("btnTestAsync Clicked");
        }

        private void btnTestChart_Click(object sender, EventArgs e)
        {
            try
            {
                //var control = new TradingDataChartControl();
                using (var session = DBSessionFactory.Instance.OpenSession())
                {
                    DateTime start = DateTime.Today.AddDays(-10); /*new DateTime(2017,11,15,16,00,00);*/
                    DateTime end = DateTime.Now;//new DateTime(2017, 11, 16, 17, 38, 00);

                    var list = session.Query<UnlTradingData>().Where(td=>td.ManagedSecurity.Symbol.Equals("FB")).ToList();

                    var theList = list
                        .Where(td => td.LastUpdate > start && td.LastUpdate < end ).ToList();
                    tradingDataChartControl1.SetDataSource(theList, start);
                }
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBnS_Click(object sender, EventArgs e)
        {
            OptionCalculatorForm calc = new OptionCalculatorForm();
            calc.Show();
        }
    }
}
