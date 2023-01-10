using TuraIntranet.Data.Logistics.Orders;

namespace TuraIntranet.Services.Orders
{
    public class OrdersService
    {
        private OrdersManager _ordersManager;

        public OrdersService()
        {
            this._ordersManager = new OrdersManager();
        }

        public Task<List<R08T1>> GetOrdersAsync()
        {
            return this._ordersManager.GetOrdersAsync();
        }

        public Task<List<O08T1>> GetNavOrderAsync(string id, string type)
        {
            return this._ordersManager.GetNavOrderAsync(id, type);
        }
    }
}
