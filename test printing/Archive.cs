using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_printing.db;

namespace test_printing
{
    public partial class Archive : UserControl
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
        public Archive()
        {
            InitializeComponent();
        }
       public AppDbContext _context = new AppDbContext();
        private void Archive_Load(object sender, EventArgs e)
        {
           
            //LoadTable();
           Single.Visible = false;
            Single.FillColor = Color.FromArgb(128,Color.Black);
            Single.UseTransparentBackground = true;
        }
        private Image ScaleImage(Image image, int width, int height)
        {
            Bitmap scaledImage = new Bitmap(880, 750);
            using (Graphics g = Graphics.FromImage(scaledImage))
            {
                g.DrawImage(image, 0, 0, 880, 750);
                //  scaledImage.SetResolution(100, 100);
            }
            return scaledImage;
        }
        public void LoadTable()
        {   
            AppDbContext context = _context;
            context.Database.OpenConnectionAsync();
            context.Database.MigrateAsync();
            context.Database.EnsureCreatedAsync();
             
            var billList=context.Bills.ToArray();
            ArchiveTable.Controls.Clear();
          

            for (int row = 0; row < Math.Ceiling(billList.Length/4.0); row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (billList.Length == row * 4 + col) break;
                    var b = new bill();
                    var bu = new BillBuy();
                    var arcbill = billList[row * 4 + col].IsBuy ? bu : null;
                    var arcbill2 = !billList[row * 4 + col].IsBuy ? b : null;

                    if (arcbill != null) { 
                        arcbill.CustName.Text = billList[row * 4 + col].CustomerName;
                    arcbill.BillNum.Text = billList[row * 4 + col].Id.ToString();
                    int id = billList[row * 4 + col].Id;
                    var tablelis = context.BillData.Where(c => c.Bill.Id == id);

                    var table = tablelis.ToArray();
                    arcbill.data.RowCount = table.Length;
                    /*    
                     *    for (int i = 0; i < table.Length; i++)
                         {
                             DataGridViewRow obj = arcbill.data.Rows[i];


                             obj.Cells[0].Value = table[i].Price.ToString();
                          //   obj.Cells[1].Value = ((long)table[i].Price).ToString();
                             obj.Cells[1].Value = table[i].Weight.ToString();
                           //  obj.Cells[3].Value = ((int)table[i].Weight).ToString();
                             obj.Cells[2].Value = table[i].Type.ToString();
                             //obj.Cells[5].Value = ((int)table[i].Type).ToString();
                             obj.Cells[3].Value = table[i].Kyrat == 0 ? null : table[i].Kyrat.ToString();
                             obj.Cells[4].Value = table[i].Number.ToString();
                             obj.Cells[5].Value = table[i].Name;


                         }*/
                    Image image = ScaleImage(arcbill.CaptureScreenshot(), 300, 340);
                    // Create a PictureBox
                    Guna2PictureBox pictureBox = new Guna2PictureBox
                    {
                        // Set PictureBox properties as needed
                        SizeMode = PictureBoxSizeMode.StretchImage,

                        Image = image,
                        Dock = DockStyle.Fill,
                        Name = id.ToString(),
                        Cursor = Cursors.Hand,

                        // BorderStyle = BorderStyle.FixedSingle, // Optional: Add a border

                    };
                    pictureBox.Click += PictureBox_Click;

                    // Add PictureBox to the TableLayoutPanel
                    ArchiveTable.Controls.Add(pictureBox, col, row);
                }
                    else
                    {
                        arcbill2.CustName.Text = billList[row * 4 + col].CustomerName;
                        arcbill2.BillNum.Text = billList[row * 4 + col].Id.ToString();
                        int id = billList[row * 4 + col].Id;
                        var tablelis = context.BillData.Where(c => c.Bill.Id == id);

                        var table = tablelis.ToArray();
                        arcbill2.data.RowCount = table.Length;
                        /*    
                         *    for (int i = 0; i < table.Length; i++)
                             {
                                 DataGridViewRow obj = arcbill.data.Rows[i];


                                 obj.Cells[0].Value = table[i].Price.ToString();
                              //   obj.Cells[1].Value = ((long)table[i].Price).ToString();
                                 obj.Cells[1].Value = table[i].Weight.ToString();
                               //  obj.Cells[3].Value = ((int)table[i].Weight).ToString();
                                 obj.Cells[2].Value = table[i].Type.ToString();
                                 //obj.Cells[5].Value = ((int)table[i].Type).ToString();
                                 obj.Cells[3].Value = table[i].Kyrat == 0 ? null : table[i].Kyrat.ToString();
                                 obj.Cells[4].Value = table[i].Number.ToString();
                                 obj.Cells[5].Value = table[i].Name;


                             }*/
                        Image image = ScaleImage(arcbill2.CaptureScreenshot(), 300, 340);
                        // Create a PictureBox
                        Guna2PictureBox pictureBox = new Guna2PictureBox
                        {
                            // Set PictureBox properties as needed
                            SizeMode = PictureBoxSizeMode.StretchImage,

                            Image = image,
                            Dock = DockStyle.Fill,
                            Name = id.ToString(),
                            Cursor = Cursors.Hand,

                            // BorderStyle = BorderStyle.FixedSingle, // Optional: Add a border

                        };
                        pictureBox.Click += PictureBox_Click;

                        // Add PictureBox to the TableLayoutPanel
                        ArchiveTable.Controls.Add(pictureBox, col, row);
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                ArchiveTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 4));
            }

            // Set the space between rows
            for (int i = 0; i < 3; i++)
            {
                ArchiveTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 3));
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Single.Visible = true;
            PictureBox pictureBox=(sender as PictureBox);
            AppDbContext context = _context;
           var bigBill= context.Bills.Where(c => c.Id == Int32.Parse(pictureBox.Name)).FirstOrDefault();
            var billdata = context.BillData.Where(c => c.Bill.Id == bigBill.Id).ToList();
          show(bigBill, billdata);
            Single.BringToFront();

         

           
        }
        public void show( Bills bigBill, List <BillData> billdata) 
        {
            if (bigBill.IsBuy)
            {
                bill1.Visible = false;
                billBuy1.Visible = true;

                billBuy1.CustName.Text = bigBill.CustomerName;
                billBuy1.BillNum.Text = bigBill.Id.ToString();

                var table = billdata.ToArray();
                billBuy1.data.RowCount = table.Length;

                for (int i = 0; i < table.Length; i++)
                {
                    DataGridViewRow obj = billBuy1.data.Rows[i];


                    obj.Cells[0].Value = table[i].Price.ToString();
                    //   obj.Cells[1].Value = ((long)table[i].Price).ToString();
                    obj.Cells[1].Value = table[i].Weight.ToString();
                    //  obj.Cells[3].Value = ((int)table[i].Weight).ToString();
                    obj.Cells[2].Value = table[i].Type.ToString();
                    //obj.Cells[5].Value = ((int)table[i].Type).ToString();
                    obj.Cells[3].Value = table[i].Kyrat == 0 ? null : table[i].Kyrat.ToString();
                    obj.Cells[4].Value = table[i].Number.ToString();
                    obj.Cells[5].Value = table[i].Name;

                    // billBuy1.data.Rows.Add(obj);
                }



            }
            else
            {
                bill1.Visible = true;
                billBuy1.Visible = false;
                bill1.CustName.Text = bigBill.CustomerName;
                bill1.BillNum.Text = bigBill.Id.ToString();
                bill1.Enabled = false;
                var table = billdata.ToArray();
                bill1.data.RowCount = table.Length;
                for (int i = 0; i < table.Length; i++)
                {
                    DataGridViewRow obj = bill1.data.Rows[i];


                    obj.Cells[0].Value = table[i].Price.ToString();
                    //   obj.Cells[1].Value = ((long)table[i].Price).ToString();
                    obj.Cells[1].Value = table[i].Weight.ToString();
                    //  obj.Cells[3].Value = ((int)table[i].Weight).ToString();
                    obj.Cells[2].Value = table[i].Type.ToString();
                    //obj.Cells[5].Value = ((int)table[i].Type).ToString();
                    obj.Cells[3].Value = table[i].Kyrat == 0 ? null : table[i].Kyrat.ToString();
                    obj.Cells[4].Value = table[i].Number.ToString();
                    obj.Cells[5].Value = table[i].Name;

                    // bill1.data.Rows.Add(obj);
                }
                bill1.last.Text = bigBill.Total.ToString();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Single.Visible=false;
            Single.SendToBack();

        }

        private void back_Click(object sender, EventArgs e)
        {
            Home home = (Home)this.ParentForm;
            home.archive1.SendToBack();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (bill1.Visible) bill1.btn_print(200, 300);
            else billBuy1.btn_print(200, 300);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("هل انت متاكد", "", MessageBoxButtons.YesNo);
            if (msg == DialogResult.Yes) 
            {
               var billToDelete= _context.Bills.Where(c => c.Id == Int32.Parse(bill1.BillNum.Text)).FirstOrDefault();
               var dataToDelete= _context.BillData.Where(c => c.Bill.Id == Int32.Parse(bill1.BillNum.Text));
               var MoneyToDelete =   _context.DaystaticMoney.Where(c => c.Date == billToDelete.Date).FirstOrDefault();
               var GramToDelete =   _context.DayStaticGrams.Where(c => c.Date == billToDelete.Date).FirstOrDefault();
                double totalgrams = 0;
                foreach (var d in dataToDelete) 
                {
                    totalgrams += d.Weight;
                }
                if(billToDelete.IsBuy==true)GramToDelete.Buy-=totalgrams;else GramToDelete.Sell-=totalgrams;
                MoneyToDelete.Bills.Remove(billToDelete);
                _context.BillData.RemoveRange(dataToDelete);
                _context.Bills.Remove(billToDelete);
                _context.SaveChanges();
                Single.Visible = false;
                Single.SendToBack();
                LoadTable();
            }
        }

        private void previous_Click(object sender, EventArgs e)
        {
            var bigBill = new Bills();
            if (bill1.Visible == true)
                bigBill = _context.Bills.AsEnumerable().Where(c => c.Id < Int32.Parse(bill1.BillNum.Text)).LastOrDefault();
            else
                bigBill = _context.Bills.Where(c => c.Id < Int32.Parse(billBuy1.BillNum.Text)).FirstOrDefault();
            if (bigBill != null)
            {
                var billData = _context.BillData.Where(c => c.Bill.Id == bigBill.Id).ToList();
                show(bigBill, billData);

            }
            else MessageBox.Show("لا يوجد فواتير اخري ");
        }

        private void next_Click(object sender, EventArgs e)
        {
            var bigBill=new Bills();
            if(bill1.Visible==true) 
                 bigBill = _context.Bills.Where(c => c.Id > Int32.Parse(bill1.BillNum.Text)).FirstOrDefault();
            else
                bigBill = _context.Bills.Where(c => c.Id > Int32.Parse(billBuy1.BillNum.Text)).FirstOrDefault();

            if (bigBill != null)
            {
                var billData = _context.BillData.Where(c => c.Bill.Id == bigBill.Id).ToList();
                show(bigBill, billData);

            }
            else MessageBox.Show("لا يوجد فواتير اخري ");

        }
    }
}
