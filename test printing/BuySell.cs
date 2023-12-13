using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_printing
{
    public partial class BuySell : UserControl
    {
        public BuySell()
        {
            InitializeComponent();
        }

        private void Buy_Click(object sender, EventArgs e)
        {
            Buy.BringToFront();
            Buy.FillColor = Color.FromArgb(255,212, 175, 55);
            sell.FillColor = Color.Black;
           
            billBuy1.Visible = true;
            bill1.Visible = false;

        }

        private void sell_Click(object sender, EventArgs e)
        {
            sell.BringToFront();
            sell.FillColor = Color.FromArgb(255,212,175,55);
            Buy.FillColor = Color.Black;
            billBuy1.Visible = false;
            bill1.Visible = true;

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            bill1.maxRowsPerPage = 0;
            bill1.currentPrintRow = 0;
            billBuy1.maxRowsPerPage = 0;
            billBuy1.currentPrintRow = 0;
            if (bill1.Visible == true)
                bill1.btn_print(880, 750);
            else
                billBuy1.btn_print(880, 750);
        }

        private void Calculate_bill_Click(object sender, EventArgs e)
        {
            double result = Double.Parse(grams.Text) * Double.Parse(price.Text);
            result+=result*Double.Parse(bouns.Text)/100;
            Result.Text=result.ToString();
        }

        private void firstPage_Load(object sender, EventArgs e)
        {
            billBuy1.Visible=false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            Home home = (Home)this.ParentForm;
            home.archive1.BringToFront();
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 127)
            {
                e.Handled = true; // Mark the event as handled (prevent the character from being entered)
            }
        }
    }
}
