using OfficeOpenXml;
using TuraIntranet.Data.PriceList;

namespace TuraIntranet.Services.PriceList
{
    public class PriceListService
    {
        private PriceListManager _priceListManager;

        public PriceListService()
        {
            this._priceListManager = new PriceListManager();
        }

        public Task<List<ViewTempPrisListExportSsr>?> GetPriceList(string customerNo, string vendorNo, string itemCategoryCode)
        {
            return this._priceListManager.GetPriceList(customerNo, vendorNo, itemCategoryCode);
        }

        public string GetActivityCodeDescription(string activityCode)
        {
            switch (activityCode)
            {
                case "1":
                    return "Active";
                case "2":
                    return "New";
                case "3":
                    return "Campaign";
                case "4":
                    return "PreOrder";
                case "5":
                    return "Discontinued";
                case "6":
                    return "Discontinued";
                case "7":
                    return "EndOfLife";
                case "8":
                    return "Discontinued";
                default:
                    return "";
            }
        }

        public MemoryStream CreateExcelStream(string customerNo, string customerName, string vendorNo, string vendorName, List<ViewTempPrisListExportSsr> priceListData)
        {
            MemoryStream stream = new MemoryStream();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo("MyWorkbook.xlsx")))
            {
                using (ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1"))
                {
                    worksheet.Row(1).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Row(1).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    worksheet.Row(1).Style.Font.Bold = true;
                    worksheet.Row(1).Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                    worksheet.Row(2).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Row(2).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    worksheet.Row(2).Style.Font.Bold = true;
                    worksheet.Row(2).Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;


                    worksheet.Row(3).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Row(3).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    worksheet.Row(3).Style.Font.Bold = true;
                    worksheet.Row(3).Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                    var firstRow = priceListData.FirstOrDefault();

                    worksheet.Cells[3, 1].Value = "Item Category";
                    worksheet.Cells[3, 2].Value = "Prod Group";
                    worksheet.Cells[3, 3].Value = "Item No";
                    worksheet.Cells[3, 4].Value = "Vendor Item No";
                    worksheet.Cells[3, 5].Value = "Description";
                    worksheet.Cells[3, 6].Value = "GTIN";
                    worksheet.Cells[3, 7].Value = "SRP " + this.GetCurrencyCode(firstRow?.CurrencyCode);
                    worksheet.Cells[3, 8].Value = "Sales Price " + this.GetCurrencyCode(firstRow?.CurrencyCode);
                    worksheet.Cells[3, 9].Value = "Discount %";
                    worksheet.Cells[3, 10].Value = "Your price " + this.GetCurrencyCode(firstRow?.CurrencyCode);
                    worksheet.Cells[3, 11].Value = "Fee Sum";
                    worksheet.Cells[3, 12].Value = "ActivityCode";

                    int row = 4;
                    foreach (var data in priceListData)
                    {
                        int collumn = 1;
                        worksheet.Cells[row, collumn++].Value = data.ItemCategoryDescrip;
                        worksheet.Cells[row, collumn++].Value = data.ProdGroupCodeDescrip;
                        worksheet.Cells[row, collumn++].Value = data.Item;
                        worksheet.Cells[row, collumn++].Value = data.VendorItemNo;
                        worksheet.Cells[row, collumn++].Value = (data.Description + " " + data.Description2);
                        worksheet.Cells[row, collumn++].Value = data.Gtin;
                        worksheet.Cells[row, collumn++].Value = (data.PriceGroupRek != null ? Math.Round(double.Parse(data.PriceGroupRek.ToString()), 2) : 0.00);
                        worksheet.Cells[row, collumn++].Value = (data.SalesPrice != null ? Math.Round(double.Parse(data.SalesPrice.ToString()), 2) : 0.00);
                        worksheet.Cells[row, collumn++].Value = (data.SalesPriceAllowLineDisc == 0 || data.LineDiscountPerc == null ? "" : Math.Round(double.Parse(data.LineDiscountPerc.ToString())));
                        worksheet.Cells[row, collumn++].Value = (data.SalesPriceAllowLineDisc == 0 || data.LineDiscountPerc == null ? data.SalesPrice : Math.Round(double.Parse((data.SalesPrice - (data.SalesPrice * (data.LineDiscountPerc / 100))).ToString()), 2));
                        worksheet.Cells[row, collumn++].Value = data.FeeSum;
                        worksheet.Cells[row, collumn++].Value = this.GetActivityCodeDescription(data.ActivityCode);

                        row++;
                    }


                    //worksheet.Cells.AutoFitColumns();
                    //worksheet.Column(1).Width = 27;
                    //worksheet.Column(2).Width = 35;
                    //worksheet.Column(3).Width = 15;
                    //worksheet.Column(4).Width = 30;
                    //worksheet.Column(5).Width = 65;
                    //worksheet.Column(6).Width = 20;

                    //worksheet.Column(1).Width = 25;
                    worksheet.Column(1).AutoFit();
                    worksheet.Column(2).AutoFit();
                    worksheet.Column(3).AutoFit();
                    worksheet.Column(4).AutoFit();
                    worksheet.Column(5).AutoFit();
                    worksheet.Column(6).AutoFit();
                    worksheet.Column(7).AutoFit();
                    worksheet.Column(8).AutoFit();
                    worksheet.Column(9).AutoFit();
                    worksheet.Column(10).AutoFit();
                    worksheet.Column(11).AutoFit();
                    worksheet.Column(12).AutoFit();

                    worksheet.Column(1).Width += 5;
                    worksheet.Column(2).Width += 5;
                    worksheet.Column(3).Width += 5;
                    worksheet.Column(4).Width += 5;
                    worksheet.Column(5).Width += 5;
                    worksheet.Column(6).Width += 5;
                    worksheet.Column(7).Width += 5;
                    worksheet.Column(8).Width += 5;
                    worksheet.Column(9).Width += 5;
                    worksheet.Column(10).Width += 5;
                    worksheet.Column(11).Width += 5;
                    worksheet.Column(12).Width += 5;


                    worksheet.Cells[1, 1].Value = "Tura Scandinavia AB Pricelist for customer: " + customerNo + " - " + customerName + ", dated " + DateTime.Now.ToString("yyyy-MM-dd - HH-mm");
                    worksheet.Cells[2, 1].Value = "Vendor: " + vendorNo + " - " + vendorName;

                    package.SaveAs(stream);
                }
            }

            return stream;
        }

        private string GetCurrencyCode(string? currencyCode)
        {
            return string.IsNullOrEmpty(currencyCode) ? "SEK" : currencyCode;
        }
    }
}
