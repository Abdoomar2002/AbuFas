using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using test_printing;
using test_printing.db;

namespace AbuFas
{
    public partial class InOutCome : UserControl
    {
        public DateTime dateTime { get; set; }
        public int moneyId;
        public bool fl;
        public int index=0;
        public InOutCome()
        {
            InitializeComponent();
            this.Visible = false;
            
             
            inout.Rows[0].Cells[0].Value = 1;
            inout.Rows[0].Cells[1].Value=Properties.Resources.icon;
            inout.Rows[0].Cells[2].Value=Properties.Resources.icon_1;
            inout.Rows[0].Height = 40;

            //dataGridViewImageColumn1.Image = Properties.Resources.icon;
            
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void guna2DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            inout.Rows[e.RowIndex].Cells[0].Value =e.RowIndex+1;
            inout.Rows[e.RowIndex].Cells[1].Value = Properties.Resources.icon;
            inout.Rows[e.RowIndex].Cells[2].Value = Properties.Resources.icon_1;
            inout.Rows[e.RowIndex].Cells[4].Value = dateTime.ToShortDateString();
        }
        public void Load(int id,bool flag) 
        {
            inout.Rows.Clear();
            inout.Rows[0].Cells[4].Value = dateTime.ToShortDateString();
            
            AppDbContext context = new AppDbContext();
            var items =context.IncomeOutcome.Where(c=>c.Money.Id==id&&c.IsIncome==flag).ToList();
            moneyId = id;
            fl = flag;
            if (items.Count <= 0) return;
            inout.RowCount=items.Count+1;
            if(items.Count>0) 
            { int i = 0;
                foreach( var item in items)
                {
                    inout.Rows[i].Cells[3].Value = item.Name;
                    inout.Rows[i].Cells[4].Value = dateTime.ToShortDateString();
                    inout.Rows[i].Cells[5].Value = item.Price;
                    inout.Rows[i].Cells[6].Value = item.Notes;
                    inout.Rows[i].ReadOnly=true;
                    i++;
                }
                index=items.Count+1;
            }
            
        }

        private void inout_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            AppDbContext context = new AppDbContext();
            var item = new IncomeOutcome();
            if(e.ColumnIndex>2)
            if (inout.Rows[e.RowIndex].Cells[3].Value == null||(inout.Rows[e.RowIndex].Cells[5].Value==null)) { MessageBox.Show("من فضلك ادخل البيانات كامله");return; }
            item.Name = inout.Rows[e.RowIndex].Cells[3].Value.ToString() ;
            item.Date =dateTime.Date ;
            item.Price = (double)TryParseDouble(inout.Rows[e.RowIndex].Cells[5].Value);
            item.Notes = inout.Rows[e.RowIndex].Cells[6].Value!=null? inout.Rows[e.RowIndex].Cells[6].Value.ToString():"";
         //   item.Money.Id = moneyId;
            item.IsIncome = fl;
      
            if (fl)
            {
         //       item.Money.Total += item.Price;
                
            }
            else 
            {
             //   item.Money.Total -= item.Price;
            }



            var mon=context.DaystaticMoney.Where(c => c.Id == moneyId).FirstOrDefault();
            if (mon.IncomeOutCome == null)
                mon.IncomeOutCome = new List<IncomeOutcome>();
                mon.IncomeOutCome.Add(item);
            context.IncomeOutcome.Add(item);
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

        private void inout_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          //  var an = MessageBox.Show("هل تريد حفظ هذه البيانات","",MessageBoxButtons.YesNo);
            //if (an == DialogResult.Yes) 
            if(e.ColumnIndex==1||e.ColumnIndex==2) 
            {
                if(e.ColumnIndex==2) 
                {
                    inout.Rows[e.RowIndex].ReadOnly= false;
                   
                }   
                else 
                {
                  var ans= MessageBox.Show("هل انت متأكد","",MessageBoxButtons.YesNo);
                    if(ans == DialogResult.Yes) 
                    {
                        AppDbContext context = new AppDbContext();
                        var item = context.IncomeOutcome.Where(c => c.Money.Id == moneyId && c.Name == inout.Rows[e.RowIndex].Cells[3].Value.ToString()).FirstOrDefault();
                        if(item != null) 
                        {
                            if (fl) item.Money.Total -= item.Price;
                            else item.Money.Total += item.Price;
                            context.IncomeOutcome.Remove(item);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
