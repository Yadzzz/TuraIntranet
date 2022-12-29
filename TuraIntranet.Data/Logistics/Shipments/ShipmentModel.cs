using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Logistics.Shipments
{
    public class ShipmentModel
    {
        public Shipment? Shipment { get; set; }
        public ShipmentDeviation? ShipmentDeviation { get; set; }
        public ShipmentUpdate? ShipmentUpdate { get; set; }
    }
}
