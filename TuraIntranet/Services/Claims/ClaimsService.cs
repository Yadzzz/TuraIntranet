using TuraIntranet.Data.Claims;

namespace TuraIntranet.Services.Claims
{
    public class ClaimsService
    {
        private ClaimsManager _claimsManager;

        public ClaimsService()
        {
            this._claimsManager = new();
        }

        public Task<Claim> GetClaim(int id)
        {
            return this._claimsManager.GetClaim(id);
        }

        public Task<List<Claim>> GetClaims()
        {
            return this._claimsManager.GetClaimsAsync();
        }
    }
}
