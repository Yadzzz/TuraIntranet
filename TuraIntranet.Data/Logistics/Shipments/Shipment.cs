using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Logistics.Shipments
{
    public class Shipment
    {
        public int Id { get; set; }
        public DateTime ReceivedAt { get; set; }
        public int? ReceivedBy { get; set; }
        public int? ReceivingCompany { get; set; }
        public string? OrderNumbers { get; set; }
        public int? NumberOfPallets { get; set; }
        public int? NumberOfPackages { get; set; }
        public string? Placement { get; set; }
        public int? InitatedBy { get; set; }
        public string? Supplier { get; set; }
        public bool? Prioritized { get; set; }
    }
}
