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

        public async Task<List<SpecialCustomerModel>?> GetSpecialCustomersAsync()
        {
            return await this._customerManager.GetSpecialCustomersAsync();
        }

        public async Task<Dictionary<string, CustomerModel>?> GetSpecialCustomersData()
        {
            return await this._customerManager.GetSpecialCustomersDataAsync();
        }

        public async Task<CustomerModel?> GetCustomerAsync(string id)
        {
            return await this._customerManager.GetCustomerAsync(id);
        }

        public async Task<SpecialCustomerModel?> GetSpecialCustomerAsync(string id)
        {
            return await this._customerManager.GetSpecialCustomerAsync(id);
        }

        public async Task AddSpecialCustomer(SpecialCustomerModel specialCustomer)
        {
            await this._customerManager.AddSpecialCustomer(specialCustomer);
        }

        public async Task UpdateSpecialCustomer(int id, SpecialCustomerModel specialCustomer)
        {
            await this._customerManager.UpdateSpecialCustomer(id, specialCustomer);
        }

        public void FlushSpecialCustomers()
        {
            this._customerManager.FlushSpecialCustomers();
        }
    }
}
