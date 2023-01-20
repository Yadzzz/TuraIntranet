using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.API;

namespace TuraIntranet.Data.Logistics.Rma
{
    public class RmaManager
    {
        public async Task<RmaData?> GetRmaInformationAsync(string identifier, string type)
        {
            APIRequest api = new APIRequest("https://localhost:7245/api/v1/intranet/logistics/rma/RmaInformations/" + identifier + "/" + type);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    var rma = JsonConvert.DeserializeObject<RmaData>(response.Content);

                    return rma;
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
