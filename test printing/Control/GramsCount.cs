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
           

        }
        public GramsCount(DbContextOptions<AppDbContext> options)
        {
            Program._context = new AppDbContext(options);
        }

        public void GramsCount_Load(object sender, EventArgs e)
        {
            reset();
            Program._context = new AppDbContext();
            var table = Program._context.DayStaticGrams.AsEnumerable().OrderByDescending(g => g.Date).ToList();

            double yesterday = 0;
            double today = 0;

            //   var table = Program._context.DayStaticGrams.OrderByDescending(g => g.Date).AsEnumerable().ToList();
            for (int i = 0; i < table.Count; i++)
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
                damg.ReadOnly = false;
                damg.TextChanged += Label8_TextChanged;

                

                // Set data for each label

                date.Text = table[i].Date.ToShortDateString();
                kyrat.Text = table[i].Type;
                but.Text = Math.Round(table[i].Buy,3).ToString();
                sell.Text =Math.Round(table[i].Sell,3).ToString();
                //    labelCol4.Text = table[i].Bouns.ToString();
                //  labelCol5.Text = table[i].Minus.ToString();
                var oldvalue = calculateOld(table[i].Date, table[i].Type);
                old.Text = Math.Round(oldvalue,3).ToString();
                curr.Text =Math.Round(oldvalue+table[i].Buy - table[i].Sell - table[i].Damaged,3).ToString();
                
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


            }
            var yesterday21 = calculateOld(DateTime.Today.Date, "21");
            var yesterday18 = calculateOld(DateTime.Today.Date, "18")*18/21;
            var yesterday24 = calculateOld(DateTime.Today.Date, "24")*24/21;
            var day21 = calculateOld(DateTime.Today.AddDays(1).Date, "21");
            var day18 = calculateOld(DateTime.Today.AddDays(1).Date, "18") * 18 / 21;
            var day24 = calculateOld(DateTime.Today.AddDays(1).Date, "24") * 24 / 21;
            guna2TextBox1.Text = Math.Round(yesterday21+yesterday18+yesterday24,3).ToString();
            guna2TextBox2.Text = Math.Round(day21+day18+day24,3).ToString();


            
        }
        private void Label8_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;

            // Get the current line number based on the cursor position
         int r=   tableLayoutPanel1.GetRow(textBox);

            var table = Program._context.DayStaticGrams.AsEnumerable().OrderByDescending(g => g.Date).ToList();
            var damage = 0;
            Int32.TryParse(textBox.Text, out damage);
            if (damage > 0&&r>=1)
                table[r-1].Damaged = damage;
            Program._context.SaveChanges();
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



        public double calculateOld(DateTime date,string type) 
        {
           var cuurentDay= Program._context.DayStaticGrams.Where(c => c.Date == date&&c.Type==type).FirstOrDefault();
           var oldDays=Program._context.DayStaticGrams.AsEnumerable().OrderBy(c=>c.Date).Where(c=>c.Date<date&&c.Type==type).ToList();
           double total = 0;
            if (oldDays.Count > 0)
                total = (double)oldDays.Sum(e => e.Buy - e.Sell - e.Damaged);
            return total;
        }
    }
}
