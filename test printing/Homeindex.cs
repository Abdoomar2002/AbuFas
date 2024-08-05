using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace test_printing
{
    public partial class Home : Form
    {
        private Bitmap _backBuffer;
        private Dictionary<string, DateTime> FromDate = new Dictionary<string, DateTime>();
        private Dictionary<string, DateTime> ToDate = new Dictionary<string, DateTime>();
        private Dictionary<string, string> SearchKey = new Dictionary<string, string>();
        private DateTime currentDate= DateTime.Today;
        private DateTime currentDate2= DateTime.Today;
        private bool activeSearch=false;
        private string ActivePage="bills";
        private static bool isDateChangingProgrammatically= false;
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
            search.TextChanged += search_TextChange;
            start.CloseUp += start_LostFocus;
            start.ValueChanged += end_valueChanged;
            end.ValueChanged += end_valueChanged;
            end.CloseUp += start_LostFocus;
            right.Width = 300;
            _backBuffer = new Bitmap(ClientSize.Width, ClientSize.Height);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            search.Visible = false;
            from.Visible = false;
            to.Visible = false;
            start.Visible = false;
            end.Visible = false;
            searchButton.Visible = false;
            day.Visible = false;
            isDateChangingProgrammatically = true;
            start.Value = DateTime.Now;
            end.Value = DateTime.Now;
            start.MaxDate=DateTime.Now;
            end.MaxDate=DateTime.Now;
            isDateChangingProgrammatically = false;
            //label1.Visible=false;

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
        private void end_valueChanged(object sender,EventArgs e)
        {
            activeSearch=false;
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
            searchButton.Visible = true;
            end.Visible = true;
            day.Visible = false;
            ActivePage = "Grams";
            handelSearch();


        }
        private void handelSearch()
        {
            if (FromDate.ContainsKey(ActivePage))
            {
                isDateChangingProgrammatically = true;
                start.Value = FromDate[ActivePage] != null ? FromDate[ActivePage] : DateTime.Now;
                end.Value = ToDate[ActivePage] != null ? ToDate[ActivePage] : DateTime.Now;
                search.Text = SearchKey[ActivePage] ?? "";
                isDateChangingProgrammatically = false;
            }
            else
            {
               
                
              
                isDateChangingProgrammatically = true;
                start.Value = DateTime.Today;
                end.Value = DateTime.Today;
                search.Text = "";
                FromDate[ActivePage] = start.Value;
                ToDate[ActivePage] = end.Value;
                SearchKey[ActivePage] = search.Text;
                isDateChangingProgrammatically = false;
            }
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
            searchButton.Visible = false;
            end.Visible = false;
            day.Visible = false;
            ActivePage = "bills";
            handelSearch();


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
            searchButton.Visible = true;
            end.Visible = false;
            day.Visible = true;
            ActivePage = "Day";
            handelSearch();



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
        public void search_TextChange(object sender, EventArgs e)
        {
            activeSearch = true;
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
            searchButton.Visible = true;
            end.Visible = true;
            day.Visible = false;
            ActivePage = "Borrow";
            handelSearch();

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
            searchButton.Visible = true;
            end.Visible = false;
            day.Visible = false;
            ActivePage = "Customer";
            handelSearch();

        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar ==Keys.Enter) 
            {
                searchExecute();
            }
        }
        private void searchExecute()
        {
            switch (ActivePage)
            {
                case "bills": { archive1.SearchByName(search.Text); break; }
                case "Borrow": { borrow1.SearchName(search.Text); break; }
                case "Customer": { customers1.SearchByName(search.Text); break; }
                default: { break; }
            }
        }
        private void start_ValueChanged(object sender, EventArgs e)
        {
            if (!isDateChangingProgrammatically)
            {
                Guna2DateTimePicker picker = (Guna2DateTimePicker)sender;
                isDateChangingProgrammatically = true;
                FromDate[ActivePage] = start.Value;
                ToDate[ActivePage] = end.Value;
                SearchKey[ActivePage] = search.Text;
                isDateChangingProgrammatically = false;
                currentDate = start.Value;
                currentDate2= end.Value;    
                switch (ActivePage)
                {
                    case "bills": { archive1.SearchByDate(start.Value.Date, end.Value.Date); break; }
                    case "Grams": { gramsCount.SearchByDate(start.Value.Date, end.Value.Date); break; }
                    case "Day": { dayStatic1.load(start.Value.Date); break; }
                    case "Borrow": { borrow1.SearchDate(start.Value.Date, end.Value.Date); break; }
                    case "inventor": { inventory1.load(start.Value.Date, end.Value.Date); break; }

                    default: { break; }

                }
            }

        }
        private void start_LostFocus(object sender,EventArgs e)
        {
            if (start.Value == FromDate[ActivePage] && end.Value == ToDate[ActivePage])
            {
                start_ValueChanged(null, null);
            }
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            inventory1.BringToFront();
            inventory1.load(start.Value,end.Value);
            Guna2Button btn = (Guna2Button)sender;
            colorChange(btn.Name);
            search.Visible = true;
            from.Visible = true;
            to.Visible = true;
            start.Visible = true;
            searchButton.Visible = true;
            end.Visible = true;
            day.Visible = false;
            ActivePage = "inventor";
            handelSearch();

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (activeSearch) searchExecute();
            else
            start_ValueChanged(null,null);
        }
    }
}
