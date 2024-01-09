using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbuFas
{
    public partial class customers : UserControl
    {
        public customers()
        {
            InitializeComponent();
        }

        private void AddCustomerBtn_Click(object sender, EventArgs e)
        {
            AddCustomer.BringToFront();
        }

        private void CustomersArchiveBtn_Click(object sender, EventArgs e)
        {
            CustomersArchive.BringToFront();
        }

        private void CustomersList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddCustomer.BringToFront();
        }

        private void ArchiveExit_Click(object sender, EventArgs e)
        {
            CustomersArchive.SendToBack();
        }

        private void AddCustomerExit_Click(object sender, EventArgs e)
        {
            AddCustomer.SendToBack();
        }
    }
}
