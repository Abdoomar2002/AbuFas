using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using test_printing.db;

namespace test_printing
{
    public partial class Archive : UserControl
    {
        bool searchFlag = false;
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
            Program._context = new AppDbContext();
            incoume.Columns[4].Visible = false;
            outcome.Columns[4].Visible = false;
            incoume.ThemeStyle.RowsStyle.Height = 30;
            incoume.Rows[0].Height = 30;
            outcome.ThemeStyle.RowsStyle.Height = 30;
            outcome.Rows[0].Height = 30;
            guna2Panel4.Width += 38;
            guna2Panel6.Width += 38;
            // outcome.Width +=150 ;
            incoume.ReadOnly = true;
            outcome.ReadOnly = true;
            billTable1.data.ReadOnly = true;
        }
        public Archive(DbContextOptions<AppDbContext> options)
        {

        }

        private void Archive_Load(object sender, EventArgs e)
        {

            //LoadTable();
            Single.Visible = false;
            Single.FillColor = Color.FromArgb(128, Color.Black);
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
        public void LoadTable(List<Bills> bills = null)
        {
            //   AppDbContext Program.Program._context = Program._context;
            Program._context.Database.OpenConnectionAsync();
            Program._context.Database.MigrateAsync();
            Program._context.Database.EnsureCreatedAsync();
            outcome.Rows.Clear();
            incoume.Rows.Clear();
            /*   var billList = Program.Program._context.Bills.ToArray();
               ArchiveTable.Controls.Clear();


               for (int row = 0; row < Math.Ceiling(billList.Length / 4.0); row++)
               {
                   for (int col = 0; col < 4; col++)
                   {
                       if (billList.Length == row * 4 + col) break;
                       var b = new bill();
                       var bu = new BillBuy();
                       var arcbill = billList[row * 4 + col].IsBuy ? bu : null;
                       var arcbill2 = !billList[row * 4 + col].IsBuy ? b : null;

                       if (arcbill != null)
                       {
                           arcbill.CustName.Text = billList[row * 4 + col].CustomerName;
                           arcbill.BillNum.Text = billList[row * 4 + col].Id.ToString();
                           arcbill.BillDate.Text = billList[row * 4 + col].Date.ToShortDateString();
                           int id = billList[row * 4 + col].Id;
                           var tablelis = Program.Program._context.BillData.Where(c => c.Bill.Id == id);

                           var table = tablelis.ToArray();
                           arcbill.data.RowCount = table.Length;

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
                           arcbill2.label12.Text = billList[row * 4 + col].Date.ToShortDateString();
                           int id = billList[row * 4 + col].Id;
                           var tablelis = Program.Program._context.BillData.Where(c => c.Bill.Id == id);

                           var table = tablelis.ToArray();
                           arcbill2.data.RowCount = table.Length;

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
               }*/

            var Sold = Program._context.Bills.Where(c => c.IsBuy == false && c.Date == DateTime.Now.Date).ToList();
            var Bought = Program._context.Bills.Where(c => c.IsBuy == true && c.Date == DateTime.Now.Date).ToList();
            if (searchFlag == true) 
            {
                if (bills == null || bills.Count == 0) { MessageBox.Show("لا يوجد فواتير مطابقة للبحث"); searchFlag = false; return; }
                else
                {
                    Sold = bills.Where(c => c.IsBuy == false).ToList();
                    Bought = bills.Where(c => c.IsBuy == true).ToList();
                }
                searchFlag = false;

            }
            outcome.RowCount = Bought.Count != 0 ? Bought.Count : 1;
            for (var i = 0; i < Bought.Count; i++)
            {
                var item = Bought[i];
                outcome.Rows[i].Cells[0].Value = item.Date.ToShortDateString();
                outcome.Rows[i].Cells[1].Value = item.CustomerName.ToString();
                outcome.Rows[i].Cells[2].Value = item.Total.ToString();
                outcome.Rows[i].Cells[3].Value = calcGrams(item);
                outcome.Rows[i].Cells[4].Value = item.Id.ToString();
            }

            incoume.RowCount = Sold.Count != 0 ? Sold.Count : 1;
            for (var i = 0; i < Sold.Count; i++)
            {
                var item = Sold[i];
                incoume.Rows[i].Cells[0].Value = item.Date.ToShortDateString();
                incoume.Rows[i].Cells[1].Value = item.CustomerName.ToString();
                incoume.Rows[i].Cells[2].Value = item.Total.ToString();
                incoume.Rows[i].Cells[3].Value = calcGrams(item);
                incoume.Rows[i].Cells[4].Value = item.Id.ToString();
            }

        }
        private double calcGrams(Bills bill)
        {
            var data = Program._context.BillData.Where(c => c.Bill == bill).ToList();
            double totalGrams = 0;
            foreach (var item in data)
            {
                if (item.Kyrat == 18) totalGrams += item.Weight * 18.0 / 21.0;
                else if (item.Kyrat == 21) totalGrams += item.Weight;
                else totalGrams += item.Weight * 24 / 21;
            }
            totalGrams = Math.Round(totalGrams, 3);

            return totalGrams;

        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            Single.Visible = true;
            PictureBox pictureBox = (sender as PictureBox);

            var bigBill = Program._context.Bills.Where(c => c.Id == Int32.Parse(pictureBox.Name)).FirstOrDefault();
            var billdata = Program._context.BillData.Where(c => c.Bill.Id == bigBill.Id).ToList();
            show(bigBill, billdata);
            Single.BringToFront();




        }
        public void show(Bills bigBill, List<BillData> billdata)
        {
            double total = 0, total18 = 0, total24 = 0;
            billTable1.Visible = false;
            billTable1.Visible = true;
            billTable1.CustName.Text = bigBill.CustomerName;
            billTable1.BillNum.Text = bigBill.Id.ToString();
            var table = billdata.ToArray();
            billTable1.data.RowCount = table.Length;
            for (int i = 0; i < table.Length; i++)
            {
                DataGridViewRow obj = billTable1.data.Rows[i];

                obj.Cells[0].Value = table[i].Price.ToString();
                //   obj.Cells[1].Value = ((long)table[i].Price).ToString();
                obj.Cells[1].Value = table[i].Weight.ToString();
                //  obj.Cells[3].Value = ((int)table[i].Weight).ToString();
                obj.Cells[2].Value = table[i].Type.ToString();
                //obj.Cells[5].Value = ((int)table[i].Type).ToString();
                obj.Cells[3].Value = table[i].Kyrat == 0 ? null : table[i].Kyrat.ToString();
                obj.Cells[4].Value = table[i].Number.ToString();
                obj.Cells[5].Value = table[i].Name;
                if (table[i].Kyrat == 21)
                    total += table[i].Weight;
                else if (table[i].Kyrat == 18)
                    total18 += table[i].Weight;
                else total24 += table[i].Weight;

                // billTable1.data.Rows.Add(obj);
            }
            billTable1.last.Text = total.ToString();
            billTable1.textBox2.Text = total18.ToString();
            billTable1.textBox3.Text = total24.ToString();
            billTable1.textBox1.Text = bigBill.Total.ToString();



        
    
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
            home.search.Visible = false;
            home.from.Visible = false;
            home.to.Visible = false;
            home.start.Visible = false;
            home.end.Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (billTable1.Visible) billTable1.btn_print(200, 300,true);
            else billTable1.btn_print(200, 300,true);
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("هل انت متاكد", "", MessageBoxButtons.YesNo);
            if (msg == DialogResult.Yes) 
            {
                var id = Int32.Parse(billTable1.BillNum.Text) ;

               var billToDelete= Program._context.Bills.Where(c => c.Id == id).FirstOrDefault();
               var dataToDelete= Program._context.BillData.Where(c => c.Bill == billToDelete).ToList();
               var MoneyToDelete = Program._context.DaystaticMoney.Where(c => c.Date == billToDelete.Date).FirstOrDefault();
               var GramToDelete18 = Program._context.DayStaticGrams.Where(c => c.Date == billToDelete.Date&&c.Type=="18").FirstOrDefault();
               var GramToDelete21 = Program._context.DayStaticGrams.Where(c => c.Date == billToDelete.Date && c.Type == "21").FirstOrDefault();
               var GramToDelete24 = Program._context.DayStaticGrams.Where(c => c.Date == billToDelete.Date && c.Type == "24").FirstOrDefault();
                if(GramToDelete18==null)GramToDelete18=new DayStaticGrams();
                if(GramToDelete21==null)GramToDelete21=new DayStaticGrams();
                if(GramToDelete24==null)GramToDelete24=new DayStaticGrams();
                double totalgrams18 = 0;
                double totalgrams21 = 0;
                double totalgrams24 = 0;
                foreach (var d in dataToDelete) 
                {
                    if(d.Kyrat==18)
                    totalgrams18 += d.Weight;
                    if (d.Kyrat == 21)
                        totalgrams21 += d.Weight;
                    if (d.Kyrat == 24)
                        totalgrams24 += d.Weight;
                }
                if (billToDelete.IsBuy == true)
                { 
                    GramToDelete18.Buy -= totalgrams18;
                    GramToDelete21.Buy -= totalgrams21;
                    GramToDelete24.Buy -= totalgrams24;
                    MoneyToDelete.Total += billToDelete.Total;
                }
                else {
                    GramToDelete18.Sell -= totalgrams18;
                    GramToDelete21.Sell -= totalgrams21;
                    GramToDelete24.Sell -= totalgrams24;
                    MoneyToDelete.Total -= billToDelete.Total;

                }
                var moneyList = Program._context.DaystaticMoney.Where(c => c.Date >= MoneyToDelete.Date).ToList();
                if (moneyList.Count > 0)
                {
                    foreach (var item in moneyList)
                    {
                        if (billToDelete.IsBuy == true)
                            item.Total += billToDelete.Total;
                        else
                        {
                            item.Total -= billToDelete.Total;
                        }
                    }
                }
                MoneyToDelete.Bills.Remove(billToDelete);

                Program._context.BillData.RemoveRange(dataToDelete);
                Program._context.Bills.Remove(billToDelete);
                Program._context.SaveChanges();
                Single.Visible = false;
                Single.SendToBack();
                LoadTable();
            }
        }

        private void previous_Click(object sender, EventArgs e)
        {
            var bigBill = new Bills();
                bigBill = Program._context.Bills.AsEnumerable().Where(c => c.Id < Int32.Parse(billTable1.BillNum.Text)).LastOrDefault();
            if (bigBill != null)
            {
                var billData = Program._context.BillData.Where(c => c.Bill.Id == bigBill.Id).ToList();
                show(bigBill, billData);
            }
            else MessageBox.Show("لا يوجد فواتير اخري ");
        }

        private void next_Click(object sender, EventArgs e)
        {
            var bigBill=new Bills();
                 bigBill = Program._context.Bills.Where(c => c.Id > Int32.Parse(billTable1.BillNum.Text)).FirstOrDefault();
            if (bigBill != null)
            {
                var billData = Program._context.BillData.Where(c => c.Bill.Id == bigBill.Id).ToList();
                show(bigBill, billData);

            }
            else MessageBox.Show("لا يوجد فواتير اخري ");

        }

        private void incoume_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            int id = 0;
            Guna2DataGridView view=(Guna2DataGridView)sender;
            if (null== view.Rows[e.RowIndex].Cells[4].Value) { MessageBox.Show("لا يوجد بيانات");return; }
            Int32.TryParse(view.Rows[e.RowIndex].Cells[4].Value.ToString(), out id);
            var bill = Program._context.Bills.Where(c => c.Id == id).FirstOrDefault();
            if (bill == null) {
                //Int32.TryParse(outcome.Rows[e.RowIndex].Cells[4].Value.ToString(), out id);
                MessageBox.Show("error");
                //bill = Program.Program._context.Bills.Where(c => c.Id == id).FirstOrDefault();
            }
            var data = Program._context.BillData.Where(c => c.Bill == bill).ToList();
            show(bill,data);
            Single.BringToFront();
            Single.Visible = true;

        }

        public void SearchByName(string name) 
        {
            int id = 0;
            
            Int32.TryParse(name, out id);
            List<Bills>bills = new List<Bills>();
            bills=Program._context.Bills.Where(c=>c.CustomerName.Contains(name)||c.Id==id).ToList();
            searchFlag = true;
             
            LoadTable(bills);

        }
        public void SearchByDate(DateTime start,DateTime end)
        {
            List<Bills> bills = new List<Bills>();
            bills = Program._context.Bills.Where(c => c.Date>=start&&c.Date<=end).ToList();
            searchFlag = true;
            LoadTable(bills);
        }
    }
}
