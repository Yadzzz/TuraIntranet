using Microsoft.Identity.Client;
using TuraIntranet.Data.Backoffice.Koss;

namespace TuraIntranet.Services.Backoffice
{
    public class KossService
    {
        private KossManager _kossManager;

        public KossService()
        {
            this._kossManager = new();
        }

        public Task<List<KossRma>> GetKossRmasAsync()
        {
            return this._kossManager.GetKossRmasAsync();
        }

        public Task<List<KossHeadphoneModel>> GetKossModelsAsync()
        {
            return this._kossManager.GetKossModelsAsync();
        }
    }
}
