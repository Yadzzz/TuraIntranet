using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.PriceList
{
    public class ViewTempPrisListExportSsr
    {
        public string Customer { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Item { get; set; } = null!;
        public string? Description { get; set; }
        public string? Description2 { get; set; }
        public string ProdGroupCode { get; set; } = null!;
        public string? ProdGroupCodeDescrip { get; set; }
        public string? ItemCategoryCode { get; set; }
        public string? ItemCategoryDescrip { get; set; }
        public string VendorNo { get; set; } = null!;
        public string? VendorName { get; set; }
        public string VendorItemNo { get; set; } = null!;
        public string Gtin { get; set; } = null!;
        public string? CurrencyCode { get; set; }
        public decimal? FeeSum { get; set; }
        public string ActivityCode { get; set; } = null!;
        public decimal? SalesPrice { get; set; }
        public decimal? LineDiscountPerc { get; set; }
        public decimal? PriceGroupRek { get; set; }
        public byte? SalesPriceAllowLineDisc { get; set; }
        public string ManufactureName { get; set; } = null!;
        public string ItemDiscountGroup { get; set; } = null!;
        public string? WipCat1 { get; set; }
        public string? WipCat2 { get; set; }
        public string? WipCat3 { get; set; }
        public int ItemType { get; set; }
    }
}
