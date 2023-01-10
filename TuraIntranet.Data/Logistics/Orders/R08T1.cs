using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Logistics.Orders
{
    public class R08T1
    {
        public string routeno { get; set; }
        public DateTime regdate { get; set; }
        public short tripstat { get; set; }
        public int noordl { get; set; }
        public int norordl { get; set; }
        public int nopordl { get; set; }
    }
}
