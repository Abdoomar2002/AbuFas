using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
//using System.Web.UI;
using System.Windows.Forms;
using test_printing.db;
using UserControl = System.Windows.Forms.UserControl;

namespace test_printing
{
    public partial class bill : UserControl
    {
        public  AppDbContext _context;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handle = base.CreateParams;
                handle.ExStyle |= 0x02000000;
                return handle;
            }
        }
        int currentIndex=1;
        public bill()
        {
            InitializeComponent();
        }
        public bill(DbContextOptions<AppDbContext> options)
        {
            _context = new AppDbContext(options);
        }
        public void AutoSizeAll(Control control) 
        {
            float widthPercentage = (float)this.ClientSize.Width / 662;
            float heightPercentage = (float)this.ClientSize.Height / 609;
        //    float leftPercentage = (float)this.Left / 16;
            foreach (Control c in control.Controls) 
                {
                c.Width = (int)(c.Width * widthPercentage);
               c.Height = (int)(c.Width * heightPercentage);
            //    c.Left = (int)(this.ClientSize.Width * leftPercentage);

                if (c.HasChildren) { AutoSizeAll(c); }
                }
            
        }

       
        private void SetColumnWidths()
        {
            int totalWidth = data.Width;
            int desiredPercentage = 8;

            int columnHeaderWidth = (int)(totalWidth * (desiredPercentage / 100.0));

            // Set the width of the first column header
          /*  data.Columns[0].Width = columnHeaderWidth ;
            data.Columns[1].Width = columnHeaderWidth ;
            data.Columns[2].Width = columnHeaderWidth ;
            data.Columns[3].Width = columnHeaderWidth ;
            data.Columns[4].Width = columnHeaderWidth ;
            data.Columns[5].Width = columnHeaderWidth ;*/

            SetRowHeights(data, 30);
        }
        private void SetRowHeights(DataGridView dataGridView, int height)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Height = height;
            }
        }
        private void LoadDataFromDatabase()
        {
          
            try
            {
                _context = new AppDbContext();

                _context.Database.EnsureCreated();

                var last = _context.Bills;
                
               var lastBill= last.AsEnumerable().LastOrDefault();

                int id = (lastBill != null) ? lastBill.Id + 1 : 1;

              BillNum.Text = id.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
            }
        }

        private void bill_Load(object sender, EventArgs e)
        {
            label12.Text = DateTime.Now.ToShortDateString();
            SetColumnWidths();
            Notes.Height=105;
            LoadDataFromDatabase();
            data.RowCount=3;
            foreach (DataGridViewRow row in data.Rows)
            {
                row.Cells[0].Value = 0;
                row.Cells[1].Value = 0;
                row.Cells[2].Value = 0;
                row.Cells[3].Value = "21";
                row.Cells[4].Value = 0;
                row.Cells[5].Value = "";
               // row.Cells[6].Value = 21;
            //    row.Cells[7].Value = 0;
            //    row.Cells[8].Value = 0;
            }
            data.Columns[0].ValueType = typeof(double);
            data.Columns[1].ValueType = typeof(double);
            data.Columns[2].ValueType = typeof(double);
            data.Columns[4].ValueType = typeof(double);
            //  AutoSizeAll(this);
        }
        Bitmap bmp;
        public int currentPrintRow = 0;
        public int maxRowsPerPage = 0;
        public void btn_print(int width, int height)
        {
            int r = 0;
            Int32.TryParse(textBox1.Text, out r);
            if (CustName.Text.Trim(' ').Length > 0 && BillNum.Text.Length > 0 &&r  > 0)
            {


             
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += printDocument1_PrintPage;

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveToDB();
                    printDocument.Print();

                    reset();
                }
            }
            else MessageBox.Show("ادخل البيانات كاملة");
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            data.RowCount=data.RowCount<15?15:data.RowCount;
            data.ClearSelection();
            
            int headerHeight = Header.Height;
            int row1Height = Panelrow1.Height;
           // int row2Height = Panelrow2.Height;
            int yOffset = e.MarginBounds.Top;
            int dataGridViewHeight =data.PreferredSize.Height;
            int textBoxHeight = Notes.PreferredSize.Height;

            // Calculate the maximum number of rows that can fit on a page
             maxRowsPerPage += 15;// (e.MarginBounds.Height - headerHeight - row1Height - row2Height - dataGridViewHeight) / data.Rows[0].Height;

            // Print header panel
            yOffset += headerHeight;

            // Print row1 panel
            yOffset += row1Height;

            // Print row2 panel
          //  yOffset += row2Height;
            
            // Print DataGridView rows
            while (currentPrintRow < data.Rows.Count && currentPrintRow < maxRowsPerPage)
            {
                DataGridViewRow row = data.Rows[currentPrintRow];
                // Adjust the positions based on your layout
                yOffset += row.Height;
                currentPrintRow++;
            }
            Bitmap dataGridViewBitmap = new Bitmap(data.Width, dataGridViewHeight);
           
            data.DrawToBitmap(dataGridViewBitmap, new Rectangle(0, 0, data.Width, 15*24+data.ColumnHeadersHeight+396*(maxRowsPerPage/15-1)));
            e.Graphics.DrawImage(dataGridViewBitmap,e.MarginBounds.Left-20,308-396 * (maxRowsPerPage / 15 - 1), e.MarginBounds.Width+60,dataGridViewHeight);
            DrawPanelToGraphics(new Panel(),e.Graphics,e.MarginBounds.Left-20,0,e.MarginBounds.Width+60,20);
            DrawPanelToGraphics(Header, e.Graphics, e.MarginBounds.Left-20, 20, e.MarginBounds.Width + 60, headerHeight);
            DrawPanelToGraphics(Panelrow1, e.Graphics, e.MarginBounds.Left-20, 276, e.MarginBounds.Width + 60, row1Height);
          //  DrawPanelToGraphics(Panelrow2, e.Graphics, e.MarginBounds.Left-20, 312, e.MarginBounds.Width + 60, row2Height);
           
           
            
            // Print the remaining rows on the next page
            if (currentPrintRow < data.Rows.Count)
            {
                e.HasMorePages = true;
                return;
            }

            // Print TextBox
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Far;
            format.LineAlignment = StringAlignment.Near;
            format.Alignment = StringAlignment.Far;

            e.Graphics.DrawString(Notes.Text, Font, Brushes.Black, e.MarginBounds.Right, e.MarginBounds.Bottom-160 + textBoxHeight, format);
           
            // No more pages
            e.HasMorePages = false;



        }

        private void DrawPanelToGraphics(Panel panel, Graphics graphics, int x, int y, int width, int height)
        {
            Bitmap panelBitmap = new Bitmap(panel.Width, panel.Height);
           
            panel.DrawToBitmap(panelBitmap, new Rectangle(0, 0, panel.Width, panel.Height));
            graphics.DrawImage(panelBitmap, x, y, width, height);
        }
     
        private void Notes_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void data_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ResizeUserControl();
            data.Rows[data.RowCount - 1].Height = 30;
           // data.RowCount = 3;


            data.Rows[e.RowIndex].Cells[0].Value = 0;
            data.Rows[e.RowIndex].Cells[1].Value = 0;
            data.Rows[e.RowIndex].Cells[2].Value = 0;
            data.Rows[e.RowIndex].Cells[3].Value = "21";
            data.Rows[e.RowIndex].Cells[4].Value = 0;
            data.Rows[e.RowIndex].Cells[5].Value = "";
          //  data.Rows[e.RowIndex].Cells[6].Value = 21;
        //    data.Rows[e.RowIndex].Cells[7].Value = 0;
      //      data.Rows[e.RowIndex].Cells[8].Value = 0;




            currentIndex++;


        }
        private void ResizeUserControl()
        {
            int newHeight;
            // Calculate new height based on the content of TextBox and DataGridView
            if (data.Height>data.PreferredSize.Height)
             newHeight =Header.Height+Panelrow1.Height+ Notes.Height + data.Height;
            else
                newHeight = Header.Height + Panelrow1.Height + Notes.Height + data.PreferredSize.Height;

            // Set the new size for the UserControl
            this.Size = new Size(this.Width, newHeight);
            this.AutoScroll
                = true;
        }

        private void Notes_TextChanged(object sender, EventArgs e)
        {
            ResizeUserControl();
            if(Notes.Height<Notes.PreferredSize.Height)
            Notes.Height = Notes.PreferredSize.Height;
            else
                Notes.Height = Notes.Height;

        }
        public Image CaptureScreenshot()
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            return bmp;
        }
        public int SaveToDB()
        {
            Bills newBill = new Bills();
            List<BillData> billdata = new List<BillData>();

            newBill.CustomerName = CustName.Text;
            newBill.IsBuy = false;
            newBill.Notes = "";
            newBill.Date = DateTime.Now.Date;
            double totalmoney = 0;
            double totalGrams18 = 0;
            double totalGrams21 = 0;
            double totalGrams24 = 0;
            Double.TryParse(textBox1.Text, out totalmoney);
            newBill.Total = totalmoney;
            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.Index == data.RowCount - 1) continue;

                BillData dataRow = new BillData();

                // Check for null values and handle conversion accordingly
                dataRow.Price = (double)TryParseDouble(row.Cells[0].Value);
                dataRow.Weight = (double)TryParseDouble(row.Cells[1].Value);
                dataRow.Type = (double)TryParseDouble(row.Cells[2].Value);
                dataRow.Kyrat = (int)TryParseInt(row.Cells[3].Value);
                dataRow.Number = (int)TryParseInt(row.Cells[4].Value);
                dataRow.Name = row.Cells[5].Value?.ToString();

                if (dataRow.Kyrat == 21)
                    totalGrams21 = dataRow.Weight == null ? totalGrams21 : totalGrams21 + dataRow.Weight;
                if (dataRow.Kyrat == 18)
                    totalGrams18 = dataRow.Weight == null ? totalGrams18 : totalGrams18 + dataRow.Weight;
                if (dataRow.Kyrat == 24)
                    totalGrams24 = dataRow.Weight == null ? totalGrams24 : totalGrams24 + dataRow.Weight;
                billdata.Add(dataRow);
            }

            newBill.Data = billdata;
            var gramsStatic18 = _context.DayStaticGrams.Where(e => e.Date == DateTime.Today && e.Type == "18").FirstOrDefault();
            var gramsStatic21 = _context.DayStaticGrams.Where(e => e.Date == DateTime.Today && e.Type == "21").FirstOrDefault();
            var gramsStatic24 = _context.DayStaticGrams.Where(e => e.Date == DateTime.Today && e.Type == "24").FirstOrDefault();

            var dayStatic = _context.DaystaticMoney.Where(e => e.Date == DateTime.Today).FirstOrDefault();
            if (gramsStatic18 == null) { gramsStatic18 = new DayStaticGrams(); gramsStatic18.Date = DateTime.Today.Date; }
            if (gramsStatic21 == null) { gramsStatic21 = new DayStaticGrams(); gramsStatic21.Date = DateTime.Today.Date; }
            if (gramsStatic24 == null) { gramsStatic24 = new DayStaticGrams(); gramsStatic24.Date = DateTime.Today.Date; }
            if (dayStatic == null)
            {
                var dayStatic2 = _context.DaystaticMoney.OrderByDescending(c => c.Date).FirstOrDefault();

                dayStatic = new DaystaticMoney();
                dayStatic.Bills = new List<Bills>();
                dayStatic.IncomeOutCome = new List<IncomeOutcome>();
                dayStatic.Date = DateTime.Now.Date;
                //    _context.DaystaticMoney.Add(dayStatic);
                dayStatic.Total = dayStatic2 != null ? dayStatic2.Total : 0;
            }

            gramsStatic18.Sell = gramsStatic18.Buy == 0 ? totalGrams18 : totalGrams18 + gramsStatic18.Buy;
            gramsStatic21.Sell = gramsStatic21.Buy == 0 ? totalGrams21 : totalGrams21 + gramsStatic21.Buy;
            gramsStatic24.Sell = gramsStatic24.Buy == 0 ? totalGrams24 : totalGrams24 + gramsStatic24.Buy;
            gramsStatic18.Type = "18";
            gramsStatic21.Type = "21";
            gramsStatic24.Type = "24";
            dayStatic.Bills.Add(newBill);
            dayStatic.Total = dayStatic.Total == 0 ? totalmoney : dayStatic.Total + totalmoney;
            dayStatic.Bills.Add(newBill);
            if (dayStatic.Id == 0)
                _context.DaystaticMoney.Add(dayStatic);
            if (gramsStatic18.Id == 0 && totalGrams18 > 0)
                _context.DayStaticGrams.Add(gramsStatic18);
            if (gramsStatic21.Id == 0 && totalGrams21 > 0)
                _context.DayStaticGrams.Add(gramsStatic21);
            if (gramsStatic24.Id == 0 && totalGrams24 > 0)
                _context.DayStaticGrams.Add(gramsStatic24);
            _context.BillData.AddRange(billdata);
            _context.Bills.Add(newBill);
            _context.SaveChanges();

            // Helper methods to handle parsing with null check




            return 0;
        }
        
        private double? TryParseDouble(object value)
        {
            if (value == null)
            {
                return 0;
            }

            double result;
            return double.TryParse(value.ToString(), out result) ? (double?)result : 0;
        }

        private int? TryParseInt(object value)
        {
            if (value == null)
            {
                return 0;
            }

            int result;
            return int.TryParse(value.ToString(), out result) ? (int?)result : 0;
        }

        private void data_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    
        private void reset() 
        {
            CustName.Text = string.Empty;
            Home home = (Home)this.ParentForm;
           home.firstPage1.billBuy1.BillNum.Text = (Int32.Parse(BillNum.Text) + 1).ToString();
            BillNum.Text =( Int32.Parse(BillNum.Text)+1).ToString();
            last.Text = "";
            textBox1.Text = "";
            data.Rows.Clear();
            data.Height = 150;
            bill_Load(null,null);
        }

        private void BillNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void bill_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void data_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridViewTextBoxEditingControl editingControl = sender as DataGridViewTextBoxEditingControl;

            if (editingControl != null)
            {
                int columnIndex = data.CurrentCell.ColumnIndex;

                // Check if it's one of the first 8 columns
                if (columnIndex >= 0 && columnIndex < 8)
                {
                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 127)
                    {
                        e.Handled = true; // Mark the event as handled (prevent the character from being entered)
                    }
                }
                // Cell 9 can accept anything
                else if (columnIndex == 8)
                {
                    // No validation for the 9th column
                }
            }
        }

        private void data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double x;           
            if (data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value !=null
                && !Double.TryParse(data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),out x)
                &&e.ColumnIndex!=5) 
            {
                data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                MessageBox.Show("يجب ان يكون المدخل رقم");
            }
            else 
            {



                double price = 0, number = 0, weight = 0;
                object value1 = data.Rows[e.RowIndex].Cells[1].Value;
                object value2 = data.Rows[e.RowIndex].Cells[2].Value;
              //  object value3 = data.Rows[e.RowIndex].Cells[3].Value;
                object value4 = data.Rows[e.RowIndex].Cells[4].Value;
                //  object value7 = data.Rows[e.RowIndex].Cells[7].Value;

                // Check if any cell is empty
                if (value2 != null  && value4 != null && value1 != null)
                {
                    weight = Double.Parse(value1.ToString()) ;
                    number = Double.Parse(value4.ToString());
                    price = Double.Parse(value2.ToString()) ;
                    if (number > 0)
                    {
                        // Perform calculations only if all cells have data
                        double result1 = (weight * price);
                        data.Rows[e.RowIndex].Cells[0].Value = result1;
                        double total = 0;
                        int result0 = (int)((weight * number * price - result1) * 100);
                        //data.Rows[e.RowIndex].Cells[0].Value = result0;
                        foreach (DataGridViewRow row in data.Rows)
                        {
                            double r0 = 0;
                            Double.TryParse(row.Cells[1].Value.ToString(), out r0);
                            //  Int32.TryParse(row.Cells[1].Value.ToString(), out r1);
                            total += r0;
                            last.Text = total.ToString();
                        }
                    }
                }
            }
           
        }

        private void data_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
           
        }

        private void data_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }


}
