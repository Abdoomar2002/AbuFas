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

namespace AbuFas
{
    public partial class GramsCount : UserControl
    {
        public GramsCount()
        {
            InitializeComponent();
        }

        private void GramsCount_Load(object sender, EventArgs e)
        {

            
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
            data.Columns[9].Width = w;
            data.Columns[10].Width = w;
            data.Columns[11].Width = w;
            data.Columns[12].Width = w;
            data.Columns[13].Width = w;
            data.Columns[14].Width = w;
            data.Columns[15].Width = w;
        

            for (int i = 0; i < 14; i++)
            {
                Random random = new Random();
                data.Rows.Add();
                data.Rows[i].Cells[0].Value = "10/12/2023";
                data.Rows[i].Cells[1].Value = 21;
                data.Rows[i].Cells[2].Value =random.Next(0,999) ;
                data.Rows[i].Cells[3].Value = random.Next(0, 99);
                data.Rows[i].Cells[4].Value = random.Next(0, 999);
                data.Rows[i].Cells[5].Value = random.Next(0, 99);
                data.Rows[i].Cells[6].Value = random.Next(0, 999);
                data.Rows[i].Cells[7].Value = random.Next(0, 99);
                data.Rows[i].Cells[8].Value = random.Next(0, 999);
                data.Rows[i].Cells[9].Value = random.Next(0, 99);
                data.Rows[i].Cells[10].Value = random.Next(0, 999);
                data.Rows[i].Cells[11].Value = random.Next(0, 99);
                data.Rows[i].Cells[12].Value = random.Next(0, 999);
                data.Rows[i].Cells[13].Value = random.Next(0, 99);
                data.Rows[i].Cells[14].Value = random.Next(0, 999);
                data.Rows[i].Cells[15].Value = random.Next(0, 99);
            }
           
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
                   Label lbl = new Label
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
    }
}
