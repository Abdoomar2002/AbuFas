using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace test_printing
{
    public partial class Home : Form
    {
        private Bitmap _backBuffer;
        private string ActivePage="bills";
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
            right.Width = 300;
            _backBuffer = new Bitmap(ClientSize.Width, ClientSize.Height);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            search.Visible = false;
            from.Visible = false;
            to.Visible = false;
            start.Visible = false;
            end.Visible = false;
            day.Visible = false;
            start.MaxDate=DateTime.Now;
            end.MaxDate=DateTime.Now;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw your graphics onto the back buffer using its Graphics object
            using (Graphics g = Graphics.FromImage(_backBuffer))
            {
                // Your drawing code here (using g)
            }

            // Blit (transfer) the back buffer onto the form's graphics object
            e.Graphics.DrawImage(_backBuffer, Point.Empty);
        }
        private void Print_Click(object sender, EventArgs e)
        {
           // bill1.btn_print(bill1.Width,bill1.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            right.FillColor = Color.FromArgb(180, 0, 0,0);
            top.FillColor = Color.FromArgb(180, 0, 0,0);
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
            gramsCount.GramsCount_Load(null, null);
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
            search.Visible = false;
            from.Visible = true;
            to.Visible = true;
            start.Visible = true;
            end.Visible = true;
            day.Visible = false;
            ActivePage = "Grams";


        }

        private void billsbtn_Click(object sender, EventArgs e)
        {
            firstPage1.BringToFront();
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
            search.Visible = false;
            from.Visible = false;
            to.Visible = false;
            start.Visible = false;
            end.Visible = false;
            day.Visible = false;
            ActivePage = "bills";
        }

        private void btntStatic_Click(object sender, EventArgs e)
        {
            dayStatic1.BringToFront();
            dayStatic1.load(DateTime.Today.Date);
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
            search.Visible = false;
            from.Visible = false;
            to.Visible = false;
            start.Visible = true;
            end.Visible = false;
            day.Visible = true;
            ActivePage = "Day";

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
            borrow1.load();
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
            search.Visible = true;
            from.Visible = true;
            to.Visible = true;
            start.Visible = true;
            end.Visible = true;
            day.Visible = false;
            ActivePage = "Borrow";
        }

        private void btnShopper_Click(object sender, EventArgs e)
        {
            customers1.BringToFront();
            customers1.load();
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
            search.Visible = true;
            from.Visible = false;
            to.Visible = false;
            start.Visible = false;
            end.Visible = false;
            day.Visible = false;
            ActivePage = "Customer";
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar ==Keys.Enter) 
            {
                switch (ActivePage) 
                {
                    case "bills": { archive1.SearchByName(search.Text); break; }
                    case "Borrow": { borrow1.SearchName(search.Text); break; }
                    case "Customer": { customers1.SearchByName( search.Text); break; }
                    default: { break; }
                }
            }
        }

        private void start_ValueChanged(object sender, EventArgs e)
        {
            Guna2DateTimePicker picker=(Guna2DateTimePicker)sender;
            switch(ActivePage) 
            {
                case "bills": { archive1.SearchByDate(start.Value.Date, end.Value.Date); break; }
                case "Grams": { gramsCount.SearchByDate(start.Value.Date, end.Value.Date); break; }
                case "Day": { dayStatic1.load(start.Value.Date); break; }
                case "Borrow": { borrow1.SearchDate(start.Value.Date, end.Value.Date); break; }
                case "inventor": { inventory1.load(start.Value.Date, end.Value.Date); break; }

                default: { break; }

            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            inventory1.BringToFront();
            inventory1.load(DateTime.Today,DateTime.Today);
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
            search.Visible = false;
            from.Visible = true;
            to.Visible = true;
            start.Visible = true;
            end.Visible = true;
            day.Visible = false;
            ActivePage = "inventor";
        }
    }
}
