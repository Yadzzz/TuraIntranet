using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Logistics.Shipments
{
    public class ShipmentUpdate
    {
        public DateTime UpdatedAt { get; set; }
        public int Id { get; set; }
        public int? UpdatedBy { get; set; }
        public int ShipmentId { get; set; }
        public string? Note { get; set; }
        public int StatusId { get; set; }
    }
}
