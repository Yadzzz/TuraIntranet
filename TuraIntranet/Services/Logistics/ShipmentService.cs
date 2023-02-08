using System.Runtime.CompilerServices;
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

        public async Task<ShipmentModel?> GetShipment(int id)
        {
            return await this._shipmentsManager.GetShipment(id);
        }

        public void UpdateShipment(ShipmentModel shipment)
        {
            Task.Run(() => this._shipmentsManager.UpdateShipment(shipment));
        }

        public void AddUpdate(ShipmentUpdateData shipmentUpdateData)
        {
            Task.Run(() => this._shipmentsManager.AddUpdate(shipmentUpdateData));
        }

        public void AddShipment(ShipmentModel shipment)
        {
            Task.Run(() => this._shipmentsManager.AddShipment(shipment));
        }

        public async Task<List<ShipmentEmployee>?> GetShipmentEmployees(bool showAll = false)
        {
            return await this._shipmentsManager.GetShipmentEmployees(showAll);
        }

        public async Task UpdateShipmentEmployee(ShipmentEmployee shipmentEmployee)
        {
            await this._shipmentsManager.UpdateShipmentEmployee(shipmentEmployee);
        }

        public string GetShipmentEmployee(int id)
        {
            return this._shipmentsManager.GetShipmentEmployee(id);
        }

        public void AddShipmentEmployee(ShipmentEmployee employee)
        {
            Task.Run(() => this._shipmentsManager.AddShipmentEmployee(employee));
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

        public void RemoveShipment(ShipmentModel shipmentModel)
        {
            this._shipmentsManager.RemoveShipment(shipmentModel);
        }

        public void FlushShipments()
        {
            this._shipmentsManager.FlushShipments();
        }

        public void FlushShipmentEmployees()
        {
            this._shipmentsManager.FlushShipmentEmployees();
        }

        public Task AddDeviation(ShipmentDeviationData deviation)
        {
            return this._shipmentsManager.AddDeviation(deviation);
        }

        public Task UpdateDeviation(ShipmentDeviationData deviation)
        {
            return this._shipmentsManager.UpdateDeviation(deviation);
        }
    }
}
