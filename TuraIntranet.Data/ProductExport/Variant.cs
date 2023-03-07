using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.ProductExport
{
    public class Variant
    {
        public string Id { get; set; }
        public string SystemId { get; set; }
        public Guid BaseProductSystemId { get; set; }
    }
}
