using TuraIntranet.Data.PriceList;

namespace TuraIntranet.Services.PriceList
{
    public class PriceListService
    {
        private PriceListManager _priceListManager;

        public PriceListService()
        {
            this._priceListManager = new PriceListManager();
        }

        public Task<List<ViewTempPrisListExportSsr>?> GetPriceList(string customerNo, string vendorNo, string itemCategoryCode)
        {
            return this._priceListManager.GetPriceList(customerNo,vendorNo, itemCategoryCode);
        }
    }
}
