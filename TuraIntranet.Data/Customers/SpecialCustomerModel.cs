using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Customers
{
    public class SpecialCustomerModel
    {
        public int Id { get; set; }
        public string CustomerNumber { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? Instructions { get; set; }
        public string? ResponsibleSalesPerson { get; set; }
        public string? SalesPersonPhone { get; set; }
    }
}
