using TuraIntranet.Data.Orders;

namespace TuraIntranet.Services.Orders
{
    public class OrdersService
    {
        private OrdersManager _ordersManager;

        public OrdersService()
        {
            this._ordersManager = new OrdersManager();
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            return this._ordersManager.GetOrdersAsync();
        }
    }
}
