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
using test_printing;

namespace AbuFas
{
    public partial class customers : UserControl
    {
        private  AppDbContext context;
        public customers()
        {
            InitializeComponent();
            CustomersList.Columns[2].Visible = false;
            CustomersList.ReadOnly = true;
            incoume.Columns[4].Visible = false;
            outcome.Columns[4].Visible = false;
            SaveChange.Visible = false;
            inoutId.Visible = false;
          
            
        }
        public customers(DbContextOptions<AppDbContext> options)
        {
            context = new AppDbContext(options);
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
            if(CustomersList.CurrentRow.Cells[2].Value !=null)
            Int32.TryParse(CustomersList.CurrentRow.Cells[2].Value.ToString(), out r);
            custLoad(r);
            SaveChange.Visible = true;
        }

        private void ArchiveExit_Click(object sender, EventArgs e)
        {
            CustomersArchive.SendToBack();
            SaveChange.Visible = false;
        }

        private void AddCustomerExit_Click(object sender, EventArgs e)
        {
            AddCustomer.SendToBack();
            SaveChange.Visible = false;
        }
        public void load() 
        {
            CustomersList.Rows.Clear();
            context=new AppDbContext();
            var list=context.Customers.ToList();
            index.BringToFront();
            if(list.Count > 0) 
            {
                int i = 0;
                CustomersList.RowCount= list.Count+1;
                foreach(var item in list) 
                {
                    
                    CustomersList.Rows[i].Cells[0].Value = i+1;
                    CustomersList.Rows[i].Cells[1].Value = item.Name;
                    CustomersList.Rows[i].Cells[2].Value = item.Id;
                    CustomersList.Rows[i].ReadOnly = true;
                }
            }
        }
        public void custLoad(int id)
        {
            incoume.Rows.Clear();
            outcome.Rows.Clear();
            custName.Text = "";
            totalGrams.Text = "0000";
            totalMoney.Text = "0000";

            if (id != 0)
            {
                var list = context.CustomersData.Where(c => c.Id == id).ToList();
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
            var list=context.Customers.Where(c=>c.IsArchived==true).ToList();
            if (list.Count > 0) 
            {
                int i = 0;
                foreach (var item in list)
                {
                    inout.Rows[i].Cells[0].Value=i+1;
                    inout.Rows[i].Cells[1].Value=item.Name;
                    inout.Rows[i].Cells[2].Value=item.Date.ToShortDateString();
                    inout.Rows[i].Cells[3].Value=item.TotalMoney;
                    inout.Rows[i].Cells[4].Value=item.TotalGrams;
                    inout.Rows[i].Cells[5].Value=item.Notes;
                    inout.Rows[i].Cells[6].Value=item.Id;
                    inout.Rows[i].ReadOnly = true;
                    i++;
                }
            }
        }
    }
}
