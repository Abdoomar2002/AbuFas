using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_printing;
using System.Text.RegularExpressions;


namespace AbuFas.Control
{
    public partial class inventory : UserControl
    {
        private DateTime fromDate, toDate;
        public inventory()
        {
            InitializeComponent();
            start.MaxDate=DateTime.Now;
            end.MaxDate=DateTime.Now;
            
        }
        public void load(DateTime startDate,DateTime endDate) 
        {
            fromDate = startDate;
            toDate =endDate;
            var TotalBuy = Program._context.Bills.Where(c => c.IsBuy == true&&c.Date>=startDate&&c.Date<=endDate).Sum(c => c.Total);
            var TotalSold = Program._context.Bills.Where(c => c.IsBuy == false && c.Date >= startDate && c.Date <= endDate).Sum(c => c.Total);
            var TotalBuy21 =Program._context.BillData.Where(c => c.Kyrat == 21 && c.Bill.Date >= startDate && c.Bill.Date <= endDate &&c.Bill.IsBuy).Sum(c => c.Weight);
            var TotalBuy18 =Program._context.BillData.Where(c => c.Kyrat == 18 && c.Bill.Date >= startDate && c.Bill.Date <= endDate && c.Bill.IsBuy).Sum(c => c.Weight);
            var TotalBuy24 =Program._context.BillData.Where(c => c.Kyrat == 24 && c.Bill.Date >= startDate && c.Bill.Date <= endDate && c.Bill.IsBuy).Sum(c => c.Weight);
            var TotalSell21 = Program._context.BillData.Where(c => c.Kyrat == 21 && c.Bill.Date >= startDate && c.Bill.Date <= endDate && !c.Bill.IsBuy).Sum(c => c.Weight);
            var TotalSell18 = Program._context.BillData.Where(c => c.Kyrat == 18 && c.Bill.Date >= startDate && c.Bill.Date <= endDate && !c.Bill.IsBuy).Sum(c => c.Weight);
            var TotalSell24 = Program._context.BillData.Where(c => c.Kyrat == 24 && c.Bill.Date >= startDate && c.Bill.Date <= endDate && !c.Bill.IsBuy).Sum(c => c.Weight);
            var income = Program._context.IncomeOutcome.Where(c => c.Date >= startDate && c.Date <= endDate&&c.IsIncome).Sum(c => c.Price);
            var outcome = Program._context.IncomeOutcome.Where(c => c.Date >= startDate && c.Date <= endDate&&!c.IsIncome).Sum(c => c.Price);
          
            //sell
            sell.Text=TotalSold.ToString();
            sell18.Text=TotalSell18.ToString();
            sell21.Text=TotalSell21.ToString();
            sell24.Text=TotalSell24.ToString();
            totalgramsSell.Text=Math.Round((TotalSell18*18+TotalSell24*24)/21+TotalSell21,3).ToString();
            //buy
            buy.Text = TotalBuy.ToString();
            buy18.Text=TotalBuy18.ToString();
            buy21.Text=TotalBuy21.ToString();
            buy24.Text=TotalBuy24.ToString();
            totalgramsBuy.Text= Math.Round((TotalBuy18 * 18 + TotalBuy24 * 24) / 21 + TotalBuy21,3).ToString();

            //incoume outcome
            inc.Text=income.ToString();
            outc.Text=outcome.ToString();

        }

        private void inventory_Load(object sendDateer, EventArgs e)
        {
            Home home = (Home)ParentForm;
          
            load(home.start.Value,home.end.Value);
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            
            var items=Program._context.IncomeOutcome.Where(c=>c.Name.Contains(search.Text)&&c.Date>=start.Value&&c.Date<=end.Value&&c.IsIncome==false).Sum(c=>c.Price);
            if (items != null)
            {
                result.Text = items.ToString();
            }
            else result.Text = "0";
        }
        private string CleanFileName(string fileName)
        {
            // Remove any characters that are not allowed in file names
            return Regex.Replace(fileName, @"[\/:*?""<>|]", "-");
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {

            // Clean the dates from invalid characters
            string cleanedFromDate = CleanFileName(fromDate.ToString("dd/MM/yyyy"));
            string cleanedToDate = CleanFileName(toDate.ToString("dd/MM/yyyy"));

            // Initialize the SaveFileDialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Set filter and default file name
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";
                saveFileDialog.FileName = $"from {cleanedFromDate} to {cleanedToDate}.xlsx";

                // Show the Save File Dialog
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the custom path from the dialog
                    string filePath = saveFileDialog.FileName;
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    // Create the Excel file using EPPlus
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        // Add a new worksheet to the empty workbook
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add($"from {cleanedFromDate} to {cleanedToDate}");

                        // Add headers in Arabic
                        worksheet.Cells[ 1,1].Value = "شراء";
                        worksheet.Cells[ 2,1].Value = "جرامات";
                        worksheet.Cells[3, 1].Value = "جرام 18";
                        worksheet.Cells[4, 1].Value = "جرام 21";
                        worksheet.Cells[5, 1].Value = "جرام 24";
                        worksheet.Cells [7, 1].Value = "بيع";
                        worksheet.Cells[8, 1].Value = "جرامات";
                        worksheet.Cells[9, 1].Value = "جرام 18";
                        worksheet.Cells[10, 1].Value = "جرام 21";
                        worksheet.Cells[11, 1].Value = "جرام 24";
                        worksheet.Cells[13, 1].Value = "مصاريف متنوعة";
                        worksheet.Cells[ 14,1].Value = "وارد نقدية";

                        // Add example data rows
                      
                            worksheet.Cells[1, 2].Value = buy.Text; // Cash inflows
                            worksheet.Cells[2, 2].Value = totalgramsBuy.Text; // Example purchase data
                            worksheet.Cells[3, 2].Value = buy18.Text; // Example sale data
                            worksheet.Cells[4, 2].Value = buy21.Text; // Example grams data
                            worksheet.Cells[5, 2].Value = buy24.Text;
                            worksheet.Cells[7, 2].Value = sell.Text;
                            worksheet.Cells[8, 2].Value = totalgramsSell.Text; // Example 21 carats data
                            worksheet.Cells[9, 2].Value = sell18.Text;
                            worksheet.Cells[10, 2].Value = sell21.Text; // Example 24 carats data
                            worksheet.Cells[ 11,2].Value = sell24.Text;
                            worksheet.Cells[ 13,2].Value = outc.Text; // Miscellaneous expenses
                            worksheet.Cells[ 14,2].Value = inc.Text; // Example 18 carats data


                        // Adjust column widths for readability
                        worksheet.Columns[1].Width = 30;
                        worksheet.Columns[2].Width = 30;
                        // Center align all cells
                        worksheet.Cells[1, 1, 14, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells[1, 1, 14, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        try
                        {

                            FileInfo fi = new FileInfo(filePath);
                            if (fi.Exists) fi.Delete();
                            package.SaveAs(fi);

                            MessageBox.Show($"تم حفظ الملف في المسار الاتي  \n{filePath}");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message );
                        }
                        // Save the package at the chosen file path
                    }
                }
            }
            }
    }
}
