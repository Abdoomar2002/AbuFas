using AbuFas.db;
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
using test_printing;
using static Guna.UI2.Native.WinApi;

namespace AbuFas
{
    public partial class Borrow : UserControl
    {
        AppDbContext context = new AppDbContext();
        Guna2DateTimePicker dtp=new Guna2DateTimePicker();
        public Borrow()
        {
            InitializeComponent();
            inout.Rows[0].Cells[0].Value = 1;
            inout.Rows[0].Cells[1].Value = Properties.Resources.icon;
            inout.Rows[0].Cells[2].Value = Properties.Resources.icon_1;
            inout.Rows[0].Cells[3].Value = Properties.Resources.archive;
            inout.Rows[0].Cells[4].Value = "";
            inout.Rows[0].Cells[8].Value = 0;
            inout.Rows[0].Height = 40;
            inout.Columns[8].Visible= false;
            DetailsList.Rows[0].Height = 40;
            DetailsList.Columns[6].Visible= false;
            DetailsList.Rows[0].Cells[0].Value = Properties.Resources.icon;
            DetailsList.Rows[0].Cells[1].Value = Properties.Resources.icon_1;
         

            msgbox.Visible = false;
            details.Visible = false;
            DetailsList.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.TextChanged += new EventHandler(dtp_TextChanged);

        }
        private void dtp_TextChanged(Object sender, EventArgs e)
        {
            DetailsList.CurrentCell.Value = dtp.Text.ToString();
            dtp.Visible=false;
        }

        private void inout_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            inout.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
            inout.Rows[e.RowIndex].Cells[1].Value = Properties.Resources.icon;
            inout.Rows[e.RowIndex].Cells[2].Value = Properties.Resources.icon_1;
            inout.Rows[e.RowIndex].Cells[3].Value = Properties.Resources.archive;
            inout.Rows[e.RowIndex].Cells[4].Value = "";
            inout.Rows[e.RowIndex].Cells[8].Value = 0;

        }

      

        private void closeDetails_Click(object sender, EventArgs e)
        {
            details.Visible=false;
        }

        private void reject_Click(object sender, EventArgs e)
        {
            Guna2Button btn=(Guna2Button)sender;
            if (btn.Name == "accept")
            {
                msgbox.Visible=false;
            }
            else 
            {
                msgbox.Visible=false;
            }

        }

        private void inout_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.ColumnIndex < 4)
            {
                switch (e.ColumnIndex)
                {
                    case 1: { msgbox.Visible = true; }; break;// Delete
                    case 2: { details.Visible=true;
                            detailsLoad(Int32.Parse(inout.Rows[e.RowIndex].Cells[8].Value.ToString()), inout.Rows[e.RowIndex].Cells[4].Value.ToString()); 
                        }; break;//Edit
                    case 3: { msgbox.Visible = true; }; break;//Archive

                }
            }
            else
            {
                msgbox.Visible = false;
                details.Visible = true;
                int id = 0;
                Int32.TryParse(inout.Rows[e.RowIndex].Cells[8].Value.ToString(), out id);
                detailsLoad(id, inout.Rows[e.RowIndex].Cells[4].Value.ToString());


            }
        }
        public void load() 
        {
             
            context.Database.EnsureCreated();
            var list=context.Borrows.ToList();
            if(list.Count > 0) 
            {inout.RowCount=list.Count+1;
                foreach( var item in list) 
                {
                    inout.Rows[list.IndexOf(item)].Cells[4].Value = item.Name;
                    inout.Rows[list.IndexOf(item)].Cells[5].Value = item.Date.ToShortDateString();
                    inout.Rows[list.IndexOf(item)].Cells[6].Value = item.Total;
                    inout.Rows[list.IndexOf(item)].Cells[7].Value = item.Notes;
                    inout.Rows[list.IndexOf(item)].Cells[8].Value = item.Id;
                }
            }
        }
        private void detailsLoad(int id,string name) 
        {
            label5.Text = name;
            
            if (id != 0)
            {
                var detailsList = context.BorrowsData.Where(c => c.Borrow.Id == id).ToList();
                if (detailsList.Count > 0)
                {
                    DetailsList.RowCount = detailsList.Count + 1;
                    foreach (var item in detailsList)
                    {
                        DetailsList.Rows[detailsList.IndexOf(item)].Cells[2].Value = item.Date;
                        DetailsList.Rows[detailsList.IndexOf(item)].Cells[3].Value = item.Incoume;
                        DetailsList.Rows[detailsList.IndexOf(item)].Cells[4].Value = item.Outcome;
                        DetailsList.Rows[detailsList.IndexOf(item)].Cells[5].Value = item.Notes;
                        DetailsList.Rows[detailsList.IndexOf(item)].ReadOnly = true;


                    }
                }
            }
        }

        private void DetailsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==1||e.ColumnIndex==0) 
            {
                if(e.ColumnIndex==0)
                {
                    var message=MessageBox.Show("هل انت متاكد","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(message != DialogResult.Yes)
                    {
                        var item = context.BorrowsData.Where(c => c.Id ==Int32.Parse(DetailsList.Rows[e.RowIndex].Cells[6].Value.ToString())).FirstOrDefault();
                        if(item != null) 
                        {
                            context.BorrowsData.Remove(item);
                        }
                        DetailsList.Rows.Remove(DetailsList.Rows[e.RowIndex]);

                    }
                }
                else 
                {
                    DetailsList.Rows[e.RowIndex].ReadOnly = false;
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            var items =new List<BorrowsData>();
            var br=context.Borrows.Where(c=>c.Name==label5.Text).FirstOrDefault();
            if (br == null) br = new Borrows();
            br.Name = label5.Text;
            double total = 0;
            string note = "";
            DateTime date = DateTime.MinValue;
            foreach(DataGridViewRow row in DetailsList.Rows) 
            {
                var item =new BorrowsData();
                item.Date = DateTime.Parse(row.Cells[2].Value.ToString()).Date;
                item.Incoume =(double) TryParseDouble(row.Cells[3].Value);
                item.Outcome =(double) TryParseDouble(row.Cells[4].Value);
                item.Notes = row.Cells[5].Value.ToString();
                items.Add(item);
            }
            br.BData = items;
            context.SaveChanges();
        }
        private double? TryParseDouble(object value)
        {
            if (value == null)
            {
                return 0;
            }

            double result;
            return double.TryParse(value.ToString(), out result) ? (double?)result : 0;
        }

        private void DetailsList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DetailsList.Rows[e.RowIndex].Height = 40;
            DetailsList.Rows[e.RowIndex].Cells[0].Value = Properties.Resources.icon;
            DetailsList.Rows[e.RowIndex].Cells[1].Value = Properties.Resources.icon_1;
            
            
        }

        private void DetailsList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==2)
            {
                Rectangle rect;
                rect = DetailsList.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtp.Size = new Size(rect.Width, rect.Height);
                dtp.Location = new Point(rect.X, rect.Y);
                dtp.Visible = true;

            }
        }

        private void DetailsList_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }

        private void DetailsList_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==2) 
            {
                DetailsList.CurrentCell.Value = dtp.Value.ToShortDateString();
                dtp.Visible = false;
            }
            else 
            {
                double v = 0;
                if(e.ColumnIndex == 3||e.ColumnIndex==4) 
                {
                    if(!Double.TryParse(DetailsList.CurrentCell.EditedFormattedValue.ToString(),out v)) 
                    {
                        MessageBox.Show("يجب ان يكون المدخل رقم");
                        
                    }
                }
            }
        }
    }
}
