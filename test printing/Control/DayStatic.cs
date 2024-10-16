﻿using Microsoft.EntityFrameworkCore;
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
      static  bool fl, fl1;
        
        public DayStatic()
        {
            InitializeComponent();
            Program._context = new AppDbContext();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            
            var money = Program._context.DaystaticMoney.Where(x => x.Date == DateTime.Parse(cuurentDate.Text)).FirstOrDefault();
            if (money == null)
            {
                money = new DaystaticMoney();
                var lastMoney = Program._context.DaystaticMoney.OrderByDescending(x => x.Id).FirstOrDefault();
                money.Id = lastMoney != null ? lastMoney.Id + 1 : 1;
                money.Date = DateTime.Parse(cuurentDate.Text);
                Program._context.DaystaticMoney.Add(money);
                Program._context.SaveChanges();
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
                inOutCome1.inout.Rows.Clear();
                inOutCome1.loadOtherSide(money.Id, fl1);
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

           //  load(DateTime.Today);
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
            
            var item = Program._context.DaystaticMoney.OrderBy(x => x.Date).FirstOrDefault();
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

          //  MessageBox.Show("fg");


            var days = Program._context.DaystaticMoney.AsEnumerable().Where(x => x.Date == date).FirstOrDefault();
            double totalIncome = 0, totalOutcome = 0;
            double totalbuy = 0, totalsell = 0;
            double yesterday = 0;
            double today = 0;
            if (days != null)

            {
                var inout = Program._context.IncomeOutcome.Where(c => c.Money.Id == days.Id).ToList();
                if (inout.Count > 0)
                    foreach (var inco in days.IncomeOutCome)
                    {
                        if (inco.IsIncome) { totalIncome += inco.Price; }
                        else { totalOutcome += inco.Price; }

                    }
                var bills = Program._context.Bills.Where(c => c.Money.Id == days.Id).ToList();
                if (days.Bills != null)
                    foreach (var inco in bills)
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
               // inOutCome1.Load(days.Id, fl1);
                bills211.load(days.Id, fl);

            }

        }
        public double Total(DateTime time) 
        {
            double total=0;
            
            var list=Program._context.DaystaticMoney.Where(d=>d.Date < time).OrderByDescending(x=>x.Date).ToList();
            foreach (var item in list)
            { 
                var bills =Program._context.Bills.Where(b=>b.Money==item).ToList();
                foreach (var element in bills)
                {
                    if(element.IsBuy)total-=element.Total;
                    else total+=element.Total;
                }
                var incoumeoutcome=Program._context.IncomeOutcome.Where(i=>i.Money==item).ToList();
                foreach (var element in incoumeoutcome)
                {
                    if (element.IsIncome)  total += element.Price;
                    else total-=element.Price;
                }
            }
            return total;
        }
        private double calcYesterday(DateTime time) 
        {
            double total=0;
            time = time.AddDays(-1).Date;
            var day = Program._context.DaystaticMoney.Where(c => c.Date == time).FirstOrDefault();
            if(day != null) {
                var bills = Program._context.Bills.Where(b => b.Money == day).ToList();
                foreach (var item in bills)
                {
                    if(item.IsBuy) total-=item.Total;
                    else total+=item.Total;
                }
                var incomeoutcome=Program._context.IncomeOutcome.Where(i=>i.Money==day).ToList();
                foreach (var item in incomeoutcome)
                {
                    if(item.IsIncome) total+=item.Price;
                    else total-=item.Price;
                }
            }
            return total;
        }
    }
}
