using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.Logistics.Shipments;

namespace TuraIntranet.Data.API
{
    public class APIRequest
    {
        private string _apiUrl;

        public APIRequest(string apiUrl)
        {
            this._apiUrl = apiUrl;
        }

        public async Task<RestResponse?> GetResponse()
        {
            try
            {
                using (var client = new RestClient(this._apiUrl))
                {
                    var request = new RestRequest();
                    request.AddHeader("ApiKey", "ba932ec7-3d66-487c-bcd0-4e17c8a2dfb3");
                    RestResponse response = await client.ExecuteAsync(request);

                    if (response != null)
                    {
                        return response;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<bool> SendPutRequest(object model)
        {
            try
            {
                using (var client = new RestClient(this._apiUrl))
                {
                    var request = new RestRequest();
                    request.Method = Method.Put;
                    request.AddHeader("ApiKey", "ba932ec7-3d66-487c-bcd0-4e17c8a2dfb3");
                    request.AddJsonBody(JsonConvert.SerializeObject(model));
                    RestResponse response = await client.ExecutePutAsync<object>(request);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        public async Task<bool> SendPostRequest(object model)
        {
            try
            {
                using (var client = new RestClient(this._apiUrl))
                {
                    var request = new RestRequest();
                    request.Method = Method.Post;
                    request.AddHeader("ApiKey", "ba932ec7-3d66-487c-bcd0-4e17c8a2dfb3");
                    request.AddJsonBody(JsonConvert.SerializeObject(model));
                    RestResponse response = await client.ExecutePostAsync<object>(request);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
