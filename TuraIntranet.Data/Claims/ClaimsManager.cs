using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.API;
using TuraIntranet.Data.Info;

namespace TuraIntranet.Data.Claims
{
    public class ClaimsManager
    {
        private List<Claim> _claims;
        private List<ClaimCurrency> _currencies;

        public ClaimsManager()
        {
            this._claims = new();
            this._currencies = new();
        }


        public async Task<Claim> GetClaim(int id)
        {
            if (this._claims != null && this._claims.Count > 0)
            {
                Claim claim = this._claims.Where(x => x.Id == id).FirstOrDefault();

                if (claim != null)
                {
                    return claim;
                }
            }

            APIRequest api = new APIRequest("https://apitest.turascandinavia.com/api/v1/intranet/claims/Claims/" + id);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    Claim claim = JsonConvert.DeserializeObject<Claim>(response.Content);

                    Console.WriteLine(claim.AmountIn);
                    Console.WriteLine(claim.AmountOut);

                    return claim;
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

        public async Task<List<Claim>> GetClaimsAsync()
        {
            if (this._claims != null && this._claims.Count > 0)
            {
                return this._claims;
            }

            APIRequest api = new APIRequest("https://apitest.turascandinavia.com/api/v1/intranet/claims/Claims");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    this._claims = JsonConvert.DeserializeObject<List<Claim>>(response.Content);

                    return this._claims;
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

        public async Task<List<ClaimCurrency>> GetCurrenciesAsync()
        {
            if (this._currencies != null && this._currencies.Count > 0)
            {
                return this._currencies;
            }

            APIRequest api = new APIRequest("https://apitest.turascandinavia.com/api/v1/intranet/claims/ClaimCurrencies");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    this._currencies = JsonConvert.DeserializeObject<List<ClaimCurrency>>(response.Content);

                    return this._currencies;
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

        public async Task<ClaimCurrency> GetCurrencyAsync(int id)
        {
            if (this._currencies != null && this._currencies.Count > 0)
            {
                var currency = this._currencies.Where(x => x.Id == id).FirstOrDefault();

                if(currency != null)
                {
                    return currency;
                }
            }

            APIRequest api = new APIRequest("https://apitest.turascandinavia.com/api/v1/intranet/claims/ClaimCurrencies/" + id);

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    ClaimCurrency currency = JsonConvert.DeserializeObject<ClaimCurrency>(response.Content);

                    return currency;
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

        public async Task UpdateClaim(Claim claim)
        {
            APIRequest api = new APIRequest("https://apitest.turascandinavia.com/api/v1/intranet/claims/Claims/" + claim.Id);
            bool success = await api.SendPutRequest(claim);
        }

        public async Task AddClaim(Claim claim)
        {
            APIRequest api = new APIRequest("https://apitest.turascandinavia.com/api/v1/intranet/claims/Claims");
            bool success = await api.SendPostRequest(claim);
        }

        public async Task Flush()
        {
            this._claims = null;
            await this.GetClaimsAsync();
        }
    }
}
