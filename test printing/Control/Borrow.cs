using AbuFas.db;
using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
        AppDbContext context;
        Guna2DateTimePicker dtp = new Guna2DateTimePicker();
        public Borrow()
        {
            InitializeComponent();
            context = new AppDbContext();
            inout.Rows[0].Cells[0].Value = 0;
            inout.Rows[0].Cells[1].Value = Properties.Resources.icon;
            inout.Rows[0].Cells[2].Value = Properties.Resources.icon_1;
            inout.Rows[0].Cells[3].Value = Properties.Resources.archive;
            inout.Rows[0].Cells[4].Value = "";
            inout.Rows[0].Cells[8].Value = 0;
            inout.Rows[0].Height = 40;
            inout.Columns[8].Visible = false;
            DetailsList.Rows[0].Height = 40;
            DetailsList.Columns[6].Visible = false;
            DetailsList.Rows[0].Cells[0].Value = Properties.Resources.icon;
            DetailsList.Rows[0].Cells[1].Value = Properties.Resources.icon_1;
            Archive.Rows[0].Cells[0].Value = 1;
            Archive.Columns[6].Visible = false;
            Archive.Rows[0].Cells[1].Value = Properties.Resources.archive;


            msgbox.Visible = false;
            details.Visible = false;
            DetailsList.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.TextChanged += new EventHandler(dtp_TextChanged);

        }
        public Borrow(DbContextOptions<AppDbContext> options)
        {
            context = new AppDbContext(options);
        }
        private void dtp_TextChanged(Object sender, EventArgs e)
        {
            DetailsList.CurrentCell.Value = dtp.Text.ToString();
            dtp.Visible = false;
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
            details.Visible = false;
        }
        //Check
        private void reject_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            if (btn.Name == "accept")
            {
                msgbox.Visible = false;
                ActionBorrow();
            }
            else
            {
                msgbox.Visible = false;
            }

        }
        //Archive or Edit or Delete
        private void inout_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.ColumnIndex < 4)
            {
                switch (e.ColumnIndex)
                {
                    case 1: { msgbox.BringToFront(); msgbox.Visible = true; break;  }// Delete
                    case 2:
                        {
                            details.Visible = true;
                            detailsLoad(Int32.Parse(inout.Rows[e.RowIndex].Cells[8].Value.ToString()), inout.Rows[e.RowIndex].Cells[4].Value.ToString());
                            break;
                        }; //Edit
                    case 3: 
                        {
                            msgbox.BringToFront();
                            msgbox.Visible = true;
                            break; }; //Archive

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
            inout.Rows.Clear();
            inout.RowCount = 1;
            context.Database.EnsureCreated();
            ArchiveLoad();
            var list = context.Borrows.Where(c => c.IsArchived == false).ToList();
            if (list.Count > 0)
            {
                double total = 0;
                foreach (var item in list)
                {
                    inout.RowCount++;
                    inout.Rows[list.IndexOf(item)].Cells[4].Value = item.Name;
                    inout.Rows[list.IndexOf(item)].Cells[5].Value = item.Date.ToShortDateString();
                    inout.Rows[list.IndexOf(item)].Cells[6].Value = item.Total;
                    total += item.Total;
                    inout.Rows[list.IndexOf(item)].Cells[7].Value = item.Notes;
                    inout.Rows[list.IndexOf(item)].Cells[8].Value = item.Id;

                }
                //  inout.RowCount++;
                inout.Rows[inout.Rows.Count - 1].Cells[0].Value = "";
                TotalBorrows.Text = total.ToString();
            }
        }
        private void detailsLoad(int id, string name)
        {
            label5.Text = name;
            DetailsList.Rows.Clear();
            if (id != 0)
            {
                var detailsList = context.BorrowsData.Where(c => c.Borrow.Id == id).ToList();
                if (detailsList.Count > 0)
                {
                    DetailsList.RowCount = detailsList.Count + 1;
                    foreach (var item in detailsList)
                    {
                        DetailsList.Rows[detailsList.IndexOf(item)].Cells[0].Value = Properties.Resources.icon;
                        DetailsList.Rows[detailsList.IndexOf(item)].Cells[1].Value = Properties.Resources.icon_1;
                        DetailsList.Rows[detailsList.IndexOf(item)].Cells[2].Value = item.Date.ToShortDateString();
                        DetailsList.Rows[detailsList.IndexOf(item)].Cells[3].Value = item.Incoume;
                        DetailsList.Rows[detailsList.IndexOf(item)].Cells[4].Value = item.Outcome;
                        DetailsList.Rows[detailsList.IndexOf(item)].Cells[5].Value = item.Notes;
                        DetailsList.Rows[detailsList.IndexOf(item)].Cells[6].Value = item.Id;

                        DetailsList.Rows[detailsList.IndexOf(item)].ReadOnly = true;
                        DetailsList.Rows[detailsList.IndexOf(item)].DefaultCellStyle.ForeColor = Color.Gray;


                    }
                }
            }
        }
        // edit or remove borrow data
        private void DetailsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 0)
            {
                if (e.ColumnIndex == 0)
                {
                    var message = MessageBox.Show("هل انت متاكد", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (message == DialogResult.Yes)
                    {
                        if (DetailsList.Rows[e.RowIndex].Cells[6].Value != null)
                        {
                            var item = context.BorrowsData.Where(c => c.Id == Int32.Parse(DetailsList.Rows[e.RowIndex].Cells[6].Value.ToString())).FirstOrDefault();
                            if (item != null)
                            {
                                context.BorrowsData.Remove(item);
                            }
                        }
                        if (e.RowIndex < DetailsList.Rows.Count - 1)
                            DetailsList.Rows.Remove(DetailsList.Rows[e.RowIndex]);
                        else
                        {
                            MessageBox.Show("هذا الصف فارغ");
                        }

                    }
                }
                else
                {
                    DetailsList.Rows[e.RowIndex].ReadOnly = false;
                    DetailsList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;

                }
            }
        }
        //Add or update Borrow Item 
        private void save_Click(object sender, EventArgs e)
        {
            if (label5.Text == "") { MessageBox.Show("من فضلك ادخل الاسم"); return; }
            if (DetailsList.RowCount == 1) { MessageBox.Show("من فضلك ادخل البيانات "); return; }



            var items = new List<BorrowsData>();
            var br = context.Borrows.Where(c => c.Name == label5.Text).FirstOrDefault();
            if (br == null) { br = new Borrows(); context.Borrows.Add(br); }
            br.Name = label5.Text;
            double total = 0;
            string note = "";
            DateTime date = DateTime.MinValue;
            foreach (DataGridViewRow row in DetailsList.Rows)
            {
                if (DetailsList.Rows.IndexOf(row) == DetailsList.RowCount - 1) { continue; }
                var item = new BorrowsData();
                DateTime dateTime = DateTime.MinValue;
                DateTime.TryParse(row.Cells[2].Value.ToString(), out dateTime);
                item.Date = dateTime == DateTime.MinValue ? DateTime.MinValue : dateTime;
                item.Incoume = (double)TryParseDouble(row.Cells[3].Value);
                item.Outcome = (double)TryParseDouble(row.Cells[4].Value);
                total += item.Incoume - item.Outcome;
                item.Notes = row.Cells[5].Value != null ? row.Cells[5].Value.ToString() : "";
                items.Add(item);
            }

            br.BData = items;
            br.Total = total;
            br.Notes = items.AsEnumerable().OrderByDescending(c => c.Date).FirstOrDefault().Notes;
            br.Date = items.AsEnumerable().OrderByDescending(c => c.Date).FirstOrDefault().Date;
            context.SaveChanges();
            MessageBox.Show("تمت الاضافة بنجاح");
            load();
            details.Visible = false;
            var list = context.BorrowsData.Where(c => c.Borrow.Id == null).ToList();
            context.BorrowsData.RemoveRange(list);
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
        // Date Picker Show
        private void DetailsList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && DetailsList.CurrentRow.ReadOnly == false)
            {
                Rectangle rect;
                rect = DetailsList.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtp.Size = new Size(rect.Width, rect.Height);
                dtp.Location = new Point(rect.X, rect.Y);
                dtp.Visible = true;

            }
        }
        //nothing
        private void DetailsList_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }
        //Validating
        private void DetailsList_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DetailsList.CurrentCell.Value = dtp.Value.ToShortDateString();
                dtp.Visible = false;
            }
            else
            {
                double v = 0;
                if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
                {
                    if (!Double.TryParse(DetailsList.CurrentCell.EditedFormattedValue.ToString(), out v))
                    {
                        MessageBox.Show("يجب ان يكون المدخل رقم");

                    }

                }
            }
        }
        //Archive Or Delete
        public void ActionBorrow()
        {
            int bid = 0;
            Int32.TryParse(inout.CurrentRow.Cells[8].Value.ToString(), out bid);
            var item = context.Borrows.Where(c => c.Id == bid).FirstOrDefault();
            if (item != null)
            {
                if (inout.CurrentCell.ColumnIndex == 1)
                {
                    item.BData.Clear();
                    context.Borrows.Remove(item);
                }
                else if (inout.CurrentCell.ColumnIndex == 3)
                {
                    item.IsArchived = true;
                }
                context.SaveChanges();
                load();

            }
            else
            {
                if (inout.CurrentRow.Index < inout.RowCount - 1)
                    inout.Rows.Remove(inout.CurrentRow);
                else MessageBox.Show("هذا الصف فارغ");
            }
        }
        public void ArchiveLoad()
        {
            Archive.Rows.Clear();
            Archive.RowCount = 1;
            context.Database.EnsureCreated();
            var list = context.Borrows.Where(c => c.IsArchived == true).ToList();
            if (list.Count > 0)
            {
                double total = 0;
                foreach (var item in list)
                {
                    Archive.RowCount++;
                    Archive.Rows[list.IndexOf(item)].Cells[2].Value = item.Name;
                    Archive.Rows[list.IndexOf(item)].Cells[3].Value = item.Date.ToShortDateString();
                    Archive.Rows[list.IndexOf(item)].Cells[4].Value = item.Total;
                    total += item.Total;
                    Archive.Rows[list.IndexOf(item)].Cells[5].Value = item.Notes;
                    Archive.Rows[list.IndexOf(item)].Cells[6].Value = item.Id;
                    Archive.Rows[list.IndexOf(item)].ReadOnly = true;


                }
                //  inout.RowCount++;
                Archive.Rows[Archive.Rows.Count - 1].Cells[0].Value = "";
                TotalBorrows.Text = total.ToString();
            }

        }

        private void CustomersArchiveBtn_Click(object sender, EventArgs e)
        {
            ArchivePanel.BringToFront();
            guna2Button1.Visible = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.Visible = false;
            inout.BringToFront();
        }

        private void Archive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var ms = MessageBox.Show("هل انت متأكد من الغاء الارشفة", "", MessageBoxButtons.YesNo);
                if (ms == DialogResult.Yes)
                {
                    int bid = 0;
                    Int32.TryParse(Archive.CurrentRow.Cells[6].Value.ToString(), out bid);
                    var item = context.Borrows.Where(c => c.Id == bid).FirstOrDefault();
                    if (item != null)
                    {
                        if (Archive.CurrentCell.ColumnIndex == 1)
                        {
                            item.IsArchived = false;
                        }

                        context.SaveChanges();
                        load();

                    }
                }
            }
        }

        private void Archive_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Archive.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
            Archive.Rows[e.RowIndex].Cells[1].Value = Properties.Resources.archive;
           // inout.Rows[e.RowIndex].Cells[2].Value = Properties.Resources.icon_1;
            //inout.Rows[e.RowIndex].Cells[3].Value = Properties.Resources.archive;
            Archive.Rows[e.RowIndex].Cells[2].Value = "";
            Archive.Rows[e.RowIndex].Cells[6].Value = 0;
        }
    }
}
