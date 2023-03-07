using Newtonsoft.Json;
using RestSharp;
using System.Reflection;
using TuraIntranet.Data.ProductExport;

namespace TuraIntranet.Services.ProductExport
{
    public class ProductExportService
    {
        public ProductExportService()
        {

        }

        public async Task<List<ProductExportData>?> GetProductData(string articleNumbers)
        {
            if(string.IsNullOrEmpty(articleNumbers))
            {
                return null;
            }

            if(articleNumbers.Contains(" "))
            {
                articleNumbers = articleNumbers.Replace(" ", "");
            }

            string[] articleIds = articleNumbers.Split(",");

            if(articleIds == null || articleIds.Length == 0)
            {
                return null;
            }

            var variantIds = await this.GetVariantIds(articleIds);

            if(variantIds == null)
            {
                return null;
            }

            List<ProductExportData> data = new List<ProductExportData>();

            foreach(var variantId in variantIds)
            {

                var variant =  await this.GetVariant(variantId);

                if (variant != null)
                {
                    data.Add(new ProductExportData() { Variant = variant });
                }
            }

            return data;
        }

        private async Task<string[]?> GetVariantIds(string[] articleIds)
        {
            string apiLink = "https://backoffice.turascandinavia.com/Litium/api/admin/products/variants/keyLookups";

            try
            {
                using (var client = new RestClient(apiLink))
                {
                    var request = new RestRequest();
                    request.Method = Method.Post;
                    request.AddHeader("Authorization", "ServiceAccount eWFkdGVzdDpxdzUwMDBxdw==");
                    request.AddJsonBody(JsonConvert.SerializeObject(articleIds));
                    RestResponse response = await client.ExecutePostAsync<object>(request);

                    Console.WriteLine(response.Content);

                    Dictionary<string, string>? data = JsonConvert.DeserializeObject<Dictionary<string,string>>(response.Content);

                    if (data == null || data.Count == 0)
                        return null;

                    return data.Values.ToArray();
                }
            }
            catch (Exception ex)
            {
                //this._logger.LogError(ex.ToString());
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        private async Task<Variant?> GetVariant(string variantId)
        {
            string apiLink = "https://backoffice.turascandinavia.com/Litium/api/admin/products/variants/" + variantId;

            try
            {
                using (var client = new RestClient(apiLink))
                {
                    var request = new RestRequest();
                    request.AddHeader("Authorization", "ServiceAccount eWFkdGVzdDpxdzUwMDBxdw==");
                    RestResponse response = await client.ExecuteAsync(request);

                    //Console.WriteLine(response.Content);

                    var variant = JsonConvert.DeserializeObject<Variant>(response.Content);

                    return variant;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        private void GetBaseProduct(string baseProductId)
        {
            string apiLink = "https://backoffice.turascandinavia.com/Litium/api/admin/products/baseProducts/" + baseProductId;
        }
    }
}
