using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Customers
{
    public class CustomerModel
    {
        public byte[] Timestamp { get; set; } = null!;

        public string No { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string SearchName { get; set; } = null!;

        public string Name2 { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Address2 { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Contact { get; set; } = null!;

        public string PhoneNo { get; set; } = null!;

        public string TerritoryCode { get; set; } = null!;

        public string ChainName { get; set; } = null!;

        public string? ChainCoded { get; set; }

        public decimal CreditLimitLcy { get; set; }

        public string CurrencyCode { get; set; } = null!;

        public string CustomerPriceGroup { get; set; } = null!;

        public string PaymentTermsCode { get; set; } = null!;

        public string ShipmentMethodCode { get; set; } = null!;

        public string CustomerDiscGroup { get; set; } = null!;

        public string CountryRegionCode { get; set; } = null!;

        public int Blocked { get; set; }

        public string BillToCustomerNo { get; set; } = null!;

        public byte PricesIncludingVat { get; set; }

        public string FaxNo { get; set; } = null!;

        public string VatRegistrationNo { get; set; } = null!;

        public string PostCode { get; set; } = null!;

        public string EMail { get; set; } = null!;

        public byte AllowLineDisc { get; set; }

        public string Ordertype { get; set; } = null!;

        public string? FeeCustomerGroupCode { get; set; }

        public int PricelistInterval { get; set; }

        public string Eancode { get; set; } = null!;

        public string TelexNo { get; set; } = null!;

        public string HomePage { get; set; } = null!;

        public byte? WebShop { get; set; }

        public byte? LesWire { get; set; }

        public string? ShipToCode { get; set; }
    }
}
