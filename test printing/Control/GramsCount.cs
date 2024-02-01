using Guna.UI2.WinForms;
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
        public AppDbContext context;

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
            context = new AppDbContext();

        }
        public GramsCount(DbContextOptions<AppDbContext> options)
        {
            context = new AppDbContext(options);
        }

        public void GramsCount_Load(object sender, EventArgs e)
        {
            reset();

         
            if (context.DayStaticGrams != null)
            {
                var table = context.DayStaticGrams.AsEnumerable().OrderByDescending(g => g.Date).ToList();
                // Further code using the context...


                // AppDbContext context = new AppDbContext();
                double yesterday = 0;
                double today = 0;

                //   var table = context.DayStaticGrams.OrderByDescending(g => g.Date).AsEnumerable().ToList();
                for (int i = 0; i < table.Count; i++)
                {
                    Random random = new Random();
                    // Assuming you have a TableLayoutPanel named tableLayoutPanel1

                    // Create labels for each column
                    Guna2TextBox labelDate = CopyLabel();
                    Guna2TextBox labelCol1 = CopyLabel();
                    Guna2TextBox labelCol2 = CopyLabel();
                    Guna2TextBox labelCol3 = CopyLabel();
                    Guna2TextBox labelCol4 = CopyLabel();
                    Guna2TextBox labelCol5 = CopyLabel();
                    Guna2TextBox labelCol6 = CopyLabel();
                    Guna2TextBox labelCol7 = CopyLabel();
                    Guna2TextBox labelCol8 = CopyLabel();
                   // labelCol5.ReadOnly = false;
                   // labelCol4.ReadOnly = false;
                    labelCol8.ReadOnly = false;
                    labelCol8.TextChanged += Label8_TextChanged;

                

                    // Set data for each label

                    labelDate.Text = table[i].Date.ToShortDateString();
                    labelCol1.Text = table[i].Type;
                    labelCol3.Text = table[i].Buy.ToString();
                    labelCol2.Text = table[i].Sell.ToString();
                //    labelCol4.Text = table[i].Bouns.ToString();
                  //  labelCol5.Text = table[i].Minus.ToString();
                    labelCol6.Text = lastcharge(i, table).ToString();
                    labelCol7.Text = (table[i].Buy - table[i].Sell + lastcharge(i, table)).ToString();
                    labelCol8.Text = table[i].Damaged.ToString();

                    // Add labels to the TableLayoutPanel
                    // tableLayoutPanel1.RowCount++;
                    tableLayoutPanel1.Controls.Add(labelDate, 0, i + 1);
                    tableLayoutPanel1.Controls.Add(labelCol1, 1, i + 1);
                    tableLayoutPanel1.Controls.Add(labelCol2, 2, i + 1);
                    tableLayoutPanel1.Controls.Add(labelCol3, 3, i + 1);
                    tableLayoutPanel1.Controls.Add(labelCol6, 4, i + 1);
                    tableLayoutPanel1.Controls.Add(labelCol7, 5, i + 1);
                    tableLayoutPanel1.Controls.Add(labelCol8, 6, i + 1);
                    //   tableLayoutPanel1.RowStyles[1].Height = 40;
                    if (i + 1 < table.Count)
                        yesterday += double.Parse(labelCol6.Text);

                    today = double.Parse(labelCol7.Text);


                }

                guna2TextBox1.Text = yesterday.ToString();
                guna2TextBox2.Text = (yesterday + today).ToString();

            }
        }
        private void Label8_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;

            // Get the current line number based on the cursor position
         int r=   tableLayoutPanel1.GetRow(textBox);

            var table = context.DayStaticGrams.AsEnumerable().OrderByDescending(g => g.Date).ToList();
            var damage = 0;
            Int32.TryParse(textBox.Text, out damage);
            if (damage > 0&&r>=1)
                table[r-1].Damaged = damage;
            context.SaveChanges();
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
                total += grams[j].Buy - grams[j].Sell - grams[i].Damaged;
            }
            return total;
        }
        public void reset()
        {
            tableLayoutPanel1.Controls.Clear();
           // tableLayoutPanel1.RowCount++;
            tableLayoutPanel1.RowStyles[1].Height = 40;
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 2, 0);
            tableLayoutPanel1.Controls.Add(label4, 3, 0);
            tableLayoutPanel1.Controls.Add(label7, 4, 0);
            tableLayoutPanel1.Controls.Add(label8, 5, 0);
            tableLayoutPanel1.Controls.Add(label9, 6, 0);
        }
    }
}
