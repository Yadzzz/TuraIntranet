using TuraIntranet.Data.Logistics.Shipments;

namespace TuraIntranet.Services.Logistics
{
    public class ShipmentService
    {
        public async Task<List<ShipmentModel>?> GetShipments()
        {
            return await new ShipmentsManager().GetShipments();
        }
    }
}
