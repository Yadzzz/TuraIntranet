using Newtonsoft.Json;
using System;
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
        public async Task<byte[]?> GetPdf(string invoiceNumber, string type)
        {
            APIRequest api = new("https://localhost:7245/api/pdf/getdocumentbytes/" + invoiceNumber + "/" + type);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    byte[]? bytes = JsonConvert.DeserializeObject<byte[]>(response.Content);

                    if(bytes == null)
                    {
                        return null;
                    }

                    byte[] decompressed = Decompressor.Decompress(bytes);

                    return decompressed;
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
