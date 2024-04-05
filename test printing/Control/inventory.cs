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

namespace AbuFas.Control
{
    public partial class inventory : UserControl
    {
        public inventory()
        {
            InitializeComponent();
            start.MaxDate=DateTime.Now;
            end.MaxDate=DateTime.Now;
            
        }
        public void load(DateTime startDate,DateTime endDate) 
        {
            var TotalBuy = Program._context.Bills.Where(c => c.IsBuy == false&&c.Date>=startDate&&c.Date<=endDate).Sum(c => c.Total);
            var TotalSold = Program._context.Bills.Where(c => c.IsBuy == true && c.Date >= startDate && c.Date <= endDate).Sum(c => c.Total);
            var TotalBuy21 =Program._context.BillData.Where(c => c.Kyrat == 21 && c.Bill.Date >= startDate && c.Bill.Date <= endDate &&c.Bill.IsBuy).Sum(c => c.Weight);
            var TotalBuy18 =Program._context.BillData.Where(c => c.Kyrat == 18 && c.Bill.Date >= startDate && c.Bill.Date <= endDate && c.Bill.IsBuy).Sum(c => c.Weight);
            var TotalBuy24 =Program._context.BillData.Where(c => c.Kyrat == 24 && c.Bill.Date >= startDate && c.Bill.Date <= endDate && c.Bill.IsBuy).Sum(c => c.Weight);
            var TotalSell21 = Program._context.BillData.Where(c => c.Kyrat == 21 && c.Bill.Date >= startDate && c.Bill.Date <= endDate && !c.Bill.IsBuy).Sum(c => c.Weight);
            var TotalSell18 = Program._context.BillData.Where(c => c.Kyrat == 18 && c.Bill.Date >= startDate && c.Bill.Date <= endDate && !c.Bill.IsBuy).Sum(c => c.Weight);
            var TotalSell24 = Program._context.BillData.Where(c => c.Kyrat == 24 && c.Bill.Date >= startDate && c.Bill.Date <= endDate && !c.Bill.IsBuy).Sum(c => c.Weight);
            var income = Program._context.IncomeOutcome.Where(c => c.Date >= startDate && c.Date <= endDate&&c.IsIncome).Sum(c => c.Price);
            var outcome = Program._context.IncomeOutcome.Where(c => c.Date >= startDate && c.Date <= endDate&&!c.IsIncome).Sum(c => c.Price);
          
            //sell
            sell.Text=TotalSold.ToString();
            sell18.Text=TotalSell18.ToString();
            sell21.Text=TotalSell21.ToString();
            sell24.Text=TotalSell24.ToString();

            //buy
            buy.Text = TotalBuy.ToString();
            buy18.Text=TotalBuy18.ToString();
            buy21.Text=TotalBuy21.ToString();
            buy24.Text=TotalBuy24.ToString();

            //incoume outcome
            inc.Text=income.ToString();
            outc.Text=outcome.ToString();

        }

        private void inventory_Load(object sendDateer, EventArgs e)
        {
            Home home = (Home)ParentForm;

            load(home.start.Value,home.end.Value);
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            
            var items=Program._context.IncomeOutcome.Where(c=>c.Name==search.Text&&c.Date>=start.Value&&c.Date<=end.Value).Sum(c=>c.Price);
            if (items != null)
            {
                result.Text = items.ToString();
            }
            else result.Text = "0";
        }


    }
}
