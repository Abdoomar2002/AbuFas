using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbuFas
{
    public partial class bills21 : UserControl
    {
        public bills21()
        {
            InitializeComponent();
           Label label=new Label();
            label.Text = "3";
            label.BackColor = Color.FromArgb(255, 212, 175, 55);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Fill;
            label.ForeColor = Color.White;
            label.Font = new System.Drawing.Font("Cairo", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label.Margin = label1.Margin;

            tableLayoutPanel1.Controls.Add(label,0,1);
            Label label2 = new Label();
            label2.Text = "4";
            label2.BackColor = Color.FromArgb(255, 212, 175, 55);
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Dock = DockStyle.Fill;
            label2.ForeColor = Color.White;
           label2.Font = new System.Drawing.Font("Cairo", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Margin=label1.Margin;
            tableLayoutPanel1.Controls.Add(label2, 2, 1);
             Guna2TextBox newtext=new Guna2TextBox
             {
                
                 Margin = guna2TextBox1.Margin,
                 BorderRadius = guna2TextBox1.BorderRadius,
                 Enabled = guna2TextBox1.Enabled, 
                 Dock = guna2TextBox1.Dock,
                 Font = guna2TextBox1.Font,
                 BackColor = guna2TextBox1.BackColor,
                 ForeColor = guna2TextBox1.ForeColor
             };
            newtext.Text = "7";
            tableLayoutPanel1.Controls.Add(newtext, 1, 1);
            Guna2TextBox newtext1 = new Guna2TextBox
            {

                Margin = guna2TextBox1.Margin,
                BorderRadius = guna2TextBox1.BorderRadius,
                Enabled = guna2TextBox1.Enabled,
                Dock = guna2TextBox1.Dock,
                Font = guna2TextBox1.Font,
                BackColor = guna2TextBox1.BackColor,
                ForeColor = guna2TextBox1.ForeColor
            };
            newtext1.Text = "7";
            tableLayoutPanel1.Controls.Add(newtext1, 3, 1);
        //    tableLayoutPanel1.AutoScroll= true;
         
        }
        
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            //tableLayoutPanel1.
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
