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

        public Task<Data.Networks.Network?> GetNetwork(int id)
        {
            return this._networkManager.GetNetworkAsync(id);
        }

        public Task<Data.Networks.NetworkIp?> GetNetworkIp(int id)
        {
            return this._networkManager.GetNetworkIpAsync(id);
        }

        public Task UpdateNetworkIp(Data.Networks.NetworkIp networkIp)
        {
            return this._networkManager.UpdateNetworkIpAsync(networkIp);
        }

        public void Flush()
        {
            this._networkManager.Flush();
        }
    }
}
