using Guna.UI2.AnimatorNS;
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
        public int index = 0;
        public bool fla=false;
        public InOutCome()
        {
            InitializeComponent();
            this.Visible = false;


            inout.Rows[0].Cells[0].Value = 1;
            inout.Rows[0].Cells[1].Value = Properties.Resources.icon;
            inout.Rows[0].Cells[2].Value = Properties.Resources.icon_1;
            inout.Rows[0].Height = 40;
            ID.Visible = false;

            //dataGridViewImageColumn1.Image = Properties.Resources.icon;

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void guna2DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            inout.Rows[e.RowIndex].Cells[0].Value ="";
            inout.Rows[e.RowIndex].Cells[5].Value = 0;
            inout.Rows[e.RowIndex].Cells[1].Value = Properties.Resources.icon;
            inout.Rows[e.RowIndex].Cells[2].Value = Properties.Resources.icon_1;
            inout.Rows[e.RowIndex].Cells[4].Value = dateTime.ToShortDateString();
            
        }
        public void Load(int id, bool flag)
        {
          /*  if (!fla)
            {
                inout.Rows.Clear();
                fla = false;
            }fla = false;*/
            inout.Rows[0].Cells[4].Value = dateTime.ToShortDateString();

            
            var items = Program._context.IncomeOutcome.Where(c=>c.Money.Id==id&&c.IsIncome==flag).ToList();
            moneyId = id;
            fl = flag;
            if (items.Count <= 0) return;
            inout.RowCount = items.Count + 1;
            if (items.Count > 0)
            {
                int i = 0;
                foreach (var item in items)
                {
                    
                    inout.Rows[i].Cells[3].Value = item.Name;
                    inout.Rows[i].Cells[0].Value = i+1;
                    inout.Rows[i].Cells[4].Value = dateTime.ToShortDateString();
                    inout.Rows[i].Cells[5].Value = item.Price;
                    inout.Rows[i].Cells[6].Value = item.Notes;
                  //  inout.Rows[i].ReadOnly =(fla==true&&(i+1)==items.Count)? false:true;
                    inout.Rows[i].Cells[7].Value=item.Id.ToString();
                    i++;
                }
                index = items.Count + 1;
            }

        }

        private void inout_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            
            var item = inout.CurrentRow.Cells[7].Value != null ? Program._context.IncomeOutcome.Where(x => x.Id == Int32.Parse(inout.CurrentRow.Cells[7].Value.ToString())).FirstOrDefault():new IncomeOutcome() ;
            if (e.ColumnIndex > 2)
                if (inout.Rows[e.RowIndex].Cells[3].Value == null || (inout.Rows[e.RowIndex].Cells[5].Value == null)) { MessageBox.Show("من فضلك ادخل البيانات كامله"); return; }
            item.Name = inout.Rows[e.RowIndex].Cells[3].Value.ToString();
            item.Date = dateTime.Date;
            item.Price = (double)TryParseDouble(inout.Rows[e.RowIndex].Cells[5].Value);
            item.Notes = inout.Rows[e.RowIndex].Cells[6].Value != null ? inout.Rows[e.RowIndex].Cells[6].Value.ToString() : "";
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



            var mon = Program._context.DaystaticMoney.Where(c => c.Id == moneyId).FirstOrDefault();
            if (mon.IncomeOutCome == null)
                mon.IncomeOutCome = new List<IncomeOutcome>();
            if (item.Id == 0)
            {
                mon.IncomeOutCome.Add(item);
                Program._context.IncomeOutcome.Add(item);
            }
            Program._context.SaveChanges();
            fla = true;
            Load(moneyId, fl);

            Home home = (Home)this.ParentForm;
            
            home.dayStatic1.load(dateTime);

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
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                if (e.ColumnIndex == 2)
                {
                    inout.Rows[e.RowIndex].ReadOnly = false;

                }
                else
                {
                    var ans = MessageBox.Show("هل انت متأكد", "", MessageBoxButtons.YesNo);
                    if (ans == DialogResult.Yes)
                    {
                        if (e.RowIndex == inout.RowCount - 1) { MessageBox.Show("لا يوجد صف لمسحه"); return; }
                      
                        var item = Program._context.IncomeOutcome.Where(c => c.Money.Id == moneyId && c.Name == inout.Rows[e.RowIndex].Cells[3].Value.ToString()).FirstOrDefault();
                        var Moneyitem = Program._context.DaystaticMoney.Where(c => c.Id == moneyId).FirstOrDefault();
                        if (item != null)
                        {
                            if (fl) Moneyitem.Total -= item.Price;
                            else item.Money.Total += item.Price;
                            Program._context.IncomeOutcome.Remove(item);
                            Program._context.SaveChanges();
                            Load(moneyId, fl);
                            Home home = (Home)this.ParentForm;
                            
                            home.dayStatic1.load(dateTime);
                        }
                    }
                }
            }
        }
        public void loadOtherSide(int id,bool flag) {
              if (!flag)
           {
               inout.Rows.Clear();
               fla = false;
           }fla = false;
            inout.Rows[0].Cells[4].Value = dateTime.ToShortDateString();


            var items = Program._context.IncomeOutcome.Where(c => c.Money.Id == id && c.IsIncome == flag).ToList();
            moneyId = id;
            fl = flag;
            if (items.Count <= 0) return;
            inout.RowCount = items.Count + 1;
            if (items.Count > 0)
            {
                int i = 0;
                foreach (var item in items)
                {

                    inout.Rows[i].Cells[3].Value = item.Name;
                    inout.Rows[i].Cells[0].Value = i + 1;
                    inout.Rows[i].Cells[4].Value = dateTime.ToShortDateString();
                    inout.Rows[i].Cells[5].Value = item.Price;
                    inout.Rows[i].Cells[6].Value = item.Notes;
                    //  inout.Rows[i].ReadOnly =(fla==true&&(i+1)==items.Count)? false:true;
                    inout.Rows[i].Cells[7].Value = item.Id.ToString();
                    i++;
                }
                index = items.Count + 1;
            }

        }
        private void inout_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
