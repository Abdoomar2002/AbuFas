using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace test_printing
{
    public partial class Home : Form
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
        public Home()
        {
            InitializeComponent();
            date.Text = DateTime.Today.ToShortDateString();
            firstPage1.BringToFront();
            
        }

        private void Print_Click(object sender, EventArgs e)
        {
           // bill1.btn_print(bill1.Width,bill1.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2Panel2.FillColor = Color.FromArgb(180, 0, 0,0);
            guna2Panel1.FillColor = Color.FromArgb(180, 0, 0,0);
            AppDbContext context = new AppDbContext();
            //context.Database.OpenConnection();
            context.Database.EnsureCreated();
           
           
         //   SQLitePCL.ISQLite3Provider provider = new SQLitePCL.ISQLite3Provider();
         
          
          //  MessageBox.Show(context.Bills.ToList().ToString());
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Grambtn_Click(object sender, EventArgs e)
        {
            gramsCount.BringToFront();
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);


        }

        private void billsbtn_Click(object sender, EventArgs e)
        {
            firstPage1.BringToFront();
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
        }

        private void btntStatic_Click(object sender, EventArgs e)
        {
            dayStatic1.BringToFront();
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
           
        }
        private void colorChange(string name) 
        {
            Guna2Button []btns = { btnPayment, btnShopper, billsbtn, Grambtn, btntStatic };
            foreach(Guna2Button btn in  btns) 
            {
                if(btn.Name == name)
                {
                    btn.FillColor = Color.FromArgb(255, 212, 175, 55);
                    
                }else btn.FillColor = Color.FromArgb(0, 212, 175, 55);
            }
        }

        private void firstPage1_Load(object sender, EventArgs e)
        {

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            borrow1.BringToFront();
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
        }

        private void btnShopper_Click(object sender, EventArgs e)
        {
            customers1.BringToFront();
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
        }
    }
}
