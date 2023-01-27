using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.API;
using TuraIntranet.Data.Customers;

namespace TuraIntranet.Data.EAN
{
    public class EANManager
    {
        private List<EanPrefix>? eanPrefixes;

        public async Task<List<EanPrefix>?> GetEanPrefixesAsync()
        {
            if (this.eanPrefixes != null && this.eanPrefixes.Count > 0)
            {
                return this.eanPrefixes;
            }

            APIRequest api = new APIRequest("/api/v1/intranet/ean/EanPrefixes");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    this.eanPrefixes = JsonConvert.DeserializeObject<List<EanPrefix>>(response.Content);

                    return this.eanPrefixes;
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
