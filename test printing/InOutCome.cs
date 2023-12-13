using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace AbuFas
{
    public partial class InOutCome : UserControl
    {
        public InOutCome()
        {
            InitializeComponent();
            this.Visible = false;

             
            guna2DataGridView1.Rows[0].Cells[0].Value = 1;
            guna2DataGridView1.Rows[0].Cells[1].Value=Properties.Resources.icon;
            guna2DataGridView1.Rows[0].Cells[2].Value=Properties.Resources.icon_1;
            guna2DataGridView1.Rows[0].Height = 40;

            //dataGridViewImageColumn1.Image = Properties.Resources.icon;
            
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void guna2DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value =e.RowIndex+1;
            guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value = Properties.Resources.icon;
            guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value = Properties.Resources.icon_1;
        }
    }
}
