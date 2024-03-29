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
            
        }
        public void load(DateTime start,DateTime end) 
        {
            var TotalBuy = Program._context.Bills.Where(c => c.IsBuy == true&&c.Date>=start&&c.Date<=end).Sum(c => c.Total);
            var TotalSold = Program._context.Bills.Where(c => c.IsBuy == false && c.Date >= start && c.Date <= end).Sum(c => c.Total);
            var Total21 =Program._context.BillData.Where(c => c.Kyrat == 21 && c.Bill.Date >= start && c.Bill.Date <= end).Sum(c => c.Weight);
            var Total18 =Program._context.BillData.Where(c => c.Kyrat == 18 && c.Bill.Date >= start && c.Bill.Date <= end).Sum(c => c.Weight);
            var Total24 =Program._context.BillData.Where(c => c.Kyrat == 24 && c.Bill.Date >= start && c.Bill.Date <= end).Sum(c => c.Weight);
            T18.Text=Total18.ToString();
            T21.Text=Total21.ToString();
            T24.Text=Total24.ToString();
            invBuy.Text = TotalBuy.ToString();
            invSell.Text = TotalSold.ToString();
        }

        private void inventory_Load(object sender, EventArgs e)
        {
            load(DateTime.Today,DateTime.Today);
        }
    }
}
