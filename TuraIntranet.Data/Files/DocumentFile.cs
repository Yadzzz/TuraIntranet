using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TuraIntranet.Data.Files
{
    public class DocumentFile
    {
        public string Name { get; set; }
        public decimal Size { get; set; }
        public string Type { get; set; }
        public string path { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
    }
}
