using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Logistics.Rma
{
    public class L62T1
    {
        public string? partno { get; set; }
        public string? divcode { get; set; }
        public string? pmha { get; set; }
        public string? wmha { get; set; }
        public string? wldct { get; set; }
        public decimal baltot { get; set; }
        public decimal balnotav { get; set; }
        public DateTime regdate { get; set; }
        public DateTime upddate { get; set; }
        public decimal balpl { get; set; }

    }
}
