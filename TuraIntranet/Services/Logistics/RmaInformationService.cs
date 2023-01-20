using TuraIntranet.Data.Logistics.Rma;

namespace TuraIntranet.Services.Logistics
{
    public class RmaInformationService
    {
        private Data.Logistics.Rma.RmaManager _rmaManager;

        public RmaInformationService()
        {
            this._rmaManager = new Data.Logistics.Rma.RmaManager();
        }

        public Task<RmaData?> GetRmaInformationAsync(string identifier, string type)
        {
            return this._rmaManager.GetRmaInformationAsync(identifier, type);
        }
    }
}
