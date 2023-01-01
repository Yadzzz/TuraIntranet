using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.API;

namespace TuraIntranet.Data.Logistics.Shipments
{
    public class ShipmentsManager
    {
        private List<ShipmentModel> _shipments { get; set; }
        private List<ShipmentEmployee>? _shipmentEmployees { get; set; }
        private List<ShipmentReceivingCompany>? _shipmentReceivingCompanies { get; set; }
        private List<ShipmentStatus>? _shipmentStatuses { get; set; }

        public ShipmentsManager()
        {
            Task.Run(async () =>
            {
                this._shipmentEmployees = await this.GetShipmentEmployees();
            });

            Task.Run(async () =>
            {
                this._shipmentReceivingCompanies = await this.GetShipmentReceivingCompanies();
            });

            Task.Run(async () =>
            {
                this._shipmentStatuses = await this.GetShipmentStatuses();
            });
        }

        public async Task<List<ShipmentModel>?> GetShipments()
        {
            if (this._shipments != null)
            {
                return this._shipments;
            }

            APIRequest api = new APIRequest("https://localhost:7245/api/v1/intranet/logistics/shipments/Shipments");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    this._shipments = JsonConvert.DeserializeObject<List<ShipmentModel>>(response.Content);

                    return this._shipments;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public ShipmentModel? GetShipment(int id)
        {
            return this._shipments.Where(x => x.Shipment.Id == id).FirstOrDefault();
        }

        public async Task<List<ShipmentEmployee>?> GetShipmentEmployees()
        {
            if (this._shipmentEmployees != null)
            {
                return this._shipmentEmployees;
            }

            APIRequest api = new APIRequest("https://localhost:7245/api/v1/intranet/logistics/shipments/ShipmentEmployee");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<ShipmentEmployee>? employees = JsonConvert.DeserializeObject<List<ShipmentEmployee>>(response.Content);

                    return employees;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public string GetShipmentEmployee(int id)
        {
            if (this._shipmentEmployees != null)
            {
                var employeeData = this._shipmentEmployees.Where(x => x.Id == id).FirstOrDefault();
                return employeeData != null ? (employeeData.FirstName + " " + employeeData.LastName) : string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<List<ShipmentReceivingCompany>?> GetShipmentReceivingCompanies()
        {
            if (this._shipmentReceivingCompanies != null)
            {
                return this._shipmentReceivingCompanies;
            }

            APIRequest api = new APIRequest("https://localhost:7245/api/v1/intranet/logistics/shipments/ShipmentReceivingCompany");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<ShipmentReceivingCompany>? companies = JsonConvert.DeserializeObject<List<ShipmentReceivingCompany>>(response.Content);

                    return companies;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public string GetShipmentReceivingCompany(int id)
        {
            if (this._shipmentReceivingCompanies != null)
            {
                var company = this._shipmentReceivingCompanies.Where(x => x.Id == id).FirstOrDefault();

                return company != null && company.Name != null ? company.Name : string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<List<ShipmentStatus>?> GetShipmentStatuses()
        {
            if (this._shipmentStatuses != null)
            {
                return this._shipmentStatuses;
            }

            APIRequest api = new APIRequest("https://localhost:7245/api/v1/intranet/logistics/shipments/ShipmentStatus");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<ShipmentStatus>? status = JsonConvert.DeserializeObject<List<ShipmentStatus>>(response.Content);

                    return status;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public string GetShipmentStatus(int id)
        {
            if (this._shipmentStatuses != null)
            {
                var statusData = this._shipmentStatuses.Where(x => x.Id == id).FirstOrDefault();

                return statusData != null && statusData.StatusName != null ? statusData.StatusName : string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
