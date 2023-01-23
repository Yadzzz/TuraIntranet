using TuraIntranet.Data.Logistics.Rma;

namespace TuraIntranet.Services.Logistics
{
    public class RmaInformationService
    {
        private RmaManager _rmaManager;

        public RmaInformationService()
        {
            this._rmaManager = new RmaManager();
        }

        public Task<RmaData?> GetRmaInformationAsync(string identifier, string type)
        {
            return this._rmaManager.GetRmaInformationAsync(identifier, type);
        }

        public Task<List<ActivityCode>> GetActivityCodes()
        {
            return this._rmaManager.GetActivityCodesAsync();
        }
    }
}
