using TuraIntranet.Data.Customers;

namespace TuraIntranet.Services.Customers
{
    public class CustomersService
    {
        private TuraIntranet.Data.Customers.CustomersManager _customerManager;

        public CustomersService()
        {
            this._customerManager = new Data.Customers.CustomersManager();
        }

        public async Task<List<SpecialCustomerModel>> GetSpecialCustomersAsync()
        {
            return await this._customerManager.GetSpecialCustomersAsync();
        }

        public async Task<CustomerModel> GetCustomerAsync(string id)
        {
            return await this._customerManager.GetCustomerAsync(id);
        }
    }
}
