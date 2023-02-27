using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.API;
using TuraIntranet.Data.Networks;

namespace TuraIntranet.Data.PriceList
{
    public class PriceListManager
    {
        private Microsoft.Extensions.Logging.ILogger _logger { get; set; }

        public PriceListManager()
        {
            var loggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder => builder.AddSerilog());
            var logger = loggerFactory.CreateLogger(string.Empty);
            this._logger = logger;
        }

        public async Task<List<ViewTempPrisListExportSsr>?> GetPriceList(string customerNo, string vendorNo, string itemCategoryCode)
        {
            APIRequest api = new APIRequest("/api/v1/intranet/pricelist/TempPrisListExportSsr/" + customerNo + "/" + vendorNo + "/" + itemCategoryCode);
            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    var priceList = JsonConvert.DeserializeObject<List<ViewTempPrisListExportSsr>>(response.Content);

                    return priceList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                Console.WriteLine(ex.ToString());

                return null;
            }
        }
    }
}
