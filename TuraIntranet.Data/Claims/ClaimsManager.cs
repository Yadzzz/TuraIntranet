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

        public ClaimsManager()
        {
            this._claims = new();
        }


        public async Task<Claim> GetClaim(int id)
        {
            if (this._claims != null && this._claims.Count > 0)
            {
                Claim claim = this._claims.Where(x => x.Id == id).FirstOrDefault();

                if(claim != null)
                {
                    return claim;
                }
            }

            APIRequest api = new APIRequest("https://localhost:7245/api/v1/intranet/claims/Claims");

            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    Claim claim = JsonConvert.DeserializeObject<Claim>(response.Content);

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

            APIRequest api = new APIRequest("https://localhost:7245/api/v1/intranet/claims/Claims");

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
    }
}
