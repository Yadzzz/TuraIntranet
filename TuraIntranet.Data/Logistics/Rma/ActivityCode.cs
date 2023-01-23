using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Logistics.Rma
{
    public class ActivityCode
    {
        public byte[] Timestamp { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
