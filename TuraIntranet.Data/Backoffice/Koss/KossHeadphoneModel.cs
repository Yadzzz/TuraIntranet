using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Backoffice.Koss
{
    public class KossHeadphoneModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool Disabled { get; set; }
    }
}
