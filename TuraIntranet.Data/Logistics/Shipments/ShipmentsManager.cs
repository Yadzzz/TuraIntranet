using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
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
        private Microsoft.Extensions.Logging.ILogger _logger { get; set; }

        private List<ShipmentModel> _shipments { get; set; }
        private List<ShipmentEmployee>? _shipmentEmployees { get; set; }
        private List<ShipmentReceivingCompany>? _shipmentReceivingCompanies { get; set; }
        private List<ShipmentStatus>? _shipmentStatuses { get; set; }

        public ShipmentsManager()
        {
            var loggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder => builder.AddSerilog());
            var logger = loggerFactory.CreateLogger(string.Empty);
            this._logger = logger;

            Task.Run(async () =>
            {
                this._shipmentEmployees = await this.GetShipmentEmployees(true);
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

        public async Task<List<ShipmentModel>?> GetShipments(bool forceFlush = false)
        {
            if (this._shipments != null && !forceFlush)
            {
                return this._shipments;
            }

            APIRequest api = new APIRequest("/api/v1/intranet/logistics/shipments/Shipments");

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
                this._logger.LogError(ex.ToString());
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<ShipmentModel?> GetShipment(int id)
        {
            if (this._shipments == null)
            {
                await this.GetShipments();
            }
            else if(this._shipments.Count == 0)
            {
                await this.GetShipments();
            }

            var shipment = this._shipments.Where(x => x.Shipment.Id == id).FirstOrDefault();

            if(shipment == null)
            {
                APIRequest api = new APIRequest("/api/v1/intranet/logistics/shipments/Shipments/" + id);

                var response = await api.GetResponse();

                try
                {
                    if (response != null && response.Content != null)
                    {
                        var shipmentModel = JsonConvert.DeserializeObject<ShipmentModel>(response.Content);

                        return shipmentModel;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex.ToString());
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
            else
            {
                return shipment;
            }
        }

        public async Task<List<ShipmentEmployee>?> GetShipmentEmployees(bool showAll = false)
        {
            if (this._shipmentEmployees != null)
            {
                if(showAll)
                {
                    return this._shipmentEmployees;
                }

                return this._shipmentEmployees.Where(x => !x.IsDeleted).ToList();
            }

            APIRequest api = new APIRequest("/api/v1/intranet/logistics/shipments/ShipmentEmployeeV2");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<ShipmentEmployee>? employees = JsonConvert.DeserializeObject<List<ShipmentEmployee>>(response.Content);
                    this._shipmentEmployees = employees;
                    
                    if (showAll)
                    {
                        return employees;
                    }

                    return employees.Where(x => !x.IsDeleted).ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task AddShipmentEmployee(ShipmentEmployee shipmentEmployee)
        {
            APIRequest api = new APIRequest("/api/v1/intranet/logistics/shipments/ShipmentEmployeeV2/");
            bool success = await api.SendPostRequest(shipmentEmployee);
        }

        public async Task UpdateShipmentEmployee(ShipmentEmployee shipmentEmployee)
        {
            APIRequest api = new APIRequest("/api/v1/intranet/logistics/shipments/ShipmentEmployeeV2/" + shipmentEmployee.Id);
            bool success = await api.SendPutRequest(shipmentEmployee);
        }

        public async Task UpdateShipment(ShipmentModel shipmentModel)
        {
            APIRequest api = new APIRequest("/api/v1/intranet/logistics/shipments/Shipments/");
            bool success = await api.SendPutRequest(shipmentModel);
        }

        public async Task AddUpdate(ShipmentUpdateData shipmentUpdateData)
        {
            APIRequest api = new APIRequest("/api/v1/intranet/logistics/shipments/ShipmentUpdate/");
            bool success = await api.SendPostRequest(shipmentUpdateData);
        }

        public async Task AddShipment(ShipmentModel shipmentModel)
        {
            APIRequest api = new APIRequest("/api/v1/intranet/logistics/shipments/Shipments/");
            bool success = await api.SendPostRequest(shipmentModel);
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

            APIRequest api = new APIRequest("/api/v1/intranet/logistics/shipments/ShipmentReceivingCompany");

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
                this._logger.LogError(ex.ToString());
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

            APIRequest api = new APIRequest("/api/v1/intranet/logistics/shipments/ShipmentStatus");

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
                this._logger.LogError(ex.ToString());
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

        public void RemoveShipment(ShipmentModel shipmentModel)
        {
            if (this._shipments.Contains(shipmentModel))
            {
                this._shipments.Remove(shipmentModel);
            }
        }
        
        public async Task FlushShipments()
        {
            this._shipments = null;
        }

        public void FlushShipmentEmployees()
        {
            this._shipmentEmployees = null;
        }

        public async Task AddDeviation(ShipmentDeviationData deviation)
        {
            APIRequest api = new APIRequest("/api/v1/intranet/logistics/shipments/ShipmentDeviations");
            bool success = await api.SendPostRequest(deviation);
        }

        public async Task UpdateDeviation(ShipmentDeviationData deviation)
        {
            APIRequest api = new APIRequest("/api/v1/intranet/logistics/shipments/ShipmentDeviations/" + deviation.ShipmentId);
            bool success = await api.SendPutRequest(deviation);
        }
    }
}
