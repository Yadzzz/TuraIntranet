

namespace TuraIntranet.Services.Backoffice
{
    public class PdfCollectorService
    {
        private TuraIntranet.Data.Backoffice.PdfCollector.PdfCollectorManager _pdfCollectorManager;

        public PdfCollectorService()
        {
            this._pdfCollectorManager = new();
        }

        public Task<byte[]?> GetBytes(string invoiceId, string type)
        {
            return this._pdfCollectorManager.GetPdf(invoiceId, type);
        }
    }
}
