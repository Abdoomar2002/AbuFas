using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using test_printing.db;
using UserControl = System.Windows.Forms.UserControl;

namespace test_printing
{
    public partial class bill : UserControl
    {
        public AppDbContext _context=new AppDbContext();
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handle = base.CreateParams;
                handle.ExStyle |= 0x02000000;
                return handle;
            }
        }
        public bill()
        {
            InitializeComponent();
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

        private void bill_Load(object sender, EventArgs e)
        {
            SetColumnWidths();
            Notes.Height=105;
            LoadDataFromDatabase();
        }
        Bitmap bmp;
        public int currentPrintRow = 0;
        public int maxRowsPerPage = 0;
        public void btn_print(int width, int height)
        {

            //  SaveToDB();
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
            data.RowCount=data.RowCount<15?15:data.RowCount;
            data.ClearSelection();
            
            int headerHeight = Header.Height;
            int row1Height = Panelrow1.Height;
            int row2Height = Panelrow2.Height;
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
           
            data.DrawToBitmap(dataGridViewBitmap, new Rectangle(0, 0, data.Width, 15*24+data.ColumnHeadersHeight+396*(maxRowsPerPage/15-1)));
            e.Graphics.DrawImage(dataGridViewBitmap,e.MarginBounds.Left-20,348-396 * (maxRowsPerPage / 15 - 1), e.MarginBounds.Width+60,dataGridViewHeight);
            DrawPanelToGraphics(new Panel(),e.Graphics,e.MarginBounds.Left-20,0,e.MarginBounds.Width+60,20);
            DrawPanelToGraphics(Header, e.Graphics, e.MarginBounds.Left-20, 20, e.MarginBounds.Width + 60, headerHeight);
            DrawPanelToGraphics(Panelrow1, e.Graphics, e.MarginBounds.Left-20, 276, e.MarginBounds.Width + 60, row1Height);
            DrawPanelToGraphics(Panelrow2, e.Graphics, e.MarginBounds.Left-20, 312, e.MarginBounds.Width + 60, row2Height);
           
           
            
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
        }
        private void ResizeUserControl()
        {
            int newHeight;
            // Calculate new height based on the content of TextBox and DataGridView
            if (data.Height>data.PreferredSize.Height)
             newHeight =Header.Height+Panelrow1.Height+Panelrow2.Height+ Notes.Height + data.Height;
            else
                newHeight = Header.Height + Panelrow1.Height + Panelrow2.Height + Notes.Height + data.PreferredSize.Height;

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
            Bills NewBill = new Bills();
           List<BillData> Data = new List<BillData>();
            BillData DataRow = new BillData();
            NewBill.CustomerName = CustName.Text;
           // NewBill.Id = Int32.Parse(BillNum.Text);
            NewBill.IsBuy = false;
            NewBill.Notes =Notes.Text;
            foreach(DataGridViewRow row in data.Rows) 
            {       if (row.Index == data.RowCount-1) continue;
                DataRow.Price = Double.Parse(row.Cells[1].Value.ToString()+"."+row.Cells[0].Value.ToString());
                DataRow.Weight = Double.Parse(row.Cells[3].Value.ToString() + "." + row.Cells[2].Value.ToString());
                DataRow.Type = Double.Parse(row.Cells[5].Value.ToString() + "." + row.Cells[4].Value.ToString());
                DataRow.Kyrat = Int32.Parse(row.Cells[6].Value.ToString());
                DataRow.Number = Int32.Parse(row.Cells[7].Value.ToString());
                DataRow.Name = row.Cells[8].Value.ToString();
                
                Data.Add(DataRow);
            }
            NewBill.Data = Data;
          
            _context.Database.Migrate();
            _context.BillData.AddRange(Data);
            _context.Bills.Add(NewBill);
            _context.SaveChanges();




            return 0;
        }
       
    }
}
