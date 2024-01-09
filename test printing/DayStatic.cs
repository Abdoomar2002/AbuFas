using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using test_printing;
using test_printing.db;

namespace AbuFas
{
    public partial class DayStatic : UserControl
    {
        bool fl, fl1;
        public DayStatic()
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            AppDbContext context = new AppDbContext();
            var money = context.DaystaticMoney.Where(x => x.Date == DateTime.Parse(cuurentDate.Text)).FirstOrDefault();
            if (money == null)
            {
                money = new test_printing.db.DaystaticMoney();
                money.Id = context.DaystaticMoney.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
                money.Date = DateTime.Parse(cuurentDate.Text);
                context.DaystaticMoney.Add(money);
                context.SaveChanges();
            }
            Label label=(Label)sender;
            colorChange(label);
            if (label == label12 || label == label9)
            {
                bills211.Visible = true;
                inOutCome1.Visible = false;
                bills211.Title.Text = label.Text;
                 fl = label == label12?true:false;
                bills211.load(money.Id, fl);
                
            }
            else if (label == label15 || label18 == label) 
            { 
                inOutCome1.Visible = true;
                 fl1=label==label15?true:false;
                inOutCome1.Load(money.Id,fl1);
                bills211.Visible = false;
                inOutCome1.Title.Text = label.Text; }


            else { bills211.Visible = false; inOutCome1.Visible = false; }

        }

        private void label15_Leave(object sender, EventArgs e)
        {
           
           
        }
        private void colorChange(Label label) 
        {
            Label[] labels = { label9, label12, label15, label18 };
            foreach (Label lbl in labels)
            {
                if (label.Text != lbl.Text)
                {
                    lbl.BackColor = Color.FromArgb(255, 255, 255, 255);
                    lbl.ForeColor = Color.Black;
                }
                else
                {
                    lbl.BackColor = Color.FromArgb(255, 212, 175, 55);
                    lbl.ForeColor = Color.White;
                }
            }
        }

        private void DayStatic_Load(object sender, EventArgs e)
        {
            cuurentDate.Text=DateTime.Today.ToShortDateString();
           
            load(DateTime.Today);
        }

        private void next_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(cuurentDate.Text);
            if (date == DateTime.Today) 
            {
                MessageBox.Show("لا يوجد ايام اخري");
            }
            else 
            {
                load(date.AddDays(1));
            }
        }
        private void prev_Click(object sender, EventArgs e)
        {
            AppDbContext context = new AppDbContext();
            var item =context.DaystaticMoney.OrderBy(x => x.Date).FirstOrDefault();
            DateTime date=DateTime.Parse(cuurentDate.Text);
            if (date == item.Date)
            {
                MessageBox.Show("لا يوجد ايام اخري");
            }
            else
            {
                load(date.AddDays(-1));
            }
        }
        public void load(DateTime date)
        {
            cuurentDate.Text = date.ToShortDateString();
            inOutCome1.dateTime = date;
            AppDbContext context = new AppDbContext();
            var days = context.DaystaticMoney.AsEnumerable().Where(x => x.Date == date).FirstOrDefault();
            double totalIncome = 0, totalOutcome = 0;
            double totalbuy = 0, totalsell = 0;
            double yesterday = 0;
            double today = 0;
            if (days != null)

            {
                if (days.IncomeOutCome != null)
                    foreach (var inco in days.IncomeOutCome)
                    {
                        if (inco.IsIncome) { totalIncome += inco.Price; }
                        else { totalOutcome += inco.Price; }

                    }
                if (days.Bills != null)
                    foreach (var inco in days.Bills)
                    {
                        if (!inco.IsBuy) totalsell += inco.Total;
                        else totalbuy += inco.Total;
                    }
                incomemoney.Text = totalIncome.ToString();
                outcomemoney.Text = totalOutcome.ToString();
                buy21.Text = totalbuy.ToString();
                sell21.Text = totalsell.ToString();
                yesterdaytotal.Text = (yesterday + totalIncome - totalOutcome + totalbuy - totalsell).ToString();
                todaytotal.Text = days.Total.ToString();
                
                inOutCome1.Load(days.Id, fl1);
                bills211.load(days.Id, fl);
                
            }

        }

    }
}
