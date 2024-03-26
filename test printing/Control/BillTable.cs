using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using System.Xml.Linq;
using test_printing;
using test_printing.db;


namespace AbuFas.Control
{
    public partial class BillTable : UserControl
    {
        Bitmap bmp;
        public int currentPrintRow = 0;
        public int maxRowsPerPage = 0;
        public bool IsBuy=false;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handle = base.CreateParams;
                handle.ExStyle |= 0x02000000;
                return handle;
            }
        }
        public BillTable()
        {
            InitializeComponent();
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


                Program._context.Database.EnsureCreated();

                var last = Program._context.Bills;

                var lastBill = last.AsEnumerable().LastOrDefault();

                int id = (lastBill != null) ? lastBill.Id + 1 : 1;

                BillNum.Text = id.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
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
        private void BillTable_Load(object sender, EventArgs e)
        {
            data.Rows[0].Cells[3].Value = "21";
            data.Rows[0].Height = 30;

            SetColumnWidths();

            LoadDataFromDatabase();
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

        }

        private void data_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ResizeUserControl();
            data.Rows[e.RowIndex].Cells[0].Value = 0;
            data.Rows[e.RowIndex].Cells[1].Value = 0;
            data.Rows[e.RowIndex].Cells[2].Value = 0;
            data.Rows[e.RowIndex].Cells[3].Value = "21";
            data.Rows[e.RowIndex].Cells[4].Value = 0;
        }
        private void ResizeUserControl()
        {
            int newHeight;
            // Calculate new height based on the content of TextBox and DataGridView
            if (data.Height > data.PreferredSize.Height)
                newHeight =  Panelrow1.Height + Notes.Height + data.Height;
            else
                newHeight =  Panelrow1.Height + Notes.Height + data.PreferredSize.Height;

            // Set the new size for the UserControl
            this.Size = new Size(this.Width, newHeight);
            this.AutoScroll
                = true;
        }
        private void reset()
        {
            CustName.Text = string.Empty;
            Home home = (Home)this.ParentForm;
            if(!IsBuy)
              home.firstPage1.billTable2.BillNum.Text = (Int32.Parse(BillNum.Text) + 1).ToString();
            else 
              home.firstPage1.billTable1.BillNum.Text = (Int32.Parse(BillNum.Text) + 1).ToString();
            BillNum.Text = (Int32.Parse(BillNum.Text) + 1).ToString();
            last.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            data.Rows.Clear();
            data.Height = 150;

            BillTable_Load(null, null);
           
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
            if (data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null
                && !Double.TryParse(data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out x)
                && e.ColumnIndex != 5)
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
                if (value2 != null && value4 != null && value1 != null)
                {
                    weight = Double.Parse(value1.ToString());
                    number = Double.Parse(value4.ToString());
                    price = Double.Parse(value2.ToString());
                    if (number > 0)
                    {
                        // Perform calculations only if all cells have data
                        double result1 = (weight * price);
                        //  data.Rows[e.RowIndex].Cells[0].Value = result1;
                        double total = 0, total18 = 0, total24 = 0;
                        int result0 = (int)((weight * number * price - result1) * 100);
                        //data.Rows[e.RowIndex].Cells[0].Value = result0;
                        foreach (DataGridViewRow row in data.Rows)
                        {
                            double r0 = 0;
                            Double.TryParse(row.Cells[1].Value.ToString(), out r0);
                            //  Int32.TryParse(row.Cells[1].Value.ToString(), out r1);

                            if (row.Cells[3].Value.ToString() == "21")
                            {
                                total += r0;

                                //  Int32.TryParse(row.Cells[1].Value.ToString(), out r1);
                                // 
                                //   else if (row.Cells[3].Value.ToString() == "18") total += r0 * 18 / 21;
                                //  else if (row.Cells[3].Value.ToString() == "24") total += r0 * 24 / 21;
                            }
                            else if (row.Cells[3].Value.ToString() == "18")
                            {
                                total18 += r0;
                            }
                            else if (row.Cells[3].Value.ToString() == "24")
                            {
                                total24 += r0;
                            }
                        }
                        last.Text = Math.Round(total, 3).ToString();
                        textBox2.Text = total18.ToString();
                        textBox3.Text = total24.ToString();

                    }
                }
            }

        }
        public int SaveToDB()
        {
            Bills newBill = new Bills();
            List<BillData> billdata = new List<BillData>();

            newBill.CustomerName = CustName.Text;
            newBill.IsBuy = IsBuy;
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
            // totalmoney = (double)TryParseDouble(textBox1.Text);
            newBill.Data = billdata;
            var gramsStatic18 = Program._context.DayStaticGrams.Where(e => e.Date == DateTime.Today && e.Type == "18").FirstOrDefault();
            var gramsStatic21 = Program._context.DayStaticGrams.Where(e => e.Date == DateTime.Today && e.Type == "21").FirstOrDefault();
            var gramsStatic24 = Program._context.DayStaticGrams.Where(e => e.Date == DateTime.Today && e.Type == "24").FirstOrDefault();

            var dayStatic = Program._context.DaystaticMoney.Where(e => e.Date == DateTime.Today).FirstOrDefault();
            if (gramsStatic18 == null) { gramsStatic18 = new DayStaticGrams(); gramsStatic18.Date = DateTime.Today.Date; }
            if (gramsStatic21 == null) { gramsStatic21 = new DayStaticGrams(); gramsStatic21.Date = DateTime.Today.Date; }
            if (gramsStatic24 == null) { gramsStatic24 = new DayStaticGrams(); gramsStatic24.Date = DateTime.Today.Date; }
            if (dayStatic == null)
            {
                var dayStatic2 = Program._context.DaystaticMoney.OrderByDescending(c => c.Date).FirstOrDefault();

                dayStatic = new DaystaticMoney();
                dayStatic.Bills = new List<Bills>();
                dayStatic.IncomeOutCome = new List<IncomeOutcome>();
                dayStatic.Date = DateTime.Now.Date;
                //    Program._context.DaystaticMoney.Add(dayStatic);
                dayStatic.Total = dayStatic2 != null ? dayStatic2.Total : 0;
            }
            if (!IsBuy)
            {
                gramsStatic18.Sell = gramsStatic18.Sell == 0 ? totalGrams18 : totalGrams18 + gramsStatic18.Sell;
                gramsStatic21.Sell = gramsStatic21.Sell == 0 ? totalGrams21 : totalGrams21 + gramsStatic21.Sell;
                gramsStatic24.Sell = gramsStatic24.Sell == 0 ? totalGrams24 : totalGrams24 + gramsStatic24.Sell;
            }
            else
            {
                gramsStatic18.Buy = gramsStatic18.Buy == 0 ? totalGrams18 : totalGrams18 + gramsStatic18.Buy;
                gramsStatic21.Buy = gramsStatic21.Buy == 0 ? totalGrams21 : totalGrams21 + gramsStatic21.Buy;
                gramsStatic24.Buy = gramsStatic24.Buy == 0 ? totalGrams24 : totalGrams24 + gramsStatic24.Buy;
            }
            gramsStatic18.Type = "18";
            gramsStatic21.Type = "21";
            gramsStatic24.Type = "24";
            if (dayStatic.Id == 0)
                Program._context.DaystaticMoney.Add(dayStatic);
            dayStatic.Bills.Add(newBill);
            if(!IsBuy)
            dayStatic.Total = dayStatic.Total == 0 ? totalmoney : dayStatic.Total + totalmoney;
            else
            dayStatic.Total = dayStatic.Total == 0 ? totalmoney * -1 : dayStatic.Total - totalmoney;

            dayStatic.Bills.Add(newBill);
            if (gramsStatic18.Id == 0 && totalGrams18 > 0)
                Program._context.DayStaticGrams.Add(gramsStatic18);
            if (gramsStatic21.Id == 0 && totalGrams21 > 0)
                Program._context.DayStaticGrams.Add(gramsStatic21);
            if (gramsStatic24.Id == 0 && totalGrams24 > 0)
                Program._context.DayStaticGrams.Add(gramsStatic24);
            Program._context.BillData.AddRange(billdata);
            Program._context.Bills.Add(newBill);
            Program._context.SaveChanges();

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
        public void btn_print(int width, int height)
        {
            int r = 0;
            Int32.TryParse(textBox1.Text, out r);
            if (CustName.Text.Trim(' ').Length > 0 && BillNum.Text.Length > 0 && r > 0)
            {



                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += printDocument1_PrintPage;

                PrintDialog printDialog = new PrintDialog();
                printDocument.DocumentName = "فاتورة رقم " + BillNum.Text + " بأسم " + CustName.Text;
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
          //  data.RowCount = data.RowCount < 15 ? 15 : data.RowCount;
          
            data.ClearSelection();

      
            int row1Height = Panelrow1.Height;
            // int row2Height = Panelrow2.Height;
            int yOffset = 396;
            int dataGridViewHeight = data.PreferredSize.Height;
      

            // Calculate the maximum number of rows that can fit on a page
            maxRowsPerPage += 18;// (e.MarginBounds.Height - headerHeight - row1Height - row2Height - dataGridViewHeight) / data.Rows[0].Height;

              // Print DataGridView rows
            while (currentPrintRow < data.Rows.Count && currentPrintRow < maxRowsPerPage)
            {
                DataGridViewRow row = data.Rows[currentPrintRow];
                // Adjust the positions based on your layout
                yOffset += row.Height;
                currentPrintRow++;
            }
            Bitmap dataGridViewBitmap = new Bitmap(data.Width, data.ColumnHeadersHeight + data.RowCount * 50+10);

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Far;
            format.LineAlignment = StringAlignment.Near;
            format.Alignment = StringAlignment.Far;
            var newFont = new System.Drawing.Font("Cairo", 12,FontStyle.Bold);
            
            string c = last.Text + "        \t         " + label13.Text+ "        \t         ";
            c += textBox2.Text + "        \t         " + label14.Text + "        \t         ";
            c += textBox3.Text + "        \t         " + label15.Text + "        \t         ";
             c += textBox1.Text + "        \t         " + label1.Text + "        \t         ";
            e.Graphics.DrawString(c, newFont, Brushes.Black, e.MarginBounds.Right+80,e.MarginBounds.Bottom, format);
          data.DrawToBitmap(dataGridViewBitmap, new Rectangle(0, 0, data.Width + 50, 15 * 24 + data.ColumnHeadersHeight + data.RowCount*50 +80 + 396 * (maxRowsPerPage / 15 - 1)));
           e.Graphics.DrawImage(dataGridViewBitmap, e.MarginBounds.Left - 80, 408 - 396 * (maxRowsPerPage / 15 - 1), e.MarginBounds.Width + 160, data.RowCount*50+80 );
            DrawPanelToGraphics(Panelrow1, e.Graphics, e.MarginBounds.Left-80, 372, e.MarginBounds.Width + 160, row1Height);

            // Print the remaining rows on the next page
            if (currentPrintRow < data.Rows.Count)
            {
                e.HasMorePages = true;
                return;
            }

            // Print TextBox
            // No more pages
            e.HasMorePages = false;

        }
        private void DrawPanelToGraphics(Panel panel, Graphics graphics, int x, int y, int width, int height)
        {
            Bitmap panelBitmap = new Bitmap(panel.Width, panel.Height);

            panel.DrawToBitmap(panelBitmap, new Rectangle(0, 0, panel.Width, panel.Height));
            graphics.DrawImage(panelBitmap, x, y, width, height);
        }
  
    }

}
