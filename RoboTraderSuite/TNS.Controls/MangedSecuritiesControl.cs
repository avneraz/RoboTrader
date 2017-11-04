using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Infra.Extensions;
using NHibernate;
using NHibernate.Linq;
using TNS.API.ApiDataObjects;
using TNS.BL;

namespace TNS.Controls
{
    public partial class MangedSecuritiesControl : UserControl
    {
        public MangedSecuritiesControl()
        {
            InitializeComponent();
        }

        private List<ManagedSecurity> _managedSecuritiesList;

        void SetDataSource()
        {

            using (ISession session = DBSessionFactory.Instance.OpenSession())
            {
                _managedSecuritiesList =
                    session.Query<ManagedSecurity>().ToList();

            }
            this.InvokeIfRequired(() =>
            {
                managedSecurityBindingSource.DataSource = _managedSecuritiesList;
                managedSecurityBindingSource.ResetBindings(false);
            });
        }

        private void MangedSecuritiesContol_Load(object sender, EventArgs e)
        {
            SetDataSource();
        }

        public void SaveManagedSecuritiesData()
        {
            //savedParametersData.LastUpdate = DateTime.Now;
            using (var session = DBSessionFactory.Instance.OpenSession())
            {
                
                //session.SetBatchSize(1000);
                foreach (var managedSecurity in _managedSecuritiesList)
                {
                    session.SaveOrUpdate(managedSecurity);
                }
                session.Flush();
                //Update:
                AppManager.AppManagerSingleTonObject.MarginManager.UpdateMaxMargin(_managedSecuritiesList);
            }

        }

        private void managedSecurityBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            btnSubmit.Enabled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SaveManagedSecuritiesData();
                ParentForm?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ParentForm?.Close();
        }
    }
}

