using TuraIntranet.Data.Logistics.Shipments;

namespace TuraIntranet.Services.Logistics
{
    public class ShipmentService
    {
        private ShipmentsManager _shipmentsManager { get; set; }

        public ShipmentService()
        {
            this._shipmentsManager = new ShipmentsManager();
        }

        public async Task<List<ShipmentModel>?> GetShipments()
        {
            return await this._shipmentsManager.GetShipments();
        }

        public ShipmentModel? GetShipment(int id)
        {
            return this._shipmentsManager.GetShipment(id);
        }

        public void UpdateShipment(ShipmentModel shipment)
        {
            Task.Run(() => this._shipmentsManager.UpdateShipment(shipment));
        }

        public void AddUpdate(ShipmentUpdateData shipmentUpdateData)
        {
            Task.Run(() => this._shipmentsManager.AddUpdate(shipmentUpdateData));
        }

        public async Task<List<ShipmentEmployee>?> GetShipmentEmployees()
        {
            return await this._shipmentsManager.GetShipmentEmployees();
        }

        public string GetShipmentEmployee(int id)
        {
            return this._shipmentsManager.GetShipmentEmployee(id);
        }

        public async Task<List<ShipmentReceivingCompany>?> GetShipmentReceivingCompanies()
        {
            return await this._shipmentsManager.GetShipmentReceivingCompanies();
        }

        public string GetShipmentReceivingCompany(int id)
        {
            return this._shipmentsManager.GetShipmentReceivingCompany(id);
        }

        public async Task<List<ShipmentStatus>?> GetShipmentStatuses()
        {
            return await this._shipmentsManager.GetShipmentStatuses();
        }

        public string GetShipmentStatus(int id)
        {
            return this._shipmentsManager.GetShipmentStatus(id);
        }
    }
}
