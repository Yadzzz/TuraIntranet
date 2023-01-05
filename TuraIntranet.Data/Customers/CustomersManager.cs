﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.API;
using TuraIntranet.Data.Logistics.Shipments;

namespace TuraIntranet.Data.Customers
{
    public class CustomersManager
    {
        private List<SpecialCustomerModel>? _specialCustomers;

        public async Task<List<SpecialCustomerModel>?> GetSpecialCustomersAsync(bool forceFlush = false)
        {
            if(this._specialCustomers != null && !forceFlush)
            {
                return this._specialCustomers;
            }

            APIRequest api = new APIRequest("https://localhost:7245/api/v1/intranet/customers/SpecialCustomers");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    this._specialCustomers = JsonConvert.DeserializeObject<List<SpecialCustomerModel>>(response.Content);

                    return this._specialCustomers;
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

        public async Task<SpecialCustomerModel?> GetSpecialCustomerAsync(string id)
        {
            if (this._specialCustomers != null)
            {
                var specialCustomer = this._specialCustomers.Where(x => x.CustomerNumber == id).FirstOrDefault();

                if(specialCustomer != null)
                {
                    return specialCustomer;
                }
            }

            APIRequest api = new APIRequest("https://localhost:7245/api/v1/intranet/customers/SpecialCustomers/" + id);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    var specialCustomer = JsonConvert.DeserializeObject<SpecialCustomerModel>(response.Content);

                    return specialCustomer;
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

        public async Task<CustomerModel?> GetCustomerAsync(string id)
        {
            APIRequest api = new APIRequest("https://localhost:7245/api/v1/intranet/customers/Customers/" + id);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    var customerModel = JsonConvert.DeserializeObject<CustomerModel>(response.Content);

                    return customerModel;
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

        public async Task AddSpecialCustomer(SpecialCustomerModel specialCustomer)
        {
            APIRequest api = new APIRequest("https://localhost:7245/api/v1/intranet/customers/SpecialCustomers");
            bool success = await api.SendPostRequest(specialCustomer);
        }

        public async Task UpdateSpecialCustomer(int id, SpecialCustomerModel specialCustomer)
        {
            APIRequest api = new APIRequest("https://localhost:7245/api/v1/intranet/customers/SpecialCustomers/" + id);
            bool success = await api.SendPutRequest(specialCustomer);
        }

        public void FlushSpecialCustomers()
        {
            this._specialCustomers = null;
        }
    }
}
