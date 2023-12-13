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
    public partial class DayStatic : UserControl
    {
        public DayStatic()
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Label label=(Label)sender;
            colorChange(label);
            if (label == label12 || label == label9) { bills211.Visible = true;inOutCome1.Visible = false; bills211.Title.Text = label.Text; }
            else if (label == label15 || label18 == label) { inOutCome1.Visible = true;bills211.Visible = false; inOutCome1.Title.Text = label.Text; }


            else { bills211.Visible = false; inOutCome1.Visible = false; }

        }

        private void label15_Leave(object sender, EventArgs e)
        {
           
           
        }
        private void colorChange(Label label) 
        {
            Label[] labels = { label9, label12, label15, label18 };
            foreach (Label lbl in labels)
            {
                if (label.Text != lbl.Text)
                {
                    lbl.BackColor = Color.FromArgb(255, 255, 255, 255);
                    lbl.ForeColor = Color.Black;
                }
                else
                {
                    lbl.BackColor = Color.FromArgb(255, 212, 175, 55);
                    lbl.ForeColor = Color.White;
                }
            }
        }
    }
}
