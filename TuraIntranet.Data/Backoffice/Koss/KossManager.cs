using Serilog;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.API;
using Microsoft.Extensions.Logging;

namespace TuraIntranet.Data.Backoffice.Koss
{
    public class KossManager
    {
        private Microsoft.Extensions.Logging.ILogger _logger { get; set; }
        private List<KossHeadphoneModel> _kossHeadphones;
        private List<KossRma> _kossRma;

        public KossManager()
        {
            var loggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder => builder.AddSerilog());
            var logger = loggerFactory.CreateLogger(string.Empty);
            this._logger = logger;
        }

        public async Task<List<KossRma>> GetKossRmasAsync()
        {
            if (this._kossRma != null && this._kossRma.Count > 0)
            {
                return this._kossRma;
            }

            APIRequest api = new APIRequest("/api/v1/koss/KossRmas");

            var response = await api.GetResponse();

            //Console.WriteLine(response.Content);

            try
            {
                if (response != null && response.Content != null)
                {
                    this._kossRma = JsonConvert.DeserializeObject<List<KossRma>>(response.Content);

                    return this._kossRma;
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

        public async Task<KossRma> GetKossRmaAsync(int id)
        {
            if (this._kossRma != null && this._kossRma.Count > 0)
            {
                var rma = this._kossRma.Where(x => x.Id == id).FirstOrDefault();

                if (rma != null)
                    return rma;
            }

            APIRequest api = new APIRequest("/api/v1/koss/KossRmas/" + id);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    var rma = JsonConvert.DeserializeObject<KossRma>(response.Content);

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

        public async Task<List<KossHeadphoneModel>?> GetKossModelsAsync()
        {
            if (this._kossHeadphones != null && this._kossHeadphones.Count > 0)
            {
                return this._kossHeadphones;
            }

            APIRequest api = new APIRequest("/api/v1/koss/KossHeadphoneModels");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    this._kossHeadphones = JsonConvert.DeserializeObject<List<KossHeadphoneModel>>(response.Content);

                    return this._kossHeadphones;
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

        public async Task<bool> UpdateKossModelAsync(KossRma kossRma)
        {
            APIRequest api = new APIRequest("/api/v1/koss/KossRmas/" + kossRma.Id);
            bool success = await api.SendPutRequest(kossRma);

            return success;
        }

        public void Flush()
        {
            this._kossRma = null;
        }
    }
}
