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

namespace test_printing
{
    public partial class BillBuy : UserControl
    {
        public AppDbContext _context = new AppDbContext();
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
        public BillBuy()
        {
            InitializeComponent();
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
            data.Columns[0].Width = columnHeaderWidth + 4;
            data.Columns[1].Width = columnHeaderWidth + 4;
            data.Columns[2].Width = columnHeaderWidth + 3;
            data.Columns[3].Width = columnHeaderWidth + 3;
            data.Columns[4].Width = columnHeaderWidth + 3;
            data.Columns[5].Width = columnHeaderWidth + 3;
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                _context.Database.EnsureCreated();

                var lastBill = _context.Bills.AsEnumerable().LastOrDefault();
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

            SetColumnWidths();
            LoadDataFromDatabase();
        }
        public void btn_print(int width, int height)
        {
            SaveToDB();
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += printDocument1_PrintPage;

            PrintPreviewDialog printDialog = new PrintPreviewDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            data.ClearSelection();
            this.Height = this.Height;
            int headerHeight = Header.Height;
            int row1Height = Panelrow1.Height;
            int row2Height = Panelrow2.Height;
            int yOffset = e.MarginBounds.Top;

            int dataGridViewHeight = data.PreferredSize.Height;
            int textBoxHeight = promise.PreferredSize.Height;

            // Calculate the maximum number of rows that can fit on a page
            maxRowsPerPage += 10;// (e.MarginBounds.Height - headerHeight - row1Height - row2Height - dataGridViewHeight) / data.Rows[0].Height;

            // Print header panel
            yOffset += headerHeight;

            // Print row1 panel
            yOffset += row1Height;

            // Print row2 panel
            yOffset += row2Height;

            // Print DataGridView rows
            while (currentPrintRow < data.Rows.Count && currentPrintRow < maxRowsPerPage)
            {
                DataGridViewRow row = data.Rows[currentPrintRow];
                // Adjust the positions based on your layout
                yOffset += row.Height;
                currentPrintRow++;
            }
            Bitmap dataGridViewBitmap = new Bitmap(data.Width, dataGridViewHeight);

            data.DrawToBitmap(dataGridViewBitmap, new Rectangle(0, 0, data.Width, 15 * 24 + data.ColumnHeadersHeight + 396 * (maxRowsPerPage / 10 - 1)));
            e.Graphics.DrawImage(dataGridViewBitmap, e.MarginBounds.Left - 20, 348 - 396 * (maxRowsPerPage / 10 - 1), e.MarginBounds.Width + 60, dataGridViewHeight);
            DrawPanelToGraphics(new Panel(), e.Graphics, e.MarginBounds.Left - 20, 0, e.MarginBounds.Width + 60, 20);
            DrawPanelToGraphics(Header, e.Graphics, e.MarginBounds.Left - 20, 20, e.MarginBounds.Width + 60, headerHeight);
            DrawPanelToGraphics(Panelrow1, e.Graphics, e.MarginBounds.Left - 20, 276, e.MarginBounds.Width + 60, row1Height);
            DrawPanelToGraphics(Panelrow2, e.Graphics, e.MarginBounds.Left - 20, 312, e.MarginBounds.Width + 60, row2Height);



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
          DrawPanelToGraphics(promise,e.Graphics, e.MarginBounds.Left - 20, yOffset, e.MarginBounds.Width+60, promise.Height);
            // No more pages
            e.HasMorePages = false;



        }

        private void DrawPanelToGraphics(Panel panel, Graphics graphics, int x, int y, int width, int height)
        {
            Bitmap panelBitmap = new Bitmap(panel.Width, panel.Height);

            panel.DrawToBitmap(panelBitmap, new Rectangle(0, 0, panel.Width, panel.Height));
            graphics.DrawImage(panelBitmap, x, y, width, height);
        }
        private void ResizeUserControl()
        {
            int newHeight;
            // Calculate new height based on the content of TextBox and DataGridView
            if (data.Height > data.PreferredSize.Height)
                newHeight = Header.Height + Panelrow1.Height + Panelrow2.Height + promise.Height + data.Height;
            else
                newHeight = Header.Height + Panelrow1.Height + Panelrow2.Height + promise.Height + data.PreferredSize.Height;

            // Set the new size for the UserControl
            this.Size = new Size(this.Width, newHeight);
            this.AutoScroll
                = true;
        }

        private void data_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ResizeUserControl();
        }
        public int SaveToDB()
        {
            Bills NewBill = new Bills();
            List<BillData> Data = new List<BillData>();
            BillData DataRow = new BillData();
            NewBill.CustomerName = CustName.Text;
            // NewBill.Id = Int32.Parse(BillNum.Text);
            NewBill.IsBuy = true;
            NewBill.Notes = "";
            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.Index == data.RowCount - 1) continue;
                DataRow.Price = Double.Parse(row.Cells[1].Value.ToString() + "." + row.Cells[0].Value.ToString());
                DataRow.Weight = Double.Parse(row.Cells[3].Value.ToString() + "." + row.Cells[2].Value.ToString());
                DataRow.Type = Double.Parse(row.Cells[5].Value.ToString() + "." + row.Cells[4].Value.ToString());
                DataRow.Kyrat = Int32.Parse(row.Cells[6].Value.ToString());
                DataRow.Number = Int32.Parse(row.Cells[7].Value.ToString());
                DataRow.Name = row.Cells[8].Value.ToString();

                Data.Add(DataRow);
            }
            NewBill.Data = Data;

          
            _context.BillData.AddRange(Data);
            _context.Bills.Add(NewBill);
            _context.SaveChanges();




            return 0;
        }
    }
}
