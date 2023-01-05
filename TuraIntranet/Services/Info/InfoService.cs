using TuraIntranet.Data.Info;

namespace TuraIntranet.Services.Info
{
    public class InfoService
    {
        private Data.Info.InfoMessageManager _infoMessageManager;

        public InfoService()
        {
            this._infoMessageManager = new Data.Info.InfoMessageManager();
        }

        public async Task<List<Data.Info.InfoMessageModel>?> GetInfoMessagesAsync()
        {
            return await this._infoMessageManager.GetInfoMessagesAsync();
        }

        public async Task<InfoMessageModel?> GetInfoMessageAsync(int id)
        {
            return await this._infoMessageManager.GetInfoMessageAsync(id);
        }

        public async Task UpdateInfoMessageAsync(int id, InfoMessageModel infoMessage)
        {
            await this._infoMessageManager.UpdateInfoMessage(id, infoMessage);
        }

        public async Task DeleteInfoMessageAsync(int id)
        {
            await this._infoMessageManager.DeleteInfoMessage(id);
        }

        public void Flush()
        {
            this._infoMessageManager.Flush();
        }
    }
}
