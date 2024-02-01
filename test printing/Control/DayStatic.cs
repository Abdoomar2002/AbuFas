using Microsoft.EntityFrameworkCore;
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
        public  AppDbContext context;
        public DayStatic()
        {
            InitializeComponent();
        }
        public DayStatic(DbContextOptions<AppDbContext> options)
        {
            context = new AppDbContext(options);
        }
        private void label15_Click(object sender, EventArgs e)
        {
            AppDbContext context = new AppDbContext();
            var money = context.DaystaticMoney.Where(x => x.Date == DateTime.Parse(cuurentDate.Text)).FirstOrDefault();
            if (money == null)
            {
                money = new DaystaticMoney();
                var lastMoney = context.DaystaticMoney.OrderByDescending(x => x.Id).FirstOrDefault();
                money.Id = lastMoney != null ? lastMoney.Id + 1 : 1;
                money.Date = DateTime.Parse(cuurentDate.Text);
                context.DaystaticMoney.Add(money);
                context.SaveChanges();
            }
            Label label = (Label)sender;
            colorChange(label);
            if (label == label12 || label == label9)
            {
                bills211.Visible = true;
                inOutCome1.Visible = false;
                bills211.Title.Text = label.Text;
                fl = label == label12 ? true : false;
                bills211.load(money.Id, fl);

            }
            else if (label == label15 || label18 == label)
            {
                inOutCome1.Visible = true;
                fl1 = label == label15 ? true : false;
                inOutCome1.Load(money.Id, fl1);
                bills211.Visible = false;
                inOutCome1.Title.Text = label.Text;
            }


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
            cuurentDate.Text = DateTime.Today.ToShortDateString();

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
            var item = context.DaystaticMoney.OrderBy(x => x.Date).FirstOrDefault();
            DateTime date = DateTime.Parse(cuurentDate.Text);
            if (item == null || date == item.Date)
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
            buy21.Text = "";
            incomemoney.Text = "";
            sell21.Text = "";
            outcomemoney.Text = "";
            yesterdaytotal.Text = "";
            todaytotal.Text = "";
            AppDbContext context = new AppDbContext();



            var days = context.DaystaticMoney.AsEnumerable().Where(x => x.Date == date).FirstOrDefault();
            double totalIncome = 0, totalOutcome = 0;
            double totalbuy = 0, totalsell = 0;
            double yesterday = 0;
            double today = 0;
            if (days != null)

            {
                var inout = context.IncomeOutcome.Where(c => c.Money.Id == days.Id).ToList();
                if (inout.Count > 0)
                    foreach (var inco in days.IncomeOutCome)
                    {
                        if (inco.IsIncome) { totalIncome += inco.Price; }
                        else { totalOutcome += inco.Price; }

                    }
                var bills = context.Bills.Where(c => c.Money.Id == days.Id).ToList();
                if (days.Bills != null)
                    foreach (var inco in days.Bills)
                    {
                        if (inco.IsBuy) totalsell += inco.Total;
                        else totalbuy += inco.Total;
                    }
                incomemoney.Text = totalIncome.ToString();
                outcomemoney.Text = totalOutcome.ToString();
                buy21.Text = totalbuy.ToString();
                sell21.Text = totalsell.ToString();
                double yesterdayMoney = Total(days.Date);
                yesterdaytotal.Text =yesterdayMoney.ToString() ;
                days.Total=totalbuy+totalIncome-totalsell-totalOutcome;
                todaytotal.Text = (days.Total +yesterdayMoney).ToString();
                inOutCome1.Load(days.Id, fl1);
                bills211.load(days.Id, fl);

            }

        }
        public double Total(DateTime time) 
        {
            double total=0;
            context=new AppDbContext();
            var list=context.DaystaticMoney.Where(d=>d.Date < time).OrderByDescending(x=>x.Date).ToList();
            foreach (var item in list)
            {
                foreach (var element in item.Bills)
                {
                    if(element.IsBuy)total-=element.Total;
                    else total+=element.Total;
                }
                foreach (var element in item.IncomeOutCome)
                {
                    if (element.IsIncome)  total += element.Price;
                    else total-=element.Price;
                }
            }
            return total;
        }

    }
}
