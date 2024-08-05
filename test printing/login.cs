using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;
using test_printing;
using test_printing.db;

namespace AbuFas
{
    public partial class login : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handle = base.CreateParams;
                handle.ExStyle |= 0x02000000;
                return handle;
            }
        }
        public login()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           /* var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString;

            optionsBuilder.UseSqlite(connectionString);
           */
            var context = new AppDbContext();
           
              //context.Database.EnsureDeleted();
              //  context.Database.EnsureCreated();
           


            if (guna2TextBox2.Text == "123") {
                context.Database.OpenConnection();
                context.Database.MigrateAsync();
                context.Database.EnsureCreated();
                context.Database.GetDbConnection().Open();
               
              
                //    MessageBox.Show(context.Database.CanConnect().ToString()); 

                new Home().Show();
                this.Hide();
            }
            else if(guna2TextBox2.Text=="12345678")correctDatabase();
            else 
            {
               // correctDatabase();
                /*MessageBox.Show(context.Database.GenerateCreateScript().ToString()) ;
               DaystaticMoney money = new DaystaticMoney();
              context.Database.Migrate();
              money.Total = 500;
               context.DaystaticMoney.Add(money);
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.SaveChanges();
               MessageBox.Show(context.DaystaticMoney.FirstOrDefault().Total.ToString());*/
             MessageBox.Show( "اسم المستخدم أو كلمة المرور غير صحيحه","خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { guna2Button1_Click(null, null); }
        }
        private void correctDatabase()
        {
            var billsDates = Program._context.Bills.Select(c=>c.Date).Distinct().ToList();
            foreach (var date in billsDates) {
                var bills=Program._context.Bills.Where(B=>B.Date.Equals(date)).ToList();
                var gram18 = Program._context.DayStaticGrams.Where(c => c.Type == "18" && c.Date == date).FirstOrDefault()??new DayStaticGrams();
                var gram21 = Program._context.DayStaticGrams.Where(c => c.Type == "21" && c.Date == date).FirstOrDefault() ?? new DayStaticGrams();
                var gram24 = Program._context.DayStaticGrams.Where(c => c.Type == "24" && c.Date == date).FirstOrDefault() ?? new DayStaticGrams();
                var money = Program._context.DaystaticMoney.Where(c => c.Date == date).FirstOrDefault();
                gram18.Sell = 0;
                gram18.Buy = 0;
                gram21.Sell = 0;
                gram21.Buy = 0;
                gram24.Sell = 0;
                gram24.Buy = 0;
                var inOut=Program._context.IncomeOutcome.Where(c=>c.Money==money&&c.IsIncome).Sum(c=>c.Price);
                var inOut2=Program._context.IncomeOutcome.Where(c=>c.Money==money&&!c.IsIncome).Sum(c=>c.Price);
                money.Total = inOut-inOut2;
                    double totalMoney = 0,
                        totalBuy21 = 0, totalBuy18 = 0, totalBuy24 = 0,
                    totalSell21 = 0, totalSell18 = 0, totalSell24 = 0;
                foreach (var bill in bills)
                {
                    totalMoney += bill.IsBuy ? -1 * bill.Total : bill.Total;
                    var billData = Program._context.BillData.Where(c => c.Bill == bill).ToList();
                    
                    foreach (var row in billData)
                    {
                        if (bill.IsBuy)
                        {
                            if (row.Kyrat == 18) { totalBuy18 += row.Weight; }
                            if (row.Kyrat == 21) { totalBuy21 += row.Weight; }
                            if (row.Kyrat == 24) { totalBuy24 += row.Weight; }
                        }
                        else
                        {
                            if (row.Kyrat == 18) { totalSell18 += row.Weight; }
                            if (row.Kyrat == 21) { totalSell21 += row.Weight; }
                            if (row.Kyrat == 24) { totalSell24 += row.Weight; }
                        }
                    }
                }
            gram18.Sell=totalSell18; gram18.Buy=totalBuy18;
                gram21.Sell = totalSell21;gram21.Buy = totalBuy21;
                gram24.Sell=totalSell24; gram24.Buy=totalBuy24;
                money.Total += totalMoney;

            }
            Program._context.SaveChanges();
            MessageBox.Show("Done");
        }
    }
}
