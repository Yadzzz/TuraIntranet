using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Logistics.Rma
{
    public class RmaItem
    {
        public string No_ { get; set; }
        public string Description { get; set; }
        public string Description_2 { get; set; }
        public string Vendor_Item_No_ { get; set; }
        public string Primary_EAN_Code { get; set; }
        public string? Manufacturer_Code { get; set; }
        public string? Activity_Code { get; set; }
        public string? Vendor_Name { get; set; }
    }
}
