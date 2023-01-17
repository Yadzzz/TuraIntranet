using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Backoffice.Koss
{
    public class KossRmaMessage
    {
        public int Id { get; set; }

        public string Message { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
