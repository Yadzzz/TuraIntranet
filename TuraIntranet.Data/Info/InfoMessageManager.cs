using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.API;
using TuraIntranet.Data.Customers;

namespace TuraIntranet.Data.Info
{
    public class InfoMessageManager
    {
        private List<InfoMessageModel> _infoMessages;

        public async Task<List<InfoMessageModel>?> GetInfoMessagesAsync()
        {
            if (this._infoMessages != null)
            {
                return this._infoMessages;
            }

            APIRequest api = new APIRequest("https://apitest.turascandinavia.com/api/v1/intranet/InfoMessages");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    this._infoMessages = JsonConvert.DeserializeObject<List<InfoMessageModel>>(response.Content);

                    return this._infoMessages;
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

        public async Task<InfoMessageModel?> GetInfoMessageAsync(int id)
        {
            if (this._infoMessages != null)
            {
                var infoMessage = this._infoMessages.Where(x => x.Id == id).FirstOrDefault();

                if(infoMessage != null)
                {
                    return infoMessage;
                }
            }

            APIRequest api = new APIRequest("https://apitest.turascandinavia.com/api/v1/intranet/InfoMessages/" + id);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    var infoMessage = JsonConvert.DeserializeObject<InfoMessageModel>(response.Content);

                    return infoMessage;
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

        public async Task UpdateInfoMessage(int id, InfoMessageModel infoMessage)
        {
            APIRequest api = new APIRequest("https://apitest.turascandinavia.com/api/v1/intranet/InfoMessages/" + id);
            bool success = await api.SendPutRequest(infoMessage);
        }

        public async Task AddInfoMessage(InfoMessageModel infoMessage)
        {
            APIRequest api = new APIRequest("https://apitest.turascandinavia.com/api/v1/intranet/InfoMessages/");
            bool success = await api.SendPostRequest(infoMessage);
        }

        public async Task DeleteInfoMessage(int id)
        {
            APIRequest api = new APIRequest("https://apitest.turascandinavia.com/api/v1/intranet/InfoMessages/" + id);
            bool success = await api.SendDeleteRequest();
        }

        public void Flush()
        {
            this._infoMessages = null;
        }
    }
}
