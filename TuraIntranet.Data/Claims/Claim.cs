using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Claims
{
    public class Claim
    {
        public int Id { get; set; }

        public bool InvoiceFromCustomer { get; set; }

        public string? InvoiceFromCustomerReference { get; set; }

        public bool CreditToCustomer { get; set; }

        public string? CreditToCustomerReference { get; set; }

        public bool InvoiceToSupplier { get; set; }

        public string? InvoiceToSupplierReference { get; set; }

        public bool CreditFromSupplier { get; set; }

        public string? CreditFromSupplierReference { get; set; }

        public decimal? AmountIn { get; set; }

        public int? CurrencyIn { get; set; }

        public decimal? AmountOut { get; set; }

        public int? CurrencyOut { get; set; }

        public string TuraContactPerson { get; set; } = null!;

        public string CustomerContactPerson { get; set; } = null!;

        public string Customer { get; set; } = null!;

        public string? CustomerNumber { get; set; }

        public DateTime Date { get; set; }

        public string Supplier { get; set; } = null!;

        public string Subject { get; set; } = null!;

        public bool Completed { get; set; }
    }
}
