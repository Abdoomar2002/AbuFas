using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handle = base.CreateParams;
                handle.ExStyle |= 0x02000000;
                return handle;
            }
        }
        public BuySell()
        {
            InitializeComponent();
        }
      

        private void Buy_Click(object sender, EventArgs e)
        {
            Buy.BringToFront();
            Buy.FillColor = Color.FromArgb(255,212, 175, 55);
            sell.FillColor = Color.Black;
           billTable2.Visible = true;
            billTable1.Visible = false;
         //   billTable2.Visible = true;
           // billTable1.Visible = false;

        }

        private void sell_Click(object sender, EventArgs e)
        {
            sell.BringToFront();
            sell.FillColor = Color.FromArgb(255,212,175,55);
            Buy.FillColor = Color.Black;
            billTable1.Visible = true;
            billTable2.Visible = false;
            // billTable2.Visible = false;
            // billTable1.Visible = true;

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            billTable1.maxRowsPerPage = 0;
            billTable1.currentPrintRow = 0;
            billTable2.maxRowsPerPage = 0;
            billTable2.currentPrintRow = 0;
            if (billTable1.Visible == true)
            {
                billTable1.IsBuy = false;
                billTable1.btn_print(880, 750);
                //billTable1 = new bill();
            }
            else
            {
                billTable2.IsBuy = true;
                billTable2.btn_print(880, 750);
                
            }
        }

        private void Calculate_bill_Click(object sender, EventArgs e)
        {
            double result = Double.Parse(grams.Text) * Double.Parse(price.Text);
            double bou = 0.0;
            Double.TryParse(bouns.Text, out bou) ;
            result += result * bou/100;

            Result.Text=result.ToString();
        }

        private void firstPage_Load(object sender, EventArgs e)
        {
            billTable2.Visible=false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            Home home = (Home)this.ParentForm;
            home.archive1.BringToFront();
            home.archive1.LoadTable();
            home.search.Visible = true;
            home.from.Visible = true;
            home.to.Visible = true;
            home.start.Visible = true;
            home.searchButton.Visible = true;
            home.end.Visible = true;
            home.day.Visible = false;
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            double x;

            Guna2TextBox textBox = (Guna2TextBox)sender;
            string Text = textBox.Text.Substring(0);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 127&&e.KeyChar!='.')
            {
            
                e.Handled = true; // Mark the event as handled (prevent the character from being entered)

            }
            else
            {
                if (!Double.TryParse(textBox.Text, out x)&&textBox.Text.Length>1)
                {
                    e.Handled = true;

                    MessageBox.Show("رقم غير صحيح");
                    textBox.Text = Text.Substring(0,Text.Length-1);
                }
            }
        }
    }
}
