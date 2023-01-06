using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Networks
{
    public class Network
    {
        public int Id { get; set; }

        public string NetworkName { get; set; } = null!;

        public string? Address { get; set; }

        public string? SubnetAddress { get; set; }

        public string? VlanId { get; set; }

        public ICollection<NetworkIp> NetworkIps { get; set; } = new List<NetworkIp>();
    }
}
