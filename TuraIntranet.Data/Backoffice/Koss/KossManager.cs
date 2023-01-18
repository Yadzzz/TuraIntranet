using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.API;

namespace TuraIntranet.Data.Backoffice.Koss
{
    public class KossManager
    {
        private List<KossHeadphoneModel> _kossHeadphones;
        private List<KossRma> _kossRma;

        public KossManager()
        {

        }

        public async Task<List<KossRma>> GetKossRmasAsync()
        {
            if (this._kossRma != null && this._kossRma.Count > 0)
            {
                return this._kossRma;
            }

            APIRequest api = new APIRequest("https://localhost:7245/api/v1/koss/KossRmas");

            var response = await api.GetResponse();

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
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<List<KossHeadphoneModel>> GetKossModelsAsync()
        {
            if (this._kossHeadphones != null && this._kossHeadphones.Count > 0)
            {
                return this._kossHeadphones;
            }

            APIRequest api = new APIRequest("https://localhost:7245/api/v1/koss/KossHeadphoneModels");

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
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<bool> UpdateKossModelAsync(KossRma kossRma)
        {
            APIRequest api = new APIRequest("https://localhost:7245/api/v1/koss/KossRmas");
            bool success = await api.SendPutRequest(kossRma);

            return success;
        }
    }
}
