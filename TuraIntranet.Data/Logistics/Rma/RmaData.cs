using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Logistics.Rma
{
    public class RmaData
    {
        public L62T1 L62T1 { get; set; }
        public RmaItem Item { get; set; }

        public RmaData()
        {

        }

        public RmaData(L62T1 l62T1, RmaItem item)
        {
            this.L62T1 = l62T1;
            this.Item = item;
        }
    }
}
