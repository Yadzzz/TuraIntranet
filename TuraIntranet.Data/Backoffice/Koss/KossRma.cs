using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuraIntranet.Data.Backoffice.Koss
{
    public class KossRma
    {
        public int Id { get; set; }

        public int KossModelId { get; set; }

        public string ProblemDescription { get; set; } = null!;

        public string Vendor { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? CoAddress { get; set; }

        public string StreetAddress { get; set; } = null!;

        public string Zipcode { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? Phone { get; set; }

        public string Email { get; set; } = null!;

        public DateTime Date { get; set; }

        public bool Finished { get; set; }

        public string Receipt { get; set; } = null!;

        public string? CustomReply { get; set; }

        public int? ReplyMessageId { get; set; }

        public DateTime? ReplyDate { get; set; }

        public string Country { get; set; } = null!;
    }
}
