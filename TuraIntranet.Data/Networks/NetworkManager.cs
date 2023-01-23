using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuraIntranet.Data.API;
using TuraIntranet.Data.Info;

namespace TuraIntranet.Data.Networks
{
    public class NetworkManager
    {
        private Dictionary<int, Network>? _networks;

        public NetworkManager()
        {

        }

        public async Task LoadNetworksAsync(bool forceLoad = false)
        {
            if (this._networks != null && this._networks.Count > 0 && !forceLoad)
            {
                return;
            }

            this._networks = new();

            APIRequest api = new APIRequest("https://prodapi.turascandinavia.com/api/v1/intranet/networks/Networks");
            var response = await api.GetResponse();

            try
            {
                if (response != null && response.Content != null)
                {
                    var networks = JsonConvert.DeserializeObject<List<Network>>(response.Content);

                    if (networks != null)
                    {
                        foreach (var network in networks)
                        {
                            api.SetUrl("https://prodapi.turascandinavia.com/api/v1/intranet/networks/NetworkIps/" + network.Id);
                            var networkIpResponse = await api.GetResponse();

                            if (networkIpResponse != null && networkIpResponse.Content != null)
                            {
                                var networkIps = JsonConvert.DeserializeObject<List<NetworkIp>>(networkIpResponse.Content);
                                
                                if (networkIps != null)
                                {
                                    network.NetworkIps = networkIps;
                                    this._networks.Add(network.Id, network);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<List<Network>?> GetNetworksAsync()
        {
            if (this._networks == null || this._networks.Count == 0)
            {
                await this.LoadNetworksAsync();

                if (this._networks == null || this._networks.Count == 0)
                {
                    return null;
                }
            }

            return this._networks.Values.ToList();
        }

        public async Task<Network?> GetNetworkAsync(int id)
        {
            if(this._networks == null ||this._networks.Count == 0)
            {
                await this.LoadNetworksAsync();

                if (this._networks == null || this._networks.Count == 0)
                {
                    return null;
                }
            }

            if(this._networks.TryGetValue(id, out Network network))
            {
                return network;
            }
            else
            {
                return null;
            }
        }

        public async Task<NetworkIp?> GetNetworkIpAsync(int id)
        {
            if (this._networks == null || this._networks.Count == 0)
            {
                await this.LoadNetworksAsync();

                if (this._networks == null || this._networks.Count == 0)
                {
                    return null;
                }
            }

            foreach(var network in this._networks.Values)
            {
                var networkIp = network.NetworkIps.Where(x => x.Id == id).FirstOrDefault();

                if(networkIp != null)
                {
                    return networkIp;
                }
            }

            return null;
        }

        public async Task UpdateNetworkIpAsync(NetworkIp networkIp)
        {
            APIRequest api = new APIRequest("https://prodapi.turascandinavia.com/api/v1/intranet/networks/NetworkIps/" + networkIp.Id);
            var success = await api.SendPutRequest(networkIp);
        }

        public void Flush()
        {
            this._networks = null;
        }
    }
}
