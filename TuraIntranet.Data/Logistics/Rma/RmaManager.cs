using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
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
        private Microsoft.Extensions.Logging.ILogger _logger { get; set; }

        private List<ActivityCode> _activityCodes;

        public RmaManager()
        {
            var loggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder => builder.AddSerilog());
            var logger = loggerFactory.CreateLogger(string.Empty);
            this._logger = logger;
        }

        public async Task<RmaData?> GetRmaInformationAsync(string identifier, string type)
        {
            APIRequest api = new APIRequest("/api/v1/intranet/logistics/rma/RmaInformation/" + identifier + "/" + type);

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
                this._logger.LogError(ex.ToString());
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<List<ActivityCode>> GetActivityCodesAsync()
        {
            APIRequest api = new APIRequest("/api/v1/intranet/logistics/rma/ActivityCodes");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    this._activityCodes = JsonConvert.DeserializeObject<List<ActivityCode>>(response.Content);

                    return this._activityCodes;
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

        public async Task<RmaInformation?> GetSpecialRmaInformation(string id)
        {
            APIRequest api = new APIRequest("/api/v1/intranet/logistics/RmaInformations/" + id);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    var rmaInfo = JsonConvert.DeserializeObject<RmaInformation>(response.Content);

                    return rmaInfo;
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

        public async Task<bool> UpdateSpecialRmaInformationAsync(RmaInformation rmaInformation)
        {
            APIRequest api = new APIRequest("/api/v1/intranet/logistics/RmaInformations/" + rmaInformation.Id);
            bool success = await api.SendPutRequest(rmaInformation);

            return success;
        }

        public async Task<bool> AddSpecialRmaInformationAsync(RmaInformation rmaInformation)
        {
            APIRequest api = new APIRequest("/api/v1/intranet/logistics/RmaInformations");
            bool success = await api.SendPostRequest(rmaInformation);

            return success;
        }
    }
}
