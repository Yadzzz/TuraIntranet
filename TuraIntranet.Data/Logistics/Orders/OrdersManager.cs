using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.API;

namespace TuraIntranet.Data.Logistics.Orders
{
    public class OrdersManager
    {
        private List<R08T1> _orders;

        public async Task<List<R08T1>> GetOrdersAsync()
        {
            if (_orders != null && _orders.Count > 0)
            {
                return _orders;
            }

            APIRequest api = new APIRequest("/api/v1/intranet/logistics/orders/Orders");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    _orders = JsonConvert.DeserializeObject<List<R08T1>>(response.Content);

                    return _orders;
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

        public async Task<List<O08T1>> GetNavOrderAsync(string id, string type)
        {
            APIRequest api = new APIRequest("/api/v1/intranet/logistics/orders/Orders/" + id + "/" + type);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    var order = JsonConvert.DeserializeObject<List<O08T1>>(response.Content);

                    return order;
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
