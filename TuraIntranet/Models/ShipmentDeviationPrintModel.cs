namespace TuraIntranet.Models
{
    public class ShipmentDeviationPrintModel
    {
        public string Supplier { get; set; }
        public string ShipmentCompany { get; set; }
        public string DeliveryDate { get; set; }
        public string ResponsibleConsigneeEmployee { get; set; }
        public string OrderNumbers { get; set; }
        public string ReceivedAt { get; set; }
        public bool SignedByShipmentLabel { get; set; }
        public bool SignedVisDosa { get; set; }
        public string ResponsibleSorageEmloyee { get; set; }
        public string PartDelivery { get; set; }
    }
}
