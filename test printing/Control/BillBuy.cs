using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using test_printing.db;
using Application = Microsoft.Office.Interop.Word.Application;

namespace test_printing
{
    public partial class BillBuy : UserControl
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
        Bitmap bmp;
        public int currentPrintRow = 0;
        public int maxRowsPerPage = 0;
        int currentIndex = 1;
        public BillBuy()
        {
            InitializeComponent();

        }
        public BillBuy(DbContextOptions<AppDbContext> options)
        {
           
        }

        private void Notes_TextChanged(object sender, EventArgs e)
        {

        }
        private void SetColumnWidths()
        {
            int totalWidth = data.Width;
            int desiredPercentage = 8;

            int columnHeaderWidth = (int)(totalWidth * (desiredPercentage / 100.0));

            // Set the width of the first column header
           
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                Program._context.Database.EnsureCreated();

                var last = Program._context.Bills.AsEnumerable();

                var lastBill = last.LastOrDefault();
                int id = (lastBill != null) ? lastBill.Id + 1 : 1;

                BillNum.Text = id.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
            }
        }

        private void BillBuy_Load(object sender, EventArgs e)
        {
            BillDate.Text = DateTime.Now.ToShortDateString();
            textBox2.Text = "0";
            SetColumnWidths();
            LoadDataFromDatabase();
            data.RowCount = 1;
            data.Rows[0].Height = 30;

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
        public void btn_print(int width, int height)
        {
            int r = 0;
            Int32.TryParse(textBox1.Text, out r);
            if (CustName.Text.Trim(' ').Length > 0 && BillNum.Text.Length > 0 && r > 0)
            {

                WriteTableToWordInterop("newfileword", GetGridData(data));
                SaveToDB();
                reset();
                /* PrintDocument printDocument = new PrintDocument();
                 printDocument.PrintPage += printDocument1_PrintPage;

                 PrintDialog printDialog = new PrintDialog();
                 printDocument.DocumentName = "فاتورة رقم " + BillNum.Text + " بأسم " + CustName.Text;
                 printDialog.Document = printDocument;

                 if (printDialog.ShowDialog() == DialogResult.OK)
                 {

                     printDocument.Print();

                     
                 }*/


            }
            else MessageBox.Show("ادخل البيانات كاملة");
        }
        public List<List<string>> GetGridData(DataGridView dataGridView)
        {
            // Validate input
            if (dataGridView == null || dataGridView.Rows.Count == 0 || dataGridView.Columns.Count == 0)
            {
                return new List<List<string>>(); // Return empty list if no data
            }

            // Create a list to store rows of data as lists of strings
            var data = new List<List<string>>();

            // Extract data from each row
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var rowData = new List<string>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Handle null values appropriately (optional)
                    rowData.Add(cell.Value?.ToString() ?? ""); // Use ?? to provide an empty string for null values
                }
                data.Add(rowData);
            }

            return data;
        }
        public void WriteTableToWordInterop(string filePath, List<List<string>> data)
        {
            var wordApp = new Application();
            var wordDoc = wordApp.Documents.Add();
            wordDoc.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            wordDoc.PageSetup.TopMargin = 200;
            wordDoc.PageSetup.BottomMargin = 200;
            string[] arr = { "جملة الثمن", "الوزن", "الفئة", "العيار", "العدد", "الصنف" };
            var par = wordDoc.Paragraphs.Add();
            par.Range.Text = " الاسم " + CustName.Text;
            par.Range.Bold = 8;
            par.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight; // Center alignment
            par.Range.InsertParagraphAfter();
            var par2 = wordDoc.Paragraphs.Add();
            par2.Range.Text = BillNum.Text + " رقم الفاتورة ";
            par2.Range.Bold = 8;
            par2.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight; // Center alignment
            par2.Range.InsertParagraphAfter();
            var table = wordDoc.Tables.Add(par2.Range, data.Count, data[0].Count);
            table.TableDirection = WdTableDirection.wdTableDirectionRtl;

            //   table.Rows.Alignment = WdRowAlignment.wdAlignRowRight;
            table.Rows.Alignment = WdRowAlignment.wdAlignRowRight;
            table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleThickThinLargeGap;
            table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleTriple;
            // Set header row
            for (int i = 1; i <= arr.Length; i++)
            {
                table.Cell(1, i).Range.Text = arr[i - 1];


                table.Cell(1, i).Range.Font.Bold = 4; // Set bold for headers (optional)
            }

            // Set data rows
            for (int i = 2; i <= data.Count; i++)
            {
                for (int j = 1; j <= data[0].Count; j++)
                {
                    table.Cell(i, j).Range.Text = data[i - 2][j - 1];
                    table.Cell(i, j).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                }

            }

            string c =
             textBox1.Text + "          " + label1.Text + "          ";
            var d = textBox2.Text + "          " + label14.Text + "          ";
            var e = textBox3.Text + "          " + label15.Text + "          ";
            var f = last.Text + "          " + label13.Text + "          ";
            var par3 = wordDoc.Paragraphs.Add();
            par3.Range.Text = c;
            par3.Range.Bold = 8;
            par3.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            par3.Range.InsertParagraphAfter();
            var par4 = wordDoc.Paragraphs.Add();
            par4.Range.Text = d;
            par4.Range.Bold = 8;
            par4.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            par4.Range.InsertParagraphAfter();
            var par6 = wordDoc.Paragraphs.Add();
            par6.Range.Text = f;
            par6.Range.Bold = 8;
            par6.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            par6.Range.InsertParagraphAfter();
            var par5 = wordDoc.Paragraphs.Add();
            par5.Range.Text = e;
            par5.Range.Bold = 8;
            par5.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            par5.Range.InsertParagraphAfter();
            wordDoc.PrintPreview();
            string printerName = wordApp.ActivePrinter;
            wordDoc.PrintOut(PrintToFile: false);
            wordDoc.SaveAs(BillNum.Text + " فاتورة رقم");
            wordApp.Quit();
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            data.ClearSelection();
            
            int headerHeight = Header.Height;
            int row1Height = Panelrow1.Height;
            
            int yOffset = e.MarginBounds.Top;

            int dataGridViewHeight = data.PreferredSize.Height;
            int textBoxHeight = promise.PreferredSize.Height;

            // Calculate the maximum number of rows that can fit on a page
            maxRowsPerPage += 10;// (e.MarginBounds.Height - headerHeight - row1Height - row2Height - dataGridViewHeight) / data.Rows[0].Height;

            // Print header panel
            yOffset += headerHeight;

            // Print row1 panel
            yOffset += row1Height;
            
            // Print DataGridView rows
            while (currentPrintRow < data.Rows.Count && currentPrintRow < maxRowsPerPage)
            {
                DataGridViewRow row = data.Rows[currentPrintRow];
                // Adjust the positions based on your layout
                yOffset += row.Height;
                currentPrintRow++;
            }
            Bitmap dataGridViewBitmap = new Bitmap(data.Width, dataGridViewHeight);

            data.DrawToBitmap(dataGridViewBitmap, new System.Drawing.Rectangle(0, 0, data.Width + 50, 15 * 24 + data.ColumnHeadersHeight + 91 + 396 * (maxRowsPerPage / 15 - 1)));
            e.Graphics.DrawImage(dataGridViewBitmap, e.MarginBounds.Left - 80, 408 - 396 * (maxRowsPerPage / 15 - 1), e.MarginBounds.Width + 160, dataGridViewHeight + 80);
       //     DrawPanelToGraphics(new Panel(), e.Graphics, e.MarginBounds.Left - 20, 0, e.MarginBounds.Width + 60, 20);
          //  DrawPanelToGraphics(Header, e.Graphics, e.MarginBounds.Left - 20, 20, e.MarginBounds.Width + 60, headerHeight);
           // DrawPanelToGraphics(Panelrow1, e.Graphics, e.MarginBounds.Left - 20, 276, e.MarginBounds.Width + 60, row1Height);
          

            // Print the remaining rows on the next page
            if (currentPrintRow < data.Rows.Count)
            {
                e.HasMorePages = true;
                return;
            }

            // Print TextBox
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Far;
            format.LineAlignment = StringAlignment.Far;

          //  e.Graphics.DrawString(Notes.Text, Font, Brushes.Black, e.MarginBounds.Right, yOffset + textBoxHeight, format);
        //  DrawPanelToGraphics(promise,e.Graphics, e.MarginBounds.Left - 20, yOffset, e.MarginBounds.Width+60, promise.Height);
            // No more pages
            e.HasMorePages = false;



        }

        private void DrawPanelToGraphics(Panel panel, Graphics graphics, int x, int y, int width, int height)
        {
            Bitmap panelBitmap = new Bitmap(panel.Width, panel.Height);

            panel.DrawToBitmap(panelBitmap, new System.Drawing.Rectangle(0, 0, panel.Width, panel.Height));
            graphics.DrawImage(panelBitmap, x, y, width, height);
        }
        private void ResizeUserControl()
        {
            int newHeight;
            // Calculate new height based on the content of TextBox and DataGridView
            if (data.Height > data.PreferredSize.Height)
                newHeight = Header.Height + Panelrow1.Height  + promise.Height + data.Height;
            else
                newHeight = Header.Height + Panelrow1.Height + promise.Height + data.PreferredSize.Height;

            // Set the new size for the UserControl
            this.Size = new Size(this.Width, newHeight);
            this.AutoScroll
                = true;
        }

        private void data_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ResizeUserControl();
            data.Rows[data.RowCount - 1].Height = 30;
            data.Rows[e.RowIndex].Cells[0].Value = 0;
            data.Rows[e.RowIndex].Cells[1].Value = 0;
            data.Rows[e.RowIndex].Cells[2].Value = 0;
            data.Rows[e.RowIndex].Cells[3].Value = "21";
            data.Rows[e.RowIndex].Cells[4].Value = 0;
            data.Rows[e.RowIndex].Cells[5].Value = "";   
            currentIndex++;
        }
        public int SaveToDB()
        {
            Bills newBill = new Bills();
            List<BillData> billdata = new List<BillData>();

            newBill.CustomerName = CustName.Text;
            newBill.IsBuy = true;

            newBill.Date = DateTime.Now.Date;
            double totalGrams21 = 0;
            double totalGrams18 = 0;
            double totalGrams24 = 0;
            double totalmoney = 0;
            Double.TryParse(textBox2.Text, out totalmoney);
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
         //   totalmoney = (double)TryParseDouble(textBox2.Text);
            newBill.Data = billdata;
            var gramsStatic18 = Program._context.DayStaticGrams.Where(e => e.Date == DateTime.Today && e.Type == "18").FirstOrDefault();
            var gramsStatic21 = Program._context.DayStaticGrams.Where(e => e.Date == DateTime.Today && e.Type == "21").FirstOrDefault();
            var gramsStatic24 = Program._context.DayStaticGrams.Where(e => e.Date == DateTime.Today && e.Type == "24").FirstOrDefault();

            var dayStatic = Program._context.DaystaticMoney.Where(e => e.Date == DateTime.Today).FirstOrDefault();
            if (gramsStatic18 == null) { gramsStatic18 = new DayStaticGrams(); gramsStatic18.Date = DateTime.Now.Date; }
            if (gramsStatic21 == null) { gramsStatic21 = new DayStaticGrams(); gramsStatic21.Date = DateTime.Now.Date; }
            if (gramsStatic24 == null) { gramsStatic24 = new DayStaticGrams(); gramsStatic24.Date = DateTime.Now.Date; }
            if (dayStatic == null)
            {
                var dayStatic2 = Program._context.DaystaticMoney.OrderByDescending(c => c.Date).FirstOrDefault();
                dayStatic = new DaystaticMoney();
                dayStatic.Bills = new List<Bills>();
                dayStatic.IncomeOutCome = new List<IncomeOutcome>();
                dayStatic.Total = dayStatic2 != null ? dayStatic2.Total : 0;
            }
            gramsStatic18.Buy = gramsStatic18.Buy == 0 ? totalGrams18 : totalGrams18 + gramsStatic18.Buy;
            gramsStatic21.Buy = gramsStatic21.Buy == 0 ? totalGrams21 : totalGrams21 + gramsStatic21.Buy;
            gramsStatic24.Buy = gramsStatic24.Buy == 0 ? totalGrams24 : totalGrams24 + gramsStatic24.Buy;
            gramsStatic18.Type = "18";
            gramsStatic21.Type = "21";
            gramsStatic24.Type = "24";
            dayStatic.Bills.Add(newBill);
            dayStatic.Total = dayStatic.Total == 0 ? totalmoney * -1 : dayStatic.Total - totalmoney;
            if (dayStatic.Id == 0)
                Program._context.DaystaticMoney.Add(dayStatic);
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
        private void reset()
        {
            CustName.Text = string.Empty;
            Home home = (Home)this.ParentForm;
       //     home.firstPage1.bill1.BillNum.Text = (Int32.Parse(BillNum.Text) + 1).ToString();
            BillNum.Text = (Int32.Parse(BillNum.Text) + 1).ToString();
            data.Rows.Clear();
            last.Text = "";
            textBox2.Text = "";
            data.Height = 150;

            BillBuy_Load(null, null);
        }

        private void data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double x;
            if (
                data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null &&
                !Double.TryParse(data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
               , out x) && e.ColumnIndex != 5)
            {
                data.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                MessageBox.Show("يجب ان يكون المدخل رقم");
            }
            else
            {



                double price = 0, number = 0, weight = 0;
                object value1 = data.Rows[e.RowIndex].Cells[1].Value;
                object value2 = data.Rows[e.RowIndex].Cells[2].Value;
                object value3 = data.Rows[e.RowIndex].Cells[3].Value;
                object value4 = data.Rows[e.RowIndex].Cells[4].Value;
                //  object value7 = data.Rows[e.RowIndex].Cells[7].Value;

                // Check if any cell is empty
                if (value2 != null && value3 != null && value4 != null && value1 != null)
                {
                    weight = Double.Parse(value1.ToString());
                    number = Double.Parse(value4.ToString());
                    price = Double.Parse(value2.ToString());

                    // Perform calculations only if all cells have data
                    if (number > 0)
                    {
                        double result1 = (weight  * price);
                        // data.Rows[e.RowIndex].Cells[0].Value = result1;

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
                        textBox3.Text = total18.ToString();
                        textBox4.Text = total24.ToString();

                    }
                }
            }


        }
       
 
        private void label35_Click(object sender, EventArgs e)
        {

        }
    }
}
