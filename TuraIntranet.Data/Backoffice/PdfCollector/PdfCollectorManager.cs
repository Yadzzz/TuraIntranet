using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.API;
using TuraIntranet.Data.Info;

namespace TuraIntranet.Data.Backoffice.PdfCollector
{
    public class PdfCollectorManager
    {
        public async Task<List<MetaInvoice>> GetInvoice(string invoiceNumber, DateTime start, DateTime end)
        {
            APIRequest api = new("https://prodapi.turascandinavia.com/api/v1/intranet/pdfarchive/MetaInvoices/getdocument/" + invoiceNumber + "/" + start + "/" + end);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<MetaInvoice>? data = JsonConvert.DeserializeObject<List<MetaInvoice>>(response.Content);

                    if (data == null)
                    {
                        return null;
                    }

                    //data.Data = Decompressor.Decompress(data.Data);

                    return data;
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

        public async Task<List<MetaInvoice>> GetInvoices(string customerNumber, DateTime start, DateTime end)
        {
            APIRequest api = new("https://prodapi.turascandinavia.com/api/v1/intranet/pdfarchive/MetaInvoices/getdocuments/" + customerNumber + "/" + start + "/" + end);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<MetaInvoice>? data = JsonConvert.DeserializeObject<List<MetaInvoice>>(response.Content);

                    if (data == null)
                    {
                        return null;
                    }

                    //data.Data = Decompressor.Decompress(data.Data);

                    return data;
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

        public async Task<List<MetaFinanceChrg>> GetInterestInvoice(string invoiceNumber, DateTime start, DateTime end)
        {
            APIRequest api = new("https://prodapi.turascandinavia.com/api/v1/intranet/pdfarchive/MetaFinanceChrgs/getdocument/" + invoiceNumber + "/" + start + "/" + end);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<MetaFinanceChrg>? data = JsonConvert.DeserializeObject<List<MetaFinanceChrg>>(response.Content);

                    if (data == null)
                    {
                        return null;
                    }

                    //data.Data = Decompressor.Decompress(data.Data);

                    return data;
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

        public async Task<List<MetaFinanceChrg>> GetInterestInvoices(string customerNumber, DateTime start, DateTime end)
        {
            APIRequest api = new("https://prodapi.turascandinavia.com/api/v1/intranet/pdfarchive/MetaFinanceChrgs/getdocuments/" + customerNumber + "/" + start + "/" + end);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<MetaFinanceChrg>? data = JsonConvert.DeserializeObject<List<MetaFinanceChrg>>(response.Content);

                    if (data == null)
                    {
                        return null;
                    }

                    //data.Data = Decompressor.Decompress(data.Data);

                    return data;
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

        public async Task<List<MetaLeveransbek>> GetDeliveryConfirmation(string invoiceNumber, DateTime start, DateTime end)
        {
            APIRequest api = new("https://prodapi.turascandinavia.com/api/v1/intranet/pdfarchive/MetaLeveransbeks/getdocument/" + invoiceNumber + "/" + start + "/" + end);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<MetaLeveransbek>? data = JsonConvert.DeserializeObject<List<MetaLeveransbek>>(response.Content);

                    if (data == null)
                    {
                        return null;
                    }

                    //data.Data = Decompressor.Decompress(data.Data);

                    return data;
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

        public async Task<List<MetaLeveransbek>> GetDeliveryConfirmations(string customerNumber, DateTime start, DateTime end)
        {
            APIRequest api = new("https://prodapi.turascandinavia.com/api/v1/intranet/pdfarchive/MetaLeveransbeks/getdocuments/" + customerNumber + "/" + start + "/" + end);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<MetaLeveransbek>? data = JsonConvert.DeserializeObject<List<MetaLeveransbek>>(response.Content);

                    if (data == null)
                    {
                        return null;
                    }

                    //data.Data = Decompressor.Decompress(data.Data);

                    return data;
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

        public async Task<List<MetaOrderbek>> GetOrderConfirmation(string invoiceNumber, DateTime start, DateTime end)
        {
            APIRequest api = new("https://prodapi.turascandinavia.com/api/v1/intranet/pdfarchive/MetaOrderbeks/getdocument/" + invoiceNumber + "/" + start + "/" + end);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<MetaOrderbek>? data = JsonConvert.DeserializeObject<List<MetaOrderbek>>(response.Content);

                    if (data == null)
                    {
                        return null;
                    }

                    //data.Data = Decompressor.Decompress(data.Data);

                    return data;
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

        public async Task<List<MetaOrderbek>> GetOrderConfirmations(string customerNumber, DateTime start, DateTime end)
        {
            APIRequest api = new("https://prodapi.turascandinavia.com/api/v1/intranet/pdfarchive/MetaOrderbeks/getdocuments/" + customerNumber + "/" + start + "/" + end);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<MetaOrderbek>? data = JsonConvert.DeserializeObject<List<MetaOrderbek>>(response.Content);

                    if (data == null)
                    {
                        return null;
                    }

                    //data.Data = Decompressor.Decompress(data.Data);

                    return data;
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

        public async Task<List<MetaReturorder>> GetReturnOrder(string invoiceNumber, DateTime start, DateTime end)
        {
            APIRequest api = new("https://prodapi.turascandinavia.com/api/v1/intranet/pdfarchive/MetaReturorders/getdocument/" + invoiceNumber + "/" + start + "/" + end);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<MetaReturorder>? data = JsonConvert.DeserializeObject<List<MetaReturorder>>(response.Content);

                    if (data == null)
                    {
                        return null;
                    }

                    //data.Data = Decompressor.Decompress(data.Data);

                    return data;
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

        public async Task<List<MetaReturorder>> GetReturnOrders(string customerNumber, DateTime start, DateTime end)
        {
            APIRequest api = new("https://prodapi.turascandinavia.com/api/v1/intranet/pdfarchive/MetaReturorders/getdocuments/" + customerNumber + "/" + start + "/" + end);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    List<MetaReturorder>? data = JsonConvert.DeserializeObject<List<MetaReturorder>>(response.Content);

                    if (data == null)
                    {
                        return null;
                    }

                    //data.Data = Decompressor.Decompress(data.Data);

                    return data;
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
    }
}
