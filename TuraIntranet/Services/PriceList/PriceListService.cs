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

        public MemoryStream CreateExcelStream(List<ViewTempPrisListExportSsr> priceListData)
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


                    worksheet.Cells[1, 1].Value = "Tura Scandinavia AB Pricelist for customer: 400001 - Scandinavian Photo AB, dated 2023-02-27 - 10:43";

                    worksheet.Cells[2, 1].Value = "Vendor: 1 - Western Digital UK Ltd";

                    worksheet.Cells[3, 1].Value = "Item Category";
                    worksheet.Cells[3, 2].Value = "Prod Group";
                    worksheet.Cells[3, 3].Value = "Item No";
                    worksheet.Cells[3, 4].Value = "Vendor Item No";
                    worksheet.Cells[3, 5].Value = "Description";
                    worksheet.Cells[3, 6].Value = "GTIN";
                    worksheet.Cells[3, 7].Value = "SRP SEK";
                    worksheet.Cells[3, 8].Value = "Sales Price SEK";
                    worksheet.Cells[3, 9].Value = "Discount %";
                    worksheet.Cells[3, 10].Value = "Your price SEK";
                    worksheet.Cells[3, 11].Value = "Fee Sum";
                    worksheet.Cells[3, 12].Value = "ActivityCode";

                    //worksheet.Cells[4, 1].Value = "SANDISK";
                    //worksheet.Cells[4, 2].Value = "SANDISK MEMORY CARD PHOTO";
                    //worksheet.Cells[4, 3].Value = "780137";
                    //worksheet.Cells[4, 4].Value = "SDCFXPS-032G-X46";
                    //worksheet.Cells[4, 5].Value = "SANDISK Minneskort CF Extreme Pro 32GB 160MB/s UDMA7";
                    //worksheet.Cells[4, 6].Value = "619659102432";
                    //worksheet.Cells[4, 7].Value = Math.Round(double.Parse("919"), 2);
                    //worksheet.Cells[4, 8].Value = Math.Round(double.Parse("320,64"), 2);
                    //worksheet.Cells[4, 9].Value = "";
                    //worksheet.Cells[4, 10].Value = Math.Round(double.Parse("320,64"), 2);
                    //worksheet.Cells[4, 11].Value = "";
                    //worksheet.Cells[4, 12].Value = "Active";

                    int row = 4;
                    foreach (var data in priceListData)
                    {
                        Console.WriteLine(row);
                        int collumn = 1;
                        worksheet.Cells[row, collumn++].Value = data.ItemCategoryDescrip;
                        worksheet.Cells[row, collumn++].Value = data.ProdGroupCodeDescrip;
                        worksheet.Cells[row, collumn++].Value = data.Item;
                        worksheet.Cells[row, collumn++].Value = data.VendorItemNo;
                        worksheet.Cells[row, collumn++].Value = (data.Description + " " + data.Description2);
                        worksheet.Cells[row, collumn++].Value = data.Gtin;
                        worksheet.Cells[row, collumn++].Value = data.PriceGroupRek != null ? Math.Round(double.Parse(data.PriceGroupRek.ToString()), 2) : 0.00;
                        worksheet.Cells[row, collumn++].Value = data.SalesPrice != null ? Math.Round(double.Parse(data.SalesPrice.ToString()), 2) : 0.00;
                        worksheet.Cells[row, collumn++].Value = data.SalesPriceAllowLineDisc == 0 || data.LineDiscountPerc == null ? "" : Math.Round(double.Parse(data.LineDiscountPerc.ToString()));
                        worksheet.Cells[row, collumn++].Value = data.SalesPriceAllowLineDisc == 0 || data.LineDiscountPerc == null ? data.SalesPrice : Math.Round(double.Parse((data.SalesPrice - (data.SalesPrice * (data.LineDiscountPerc / 100))).ToString()), 2);
                        worksheet.Cells[row, collumn++].Value = data.FeeSum;
                        worksheet.Cells[row, collumn++].Value = this.GetActivityCodeDescription(data.ActivityCode);

                        //worksheet.Cells[row, collumn++].Value = "SANDISK";
                        //worksheet.Cells[row, collumn++].Value = "SANDISK MEMORY CARD PHOTO";
                        //worksheet.Cells[row, collumn++].Value = "780137";
                        //worksheet.Cells[row, collumn++].Value = "SDCFXPS-032G-X46";
                        //worksheet.Cells[row, collumn++].Value = "SANDISK Minneskort CF Extreme Pro 32GB 160MB/s UDMA7";
                        //worksheet.Cells[row, collumn++].Value = "619659102432";
                        //worksheet.Cells[row, collumn++].Value = Math.Round(double.Parse("919"), 2);
                        //worksheet.Cells[row, collumn++].Value = Math.Round(double.Parse("320,64"), 2);
                        //worksheet.Cells[row, collumn++].Value = "";
                        //worksheet.Cells[row, collumn++].Value = Math.Round(double.Parse("320,64"), 2);
                        //worksheet.Cells[row, collumn++].Value = "";
                        //worksheet.Cells[row, collumn++].Value = "Active";

                        row++;
                    }


                    //worksheet.Cells.AutoFitColumns();
                    //worksheet.Column(1).Width = 27;
                    //worksheet.Column(2).Width = 35;
                    //worksheet.Column(3).Width = 15;
                    //worksheet.Column(4).Width = 30;
                    //worksheet.Column(5).Width = 65;
                    //worksheet.Column(6).Width = 20;
                    worksheet.Column(1).Width = 25;
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

                    package.SaveAs(stream);
                }
            }

            return stream;
        }
    }
}
