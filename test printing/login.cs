using System;
using System.Windows.Forms;
using test_printing;


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
                AppDbContext context = new AppDbContext();
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            if (guna2TextBox2.Text == "123") {
              //  context.Database.OpenConnection();
           
                new Home().Show();
                this.Hide();
            }
            else 
            {

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
    }
}
