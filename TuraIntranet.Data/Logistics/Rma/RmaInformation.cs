using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Logistics.Rma
{
    public class RmaInformation
    {
        public int Id { get; set; }

        public string ItemNumber { get; set; } = null!;

        public string? Rmainfo { get; set; }
    }
}
