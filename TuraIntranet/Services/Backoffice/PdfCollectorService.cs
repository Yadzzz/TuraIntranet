

namespace TuraIntranet.Services.Backoffice
{
    public class PdfCollectorService
    {
        private TuraIntranet.Data.Backoffice.PdfCollector.PdfCollectorManager _pdfCollectorManager;

        public PdfCollectorService()
        {
            this._pdfCollectorManager = new();
        }

        public Task<List<Data.Backoffice.PdfCollector.MetaInvoice>> GetInvoice(string invoiceId, DateTime start, DateTime end)
        {
            return this._pdfCollectorManager.GetInvoice(invoiceId, start, end);
        }

        public Task<List<Data.Backoffice.PdfCollector.MetaInvoice>> GetInvoices(string customerNumber, DateTime start, DateTime end)
        {
            return this._pdfCollectorManager.GetInvoices(customerNumber, start, end);
        }

        public Task<List<Data.Backoffice.PdfCollector.MetaFinanceChrg>> GetInterestInvoice(string invoiceId, DateTime start, DateTime end)
        {
            return this._pdfCollectorManager.GetInterestInvoice(invoiceId, start, end);
        }

        public Task<List<Data.Backoffice.PdfCollector.MetaFinanceChrg>> GetInterestInvoices(string customerNumber, DateTime start, DateTime end)
        {
            return this._pdfCollectorManager.GetInterestInvoices(customerNumber, start, end);
        }

        public Task<List<Data.Backoffice.PdfCollector.MetaLeveransbek>> GetDeliveryConfirmation(string orderId, DateTime start, DateTime end)
        {
            return this._pdfCollectorManager.GetDeliveryConfirmation(orderId, start, end);
        }

        public Task<List<Data.Backoffice.PdfCollector.MetaLeveransbek>> GetDeliveryConfirmations(string customerNumber, DateTime start, DateTime end)
        {
            return this._pdfCollectorManager.GetDeliveryConfirmations(customerNumber, start, end);
        }

        public Task<List<Data.Backoffice.PdfCollector.MetaOrderbek>> GetOrderConfirmation(string orderId, DateTime start, DateTime end)
        {
            return this._pdfCollectorManager.GetOrderConfirmation(orderId, start, end);
        }

        public Task<List<Data.Backoffice.PdfCollector.MetaOrderbek>> GetOrderConfirmations(string customerNumber, DateTime start, DateTime end)
        {
            return this._pdfCollectorManager.GetOrderConfirmations(customerNumber, start, end);
        }

        public Task<List<Data.Backoffice.PdfCollector.MetaReturorder>> GetReturnOrder(string orderId, DateTime start, DateTime end)
        {
            return this._pdfCollectorManager.GetReturnOrder(orderId, start, end);
        }

        public Task<List<Data.Backoffice.PdfCollector.MetaReturorder>> GetReturnOrders(string customerNumber, DateTime start, DateTime end)
        {
            return this._pdfCollectorManager.GetReturnOrders(customerNumber, start, end);
        }
    }
}
