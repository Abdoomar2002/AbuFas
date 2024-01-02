using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void GramsCount_Load(object sender, EventArgs e)
        {

            /*   
               data.Columns[0].Width = label1.Width+4;
               data.Columns[1].Width = (int)tableLayoutPanel1.ColumnStyles[1].Width*tableLayoutPanel1.Width/100;
               data.Columns[2].Width = label2.Width+4;
               int w = data.Width - data.Columns[0].Width- data.Columns[1].Width;
               w /= 13;
               data.Columns[3].Width = w;
               data.Columns[4].Width = w;
               data.Columns[5].Width = w;
               data.Columns[6].Width = w;
               data.Columns[7].Width = w;
               data.Columns[8].Width = w;
               */

            AppDbContext context = new AppDbContext();
            var table = context.DayStaticGrams.AsEnumerable().OrderByDescending(g => g.Date).ToList();
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

                // Set data for each label
                
                labelDate.Text = table[i].Date.ToShortDateString();
                labelCol1.Text = table[i].Type;
                labelCol2.Text = table[i].Buy.ToString();
                labelCol3.Text = table[i].Sell.ToString();
                labelCol4.Text = table[i].Bouns.ToString();
                labelCol5.Text = table[i].Minus.ToString();
                labelCol6.Text = lastcharge(i,table).ToString();
                labelCol7.Text =(table[i].Buy-table[i].Sell+ lastcharge(i,table)).ToString();
                labelCol8.Text = "";

                // Add labels to the TableLayoutPanel
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.Controls.Add(labelDate, 0, i + 1);
                tableLayoutPanel1.Controls.Add(labelCol1, 1, i + 1);
                tableLayoutPanel1.Controls.Add(labelCol2, 2, i + 1);
                tableLayoutPanel1.Controls.Add(labelCol3, 3, i + 1);
                tableLayoutPanel1.Controls.Add(labelCol4, 4, i + 1);
                tableLayoutPanel1.Controls.Add(labelCol5, 5, i + 1);
                tableLayoutPanel1.Controls.Add(labelCol6, 6, i + 1);
                tableLayoutPanel1.Controls.Add(labelCol7, 7, i + 1);
                tableLayoutPanel1.Controls.Add(labelCol8, 8, i + 1);
                tableLayoutPanel1.RowStyles[1].Height = 40;


            }
           

          /*  for(int i=0;i<tableLayoutPanel1.RowCount;i++)
            {
               tableLayoutPanel1.RowStyles[i].SizeType = SizeType.Absolute;
                tableLayoutPanel1.RowStyles[i].Height = 40;
                
            }*/


            //data.Rows[0].Cells[16].Value = "150";

            /*  tableLayoutPanel1.RowStyles[1].Height = 40;
              for (int row = 2; row < 14; row++)
              {
                  tableLayoutPanel1.RowCount++;


                  for (int col = 0; col < 17; col++)
                  {
                      // Create a PictureBox
                      Font cairoFont = new Font("Cairo", 10, FontStyle.Regular);
                      Random rnd = new Random();
                      // Create a Label
                     Guna2TextBoxlbl = new Label
                      {
                          Text = rnd.Next(0,800).ToString(),
                          Font = cairoFont,
                          Dock = DockStyle.Fill,
                          TextAlign = ContentAlignment.MiddleCenter
                      };

                      if (col == 0)
                      {
                          lbl.Text = "10/12/2023";
                          tableLayoutPanel1.Controls.Add(lbl, col, row);
                          tableLayoutPanel1.SetColumnSpan(lbl, 2);
                      }else
                      tableLayoutPanel1.Controls.Add(lbl, col, row);
                      //tableLayoutPanel1.RowStyles[row-1].Height = 40;
                  }


              }
              tableLayoutPanel1.Height++;
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
            newLabel.Margin = new Padding(0,0,1,0);
            newLabel.BorderThickness = 1;
            
            
            newLabel.Height = 40;
            
            // ... copy other properties as needed

            return newLabel;
        }
        public double lastcharge(int i,List<DayStaticGrams> grams)
        {
            double total = 0;
            for(int j = grams.Count-1;j>i;j--) 
            {
                total += grams[j].Buy - grams[j].Sell;
            }
            return total;
        }
    }
}
