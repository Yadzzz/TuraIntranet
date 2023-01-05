using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Info
{
    public class InfoMessageModel
    {
        public int Id { get; set; }
        public string? Header { get; set; }
        public string? Message { get; set; }
        public string? FontColor { get; set; }
        public string? BackgroundColor { get; set; }
        public bool? Active { get; set; }
        public DateTime Updated { get; set; }
    }
}
