using System.ComponentModel.DataAnnotations;

namespace TuraIntranet.Models
{
    public class AddShipmentModel
    {
        [Required]
        public string? Supplier { get; set; }
    }
}
