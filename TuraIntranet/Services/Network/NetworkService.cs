namespace TuraIntranet.Services.Network
{
    public class NetworkService
    {
        private TuraIntranet.Data.Networks.NetworkManager _networkManager;

        public NetworkService()
        {
            this._networkManager = new();
        }

        public Task<List<TuraIntranet.Data.Networks.Network>?> GetNetworks()
        {
            return this._networkManager.GetNetworksAsync();
        }
    }
}
