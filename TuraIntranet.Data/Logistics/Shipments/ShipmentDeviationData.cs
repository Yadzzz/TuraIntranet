using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Logistics.Shipments
{
    public class ShipmentDeviationData
    {
        public int ShipmentId { get; set; }
        public bool? DamagedGoods { get; set; }
        public bool? AcceptablePallets { get; set; }
        public bool? CorrectPalletHeight { get; set; }
        public bool? HasDeliveryNote { get; set; }
        public bool? OrderNumberOnDeliveryNote { get; set; }
        public bool? ConcealedFreigtDamage { get; set; }
        public bool? DeliveryNoteDeviations { get; set; }
        public bool? SortedBoxwise { get; set; }
        public bool? TaggedMixedBoxes { get; set; }
        public string? Note { get; set; }
    }
}
