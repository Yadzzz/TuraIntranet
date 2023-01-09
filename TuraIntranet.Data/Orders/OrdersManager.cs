using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.API;

namespace TuraIntranet.Data.Orders
{
    public class OrdersManager
    {
        private List<Order> _orders;

        public async Task<List<Order>> GetOrdersAsync()
        {
            if (this._orders != null && this._orders.Count > 0)
            {
                return this._orders;
            }

            APIRequest api = new APIRequest("https://localhost:7245/api/v1/intranet/orders/Orders");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    this._orders = JsonConvert.DeserializeObject<List<Order>>(response.Content);

                    return this._orders;
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
