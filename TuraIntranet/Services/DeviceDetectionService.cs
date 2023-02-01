using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace TuraIntranet.Services
{
    public class DeviceDetectionService
    {
        [Inject]
        private IJSRuntime jsRuntime { get; set; }
        public string isDevice { get; set; }
        public bool mobile { get; set; }

        public DeviceDetectionService(IJSRuntime js)
        {
            this.jsRuntime = js;
        }

        public async Task FindResponsiveness()
        {
            mobile = await jsRuntime.InvokeAsync<bool>("isDevice");
            isDevice = mobile ? "Mobile" : "Desktop";
        }
    }
}
