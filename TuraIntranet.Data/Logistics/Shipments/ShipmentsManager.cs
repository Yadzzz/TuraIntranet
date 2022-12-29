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
        public async Task<List<ShipmentModel>?> GetShipments()
        {
            APIRequest api = new APIRequest("https://localhost:7245/api/v1/intranet/logistics/shipments/Shipments");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<ShipmentModel>? shipments = JsonConvert.DeserializeObject<List<ShipmentModel>>(response.Content);

                    return shipments;
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
    }
}
