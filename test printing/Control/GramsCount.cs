﻿using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using test_printing;
using test_printing.db;

namespace AbuFas
{
    public partial class GramsCount : UserControl
    {
        DateTime current=DateTime.Now.Date;
        bool searchFlag = false;
        int counter = 0;
       List<DayStaticGrams> grams;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handle = base.CreateParams;
                handle.ExStyle |= 0x02000000;
                return handle;
            }
        }
        public GramsCount()
        {
            InitializeComponent();
          //  Program._context = new AppDbContext();


        }


        public void GramsCount_Load(object sender, EventArgs e)
        {
            if (!searchFlag)
            {
                current = DateTime.Now.Date;

            }
            reset();
           // Program._context = new AppDbContext();
            var tableDates =  Program._context.DayStaticGrams.ToList().OrderByDescending(g => g.Date).Select(g => g.Date)
                                                   .Distinct()
                                                  .Take(3).ToList();
            var table =  Program._context.DayStaticGrams.Where(g=>tableDates.Contains(g.Date)).OrderByDescending(g => g.Date).ToList();
            if (searchFlag) 
            {
                if (grams.Count == 0) 
                {
                    MessageBox.Show("لا يوجد بيانات مطابقة للفترة");
                    searchFlag = false;
                    return;
                }
                searchFlag = false;
                table = grams;
                current = table[0].Date;
            }
            double yesterday = 0;
            double today = 0;
            counter = 0;
            //   var table = Program._context.DayStaticGrams.OrderByDescending(g => g.Date).AsEnumerable().ToList();
            for (int i = 0; i < table.Count; i++,counter++)
            {
                Random random = new Random();
                // Assuming you have a TableLayoutPanel named tableLayoutPanel1

                // Create labels for each column
                Guna2TextBox date = CopyLabel();
                Guna2TextBox kyrat = CopyLabel();
                Guna2TextBox sell = CopyLabel();
                Guna2TextBox but = CopyLabel();
                Guna2TextBox labelCol4 = CopyLabel();
                Guna2TextBox labelCol5 = CopyLabel();
                Guna2TextBox old = CopyLabel();
                Guna2TextBox curr = CopyLabel();
                Guna2TextBox damg = CopyLabel();
                // labelCol5.ReadOnly = false;
                // labelCol4.ReadOnly = false;

                

                // Set data for each label

                date.Text = table[i].Date.ToShortDateString();
                kyrat.Text = table[i].Type;
                but.Text = Math.Round(table[i].Buy,2).ToString();
                sell.Text =Math.Round(table[i].Sell,2).ToString();
                //    labelCol4.Text = table[i].Bouns.ToString();
                //  labelCol5.Text = table[i].Minus.ToString();
                var oldvalue = calculateOld(table[i].Date, table[i].Type);
                old.Text = Math.Round(oldvalue,2).ToString();
                curr.Text =Math.Round(oldvalue+table[i].Buy - table[i].Sell - table[i].Damaged,2).ToString();
                
                damg.Text = table[i].Damaged.ToString();

                // Add labels to the TableLayoutPanel
                // tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.Controls.Add(date, 0, i + 1);
                tableLayoutPanel1.Controls.Add(kyrat, 1, i + 1);
                tableLayoutPanel1.Controls.Add(sell, 2, i + 1);
                tableLayoutPanel1.Controls.Add(but, 3, i + 1);
                tableLayoutPanel1.Controls.Add(old, 4, i + 1);
                tableLayoutPanel1.Controls.Add(curr, 5, i + 1);
                tableLayoutPanel1.Controls.Add(damg, 6, i + 1);
                //   tableLayoutPanel1.RowStyles[1].Height = 40;
                if (i + 1 < table.Count)
                    yesterday += double.Parse(old.Text);

                today = double.Parse(curr.Text);
              //  if (table[i].Date == current)
                //{
                    damg.ReadOnly = false;
                    damg.TextChanged += Label8_TextChanged;
               // }

            }
            var yesterday21 = calculateOld(current.Date, "21");
            var yesterday18 = calculateOld(current.Date, "18")*18/21;
            var yesterday24 = calculateOld(current.Date, "24")*24/21;
            var day21 = calculateOld(current.AddDays(1).Date, "21");
            var day18 = calculateOld(current.AddDays(1).Date, "18") * 18 / 21;
            var day24 = calculateOld(current.AddDays(1).Date, "24") * 24 / 21;
            guna2TextBox1.Text = Math.Round(yesterday21+yesterday18+yesterday24,2).ToString();
            guna2TextBox2.Text = Math.Round(day21+day18+day24,2).ToString();

            guna2TextBox4.Text = calculatecurr(current.Date).ToArray()[0].ToString();
            guna2TextBox3.Text = calculatecurr(current.Date).ToArray()[1].ToString();

        }
        private void Label8_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;

            int row = tableLayoutPanel1.GetRow(textBox);
            int column = tableLayoutPanel1.GetColumn(textBox);

            var table = Program._context.DayStaticGrams.AsEnumerable().OrderByDescending(g => g.Date).ToList();
            double damage = 0.0;
            Double.TryParse(textBox.Text, out damage);
            if (damage >= 0 && row >= 1)
                table[row - 1].Damaged = damage;
            Program._context.SaveChanges();

            LoadAfter(row, column);

            // Call CalcOthers to update all rows
            CalcOthers();
        }

        private void LoadAfter(int r,int c) 
        {
           var damg= tableLayoutPanel1.GetControlFromPosition(c, r);
           var now= tableLayoutPanel1.GetControlFromPosition(c-1, r);
           var last= tableLayoutPanel1.GetControlFromPosition(c-2, r);
           var buy= tableLayoutPanel1.GetControlFromPosition(c-3, r);
           var sell= tableLayoutPanel1.GetControlFromPosition(c-4, r);
           var type= tableLayoutPanel1.GetControlFromPosition(c-5, r);
           var date= tableLayoutPanel1.GetControlFromPosition(c-6, r);
           var item=Program._context.DayStaticGrams.Where(m=>m.Date==DateTime.Parse(date.Text)&&m.Type==type.Text).FirstOrDefault();
            //    item.Damaged=Int32.Parse(damg.ToString());
            var oldvalue = calculateOld(current, type.Text.ToString());
            last.Text = Math.Round(oldvalue, 2).ToString();
            now.Text = Math.Round(oldvalue + Double.Parse(buy.Text.ToString()) - Double.Parse(sell.Text.ToString()) - item.Damaged, 2).ToString();

            var yesterday21 = calculateOld(current.Date, "21");
            var yesterday18 = calculateOld(current.Date, "18") * 18 / 21;
            var yesterday24 = calculateOld(current.Date, "24") * 24 / 21;
            var day21 = calculateOld(current.AddDays(1).Date, "21");
            var day18 = calculateOld(current.AddDays(1).Date, "18") * 18 / 21;
            var day24 = calculateOld(current.AddDays(1).Date, "24") * 24 / 21;
            guna2TextBox1.Text = Math.Round(yesterday21 + yesterday18 + yesterday24, 2).ToString();
            guna2TextBox2.Text = Math.Round(day21 + day18 + day24, 2).ToString();
/*
            if (item.Type=="18")
                guna2TextBox2.Text = (Math.Round(Double.Parse(guna2TextBox2.Text) - item.Damaged*18/21,3)).ToString();
            else if(item.Type=="24")
                guna2TextBox2.Text = (Math.Round(Double.Parse(guna2TextBox2.Text) - item.Damaged * 24 / 18, 3)).ToString();
            else
            guna2TextBox2.Text=(Math.Round(Double.Parse(guna2TextBox2.Text) - item.Damaged, 3)).ToString();
     */
        }
        

        private Guna2TextBox CopyLabel()
        {
            Guna2TextBox newLabel = new Guna2TextBox();

            // Copy properties from the original label to the new label
            newLabel.Text = label1.Text;
            newLabel.Font = label1.Font;
            newLabel.ForeColor = label1.ForeColor;
            newLabel.BackColor = label1.BackColor;
            newLabel.TextAlign = HorizontalAlignment.Center;
            newLabel.RightToLeft = RightToLeft.Yes;
            newLabel.Dock = DockStyle.Fill;
            newLabel.AutoSize = true;
            newLabel.Margin = new Padding(0, 0, 1, 0);
            newLabel.BorderThickness = 1;
            newLabel.ReadOnly = true;


            newLabel.Height = 40;

            // ... copy other properties as needed

            return newLabel;
        }
        public double lastcharge(int i, List<DayStaticGrams> grams)
        {
            double total = 0;
            for (int j = grams.Count - 1; j > i; j--)
            {
                if (grams[j].Type=="21")
                total += grams[j].Buy - grams[j].Sell - grams[i].Damaged;
                else if (grams[j].Type == "18") 
                {
                    double total2 = grams[j].Buy - grams[j].Sell - grams[i].Damaged;
                    total += total2 * 18 / 21;
                }
                else if (grams[j].Type == "24")
                {
                    double total2 = grams[j].Buy - grams[j].Sell - grams[i].Damaged;
                    total += total2 * 24 / 21;
                }
            }
            return total;
        }
        public void reset()
        {
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();      
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute));
         // tableLayoutPanel1.Dock= DockStyle.Fill;
         //  tableLayoutPanel1.RowCount++;

          tableLayoutPanel1.RowStyles[0].Height = 80;
            tableLayoutPanel1.PerformLayout();
           // tableLayoutPanel1.r.Height = 40;
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 2, 0);
            tableLayoutPanel1.Controls.Add(label4, 3, 0);
            tableLayoutPanel1.Controls.Add(label7, 4, 0);
            tableLayoutPanel1.Controls.Add(label8, 5, 0);
            tableLayoutPanel1.Controls.Add(label9, 6, 0);
        //    tableLayoutPanel1.Controls[0].Height = 40;
        }

        private void CalcOthers()
        {
            // Iterate through each row in the TableLayoutPanel
            for (int i = 1; i <= counter; i++)
            {
                // Get the controls from the current row
                var dateControl = tableLayoutPanel1.GetControlFromPosition(0, i) as Guna2TextBox;
                var typeControl = tableLayoutPanel1.GetControlFromPosition(1, i) as Guna2TextBox;
                var sellControl = tableLayoutPanel1.GetControlFromPosition(2, i) as Guna2TextBox;
                var buyControl = tableLayoutPanel1.GetControlFromPosition(3, i) as Guna2TextBox;
                var oldControl = tableLayoutPanel1.GetControlFromPosition(4, i) as Guna2TextBox;
                var currControl = tableLayoutPanel1.GetControlFromPosition(5, i) as Guna2TextBox;
                var damgControl = tableLayoutPanel1.GetControlFromPosition(6, i) as Guna2TextBox;

                if (dateControl != null && typeControl != null && sellControl != null && buyControl != null && oldControl != null && currControl != null && damgControl != null)
                {
                    // Parse the necessary values
                    DateTime date = DateTime.Parse(dateControl.Text);
                    string type = typeControl.Text;
                    double buy = double.Parse(buyControl.Text);
                    double sell = double.Parse(sellControl.Text);
                    double damaged = 0.0;
                    double.TryParse(damgControl.Text,out damaged);

                    // Calculate old and current values
                    var oldvalue = calculateOld(date, type);
                    oldControl.Text = Math.Round(oldvalue, 2).ToString();
                    currControl.Text = Math.Round(oldvalue + buy - sell - damaged, 2).ToString();
                }
            }

            // Recalculate the total values for the text boxes at the bottom
            var yesterday21 = calculateOld(current.Date, "21");
            var yesterday18 = calculateOld(current.Date, "18") * 18 / 21;
            var yesterday24 = calculateOld(current.Date, "24") * 24 / 21;
            var day21 = calculateOld(current.AddDays(1).Date, "21");
            var day18 = calculateOld(current.AddDays(1).Date, "18") * 18 / 21;
            var day24 = calculateOld(current.AddDays(1).Date, "24") * 24 / 21;
            guna2TextBox1.Text = Math.Round(yesterday21 + yesterday18 + yesterday24, 2).ToString();
            guna2TextBox2.Text = Math.Round(day21 + day18 + day24, 2).ToString();

            guna2TextBox4.Text = calculatecurr(current.Date).ToArray()[0].ToString();
            guna2TextBox3.Text = calculatecurr(current.Date).ToArray()[1].ToString();
        }


        public double calculateOld(DateTime date, string type)
        {
            var cuurentDay =  Program._context.DayStaticGrams.Where(c => c.Date == date && c.Type == type).FirstOrDefault();
            var oldDays = Program._context.DayStaticGrams.AsEnumerable().OrderBy(c => c.Date).Where(c => c.Date < date && c.Type == type).ToList();
            double total = 0;
            if (oldDays.Count > 0)
                total = (double)oldDays.Sum(e => e.Buy - e.Sell - e.Damaged);
            return total;
        }
        public List<double> calculatecurr(DateTime date)
        {
            double totalBuy = 0,totalSell=0;
            var cuurentDay =  Program._context.DayStaticGrams.AsEnumerable().OrderByDescending(g => g.Date).Where(c => c.Date == date ).ToList();
            foreach (var item in cuurentDay)
            {
                if (item.Type == "18") { totalBuy += item.Buy * 18 / 21;totalSell += item.Sell * 18 / 21; }
                if (item.Type == "24") { totalBuy += item.Buy * 24 / 21;totalSell += item.Sell * 24 / 21; }
                if (item.Type == "21") { totalBuy += item.Buy ; totalSell += item.Sell ; }
            }
          List<double> days = new List<double>();
            totalBuy = Math.Round(totalBuy, 2);
            totalSell=Math.Round(totalSell, 2);
            days.Add(totalBuy);
            days.Add(totalSell);
            return days;
        }
        public void SearchByDate(DateTime st, DateTime ed) 
        {
            grams=Program._context.DayStaticGrams.OrderByDescending(g => g.Date).Where(c=>c.Date>=st&&c.Date<=ed).ToList();
            searchFlag = true;
            GramsCount_Load(null, null);
        }
    }
}
