using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Logistics.Shipments
{
    public class ShipmentModel
    {
        public ShipmentData? Shipment { get; set; }
        public ShipmentDeviationData? ShipmentDeviation { get; set; }
        public ShipmentUpdateData? ShipmentUpdate { get; set; }
        public List<ShipmentUpdateData>? ShipmentUpdates { get; set; }
    }
}
