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

        public Task<RmaInformation?> GetSpecialRmaInformation(string id)
        {
            return this._rmaManager.GetSpecialRmaInformation(id);
        }

        public Task<bool> UpdateSpecialRmaInformationAsync(RmaInformation rmaInformation)
        {
            return this._rmaManager.UpdateSpecialRmaInformationAsync(rmaInformation);
        }

        public Task<bool> AddSpecialRmaInformationAsync(RmaInformation rmaInformation)
        {
            return this._rmaManager.AddSpecialRmaInformationAsync(rmaInformation);
        }
    }
}
