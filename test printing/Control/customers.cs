using AbuFas.db;
using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_printing;

namespace AbuFas
{
    public partial class customers : UserControl
    {
        
        Guna2DateTimePicker dtp = new Guna2DateTimePicker();
        Guna2DateTimePicker dtp2 = new Guna2DateTimePicker();
        bool breaksave = false;
        bool searchkey = false;

        public customers()
        {
            InitializeComponent();
            CustomersList.Columns[2].Visible = false;
            CustomersList.ReadOnly = true;
            incoume.Columns[4].Visible = false;
            outcome.Columns[4].Visible = false;
            SaveChange.Visible = false;
            inoutId.Visible = false;
            dtp.Visible = false;
            dtp2.Visible = false;
            dtp.TextChanged += new EventHandler(dtp_TextChanged);
            incoume.Controls.Add(dtp);
            outcome.Controls.Add(dtp2);
            Program._context = new AppDbContext();
            inout.Rows[0].Cells[1].Value = Properties.Resources.archive;

        }
        public customers(DbContextOptions<AppDbContext> options)
        {
           
        }

        private void AddCustomerBtn_Click(object sender, EventArgs e)
        {
            AddCustomer.BringToFront();
            custLoad(0);
            SaveChange.Visible = true;

        }

        private void CustomersArchiveBtn_Click(object sender, EventArgs e)
        {
            CustomersArchive.BringToFront();
            ArchiveLoad();
            SaveChange.Visible = false;
        }

        private void CustomersList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddCustomer.BringToFront();
            int r = 0;
            if (CustomersList.CurrentRow.Cells[2].Value != null)
                Int32.TryParse(CustomersList.CurrentRow.Cells[2].Value.ToString(), out r);
            custLoad(r);
            SaveChange.Visible = true;
        }

        private void ArchiveExit_Click(object sender, EventArgs e)
        {
            CustomersArchive.SendToBack();
            load();
            SaveChange.Visible = false;
        }

        private void AddCustomerExit_Click(object sender, EventArgs e)
        {
            AddCustomer.SendToBack();
            load();
            SaveChange.Visible = false;
        }
        public void load(List<Customers>custs=null)
        {
            CustomersList.Rows.Clear();
            var list = Program._context.Customers.Where(c => c.IsArchived == false).ToList();
            if (searchkey) 
            {
                if (custs.Count==0) { MessageBox.Show("لا يوجد بيانات مطابقة"); }
                else list = custs;
                searchkey= false;
            }
            index.BringToFront();
            if (list.Count > 0)
            {
                int i = 0;
                CustomersList.RowCount = list.Count + 1;
                double grams = 0, money = 0;
                foreach (var item in list)
                {

                    CustomersList.Rows[i].Cells[0].Value = i + 1;
                    CustomersList.Rows[i].Cells[1].Value = item.Name;
                    CustomersList.Rows[i].Cells[2].Value = item.Id;
                    CustomersList.Rows[i].ReadOnly = true;
                    money += item.TotalMoney;
                    grams += item.TotalGrams;
                    i++;
                }
                totalMoney.Text = money.ToString();
                totalGrams.Text = grams.ToString();
            }
        }
        public void custLoad(int id)
        {
            incoume.Rows.Clear();
            outcome.Rows.Clear();
            incoume.RowCount = 1;
            outcome.RowCount = 1;
            custName.Text = "";
            totalGrams.Text = "0000";
            totalMoney.Text = "0000";

            if (id != 0)
            {
                var list = Program._context.CustomersData.Where(c => c.Customer.Id == id).ToList();
                if (list.Count > 0)
                {
                    custName.Text = list[0].Customer.Name;
                    int i = 0;
                    int j = 0;
                    double grams = 0, money = 0;
                    foreach (var item in list)
                    {
                        if (item.IsIncome)
                        {
                            incoume.RowCount++;
                            incoume.Rows[i].Cells[0].Value = item.Date;
                            incoume.Rows[i].Cells[1].Value = item.Price;
                            incoume.Rows[i].Cells[2].Value = item.Grams;
                            incoume.Rows[i].Cells[3].Value = item.Notes;
                            incoume.Rows[i].Cells[4].Value = item.Id;
                            i++;
                            money += item.Price;
                            grams += item.Grams;

                        }
                        else
                        {
                            outcome.RowCount++;
                            outcome.Rows[j].Cells[0].Value = item.Date;
                            outcome.Rows[j].Cells[1].Value = item.Price;
                            outcome.Rows[j].Cells[2].Value = item.Grams;
                            outcome.Rows[j].Cells[3].Value = item.Notes;
                            outcome.Rows[j].Cells[4].Value = item.Id;
                            j++;
                            money -= item.Price;
                            grams -= item.Grams;

                        }
                    }
                    totalGrams.Text = grams.ToString();
                    totalMoney.Text = money.ToString();
                }
            }
        }
        public void ArchiveLoad()
        {
            inout.Rows.Clear();
            var list = Program._context.Customers.Where(c => c.IsArchived == true).ToList();
            if (list.Count > 0)
            {
                int i = 0;
                foreach (var item in list)
                {
                    inout.Rows[i].Cells[0].Value = i + 1;
                    inout.Rows[i].Cells[2].Value = item.Name;
                    inout.Rows[i].Cells[3].Value = item.Date.ToShortDateString();
                    inout.Rows[i].Cells[4].Value = item.TotalMoney;
                    inout.Rows[i].Cells[5].Value = item.TotalGrams;
                    inout.Rows[i].Cells[6].Value = item.Notes;
                    inout.Rows[i].Cells[7].Value = item.Id;
                    inout.Rows[i].ReadOnly = true;
                    i++;
                }
            }
        }

        private void sendToArchive_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("هل تريد ارشفة التاجر ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (msg == DialogResult.Yes)
            {
                var bid = custName.Text == "" ? null : custName.Text;
                if (bid != null)
                {
                    var custToDelete = Program._context.Customers.Where(c => c.Name == bid).FirstOrDefault();
                    if (custToDelete == null)
                    {
                        MessageBox.Show("هذا التاجر لم يتم حفظه بعد");
                        return;
                    }
                    else
                    {
                        custToDelete.IsArchived=true;
                        Program._context.SaveChanges();
                        MessageBox.Show("تم ارشفة التاجر بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();

                        AddCustomer.SendToBack();
                        var list = Program._context.CustomersData.Where(c => c.Customer == null).ToList();
                        Program._context.CustomersData.RemoveRange(list);
                        Program._context.SaveChanges();
                    }
                }

            }
        }

        private void SaveChange_Click(object sender, EventArgs e)
        {
            if (custName.Text.Length == 0) { MessageBox.Show("من فضلك ادخل اسم التاجر"); return; }
            if (incoume.RowCount == 1 && outcome.RowCount == 1) { MessageBox.Show("من فضلك ادخل البيانات كامله"); return; }
            var cust = Program._context.Customers.Where(c => c.Name.Equals(custName.Text)).FirstOrDefault();
            if (cust == null) { cust = new Customers(); Program._context.Customers.Add(cust); }
            cust.IsArchived = false;
            cust.Name = custName.Text;
            double grams = 0, money = 0;
            var List = new List<CustomersData>();
            foreach (DataGridViewRow row in incoume.Rows)
            {
                CustomersData data = new CustomersData();
                if (row.Index == incoume.Rows.Count - 1) continue;
                DateTime date = DateTime.Now;
                if (row.Cells[0].Value != null) DateTime.TryParse(row.Cells[0].Value.ToString(), out date);
                data.Date = date.Date;
                data.Price = (double)TryParseDouble(row.Cells[1].Value);
                money += data.Price;
                data.Grams = (double)TryParseDouble(row.Cells[2].Value);
                grams += data.Grams;
                data.Notes = row.Cells[3].Value != null ? row.Cells[3].Value.ToString() : "";
                data.IsIncome = true;
                List.Add(data);
            }
            var outcoumeList = new List<CustomersData>();
            foreach (DataGridViewRow row in outcome.Rows)
            {
                if (row.Index == outcome.Rows.Count - 1) continue;
                CustomersData data = new CustomersData();
                DateTime date = DateTime.Now;
                if (row.Cells[0].Value != null) DateTime.TryParse(row.Cells[0].Value.ToString(), out date);
                data.Date = date.Date;
                data.Price = (double)TryParseDouble(row.Cells[1].Value);
                money -= data.Price;
                data.Grams = (double)TryParseDouble(row.Cells[2].Value);
                grams -= data.Grams;
                data.Notes = row.Cells[3].Value != null ? row.Cells[3].Value.ToString() : "";
                data.IsIncome = false;
                List.Add(data);

            }
            cust.Data = List;
            cust.Date = List.AsEnumerable().OrderByDescending(d => d.Date).FirstOrDefault().Date.Date;
            cust.Notes = List.AsEnumerable().OrderByDescending(d => d.Date).FirstOrDefault().Notes;
            cust.TotalGrams = grams;
            cust.TotalMoney = money;
            Program._context.SaveChanges();
            MessageBox.Show("تمت العملية");
            load();
            AddCustomer.SendToBack();
            var list = Program._context.CustomersData.Where(c => c.Customer == null).ToList();
            Program._context.CustomersData.RemoveRange(list);
            Program._context.SaveChanges();
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

        private void incoume_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Guna2DataGridView view = (Guna2DataGridView)sender;
            Guna2DateTimePicker dtp1 = view.Name == "outcome" ? dtp2 : dtp;

            if (e.ColumnIndex == 0 && view.CurrentRow.ReadOnly == false)
            {
                Rectangle rect;
                rect = view.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                dtp1.Size = new Size(rect.Width, rect.Height);
                dtp1.Location = new Point(rect.X, rect.Y);
                dtp1.Visible = true;

            }
        }

        private void outcome_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            Guna2DataGridView view = (Guna2DataGridView)sender;
            Guna2DateTimePicker dtp1 = view.Name == "outcome" ? dtp2 : dtp;

            if (e.ColumnIndex == 0)
            {
                view.CurrentCell.Value = dtp1.Value.ToShortDateString();
                dtp1.Visible = false;
            }
            else
            {
                double v = 0;
                if (e.ColumnIndex != 3)
                {
                    if (!Double.TryParse(view.CurrentCell.EditedFormattedValue.ToString(), out v))
                    {
                        MessageBox.Show("يجب ان يكون المدخل رقم");


                    }
                }
            }
        }
        private void dtp_TextChanged(Object sender, EventArgs e)
        {
            Guna2DataGridView view = (Guna2DataGridView)dtp.Parent;
            view.CurrentCell.Value = dtp.Text.ToString();
            dtp.Visible = false;
        }

        private void inout_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            inout.Rows[e.RowIndex].Cells[1].Value = Properties.Resources.archive;
        }

        private void inout_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var ms = MessageBox.Show("هل انت متأكد من الغاء الارشفة", "", MessageBoxButtons.YesNo);
                if (ms == DialogResult.Yes)
                {
                    int bid = 0;
                    Int32.TryParse(inout.CurrentRow.Cells[7].Value.ToString(), out bid);
                    var item = Program._context.Customers.Where(c => c.Id == bid).FirstOrDefault();
                    if (item != null)
                    {
                       
                        
                            item.IsArchived = false;
                        

                        Program._context.SaveChanges();
                        load();
                 
                        AddCustomer.SendToBack();
                        var list = Program._context.CustomersData.Where(c => c.Customer == null).ToList();
                        Program._context.CustomersData.RemoveRange(list);
                        Program._context.SaveChanges();

                    }
                }
            }
        }

        private void deleteCustomer_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("هل تريد مسح التاجر ","تنبيه",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (msg == DialogResult.Yes) 
            {
                var bid = custName.Text==""?null:custName.Text;
                if(bid != null) 
                {
                    var custToDelete=Program._context.Customers.Where(c=>c.Name==bid).FirstOrDefault();
                    if(custToDelete == null)
                    {
                        MessageBox.Show("هذا التاجر لم يتم حفظه بعد");
                        return;
                    }
                    else 
                    {
                        Program._context.Customers.Remove(custToDelete);
                        Program._context.SaveChanges();
                        MessageBox.Show("تم مسح التاجر بنجاح","",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();

                        AddCustomer.SendToBack();
                        var list = Program._context.CustomersData.Where(c => c.Customer == null).ToList();
                        Program._context.CustomersData.RemoveRange(list);
                        Program._context.SaveChanges();
                    }
                }
                
            }
        }
        public void SearchByName(string name) 
        {
            var list =Program._context.Customers.Where(c=>c.Name.Contains(name)).ToList();
            searchkey = true;
            load(list);
        }
    }
}
