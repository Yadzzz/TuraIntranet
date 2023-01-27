using TuraIntranet.Data.EAN;

namespace TuraIntranet.Services.EAN
{
    public class EANService
    {
        private EANManager eanManager;

        public EANService()
        {
            this.eanManager = new();
        }

        /// <summary>
        /// Calculates Check Digit for EAN-13
        /// </summary>
        /// <param name="data">Company Prefix + Article Number</param>
        /// <returns></returns>
        public string CalculateEan13(string data)
        {

            string temp = $"{data}";
            int sum = 0;
            int digit = 0;

            //Check if given data length is lower than 12 digits

            if (temp.Length < 12)
            {
                for (int i = temp.Length; i < 12; i++)
                {
                    temp = "0" + temp;
                }
            }

            // Calculate the checksum digit here.
            for (int i = temp.Length; i >= 1; i--)
            {
                digit = Convert.ToInt32(temp.Substring(i - 1, 1));
                // This appears to be backwards but the 
                // EAN-13 checksum must be calculated
                // this way to be compatible with UPC-A.
                if (i % 2 == 0)
                { // odd  
                    sum += digit * 3;
                }
                else
                { // even
                    sum += digit * 1;
                }
            }
            int checkSum = (10 - (sum % 10)) % 10;
            return $"{temp}{checkSum}";
        }

        public string CalculateEan13(string country, string manufacturer, string product)
        {
            string temp = $"{country}{manufacturer}{product}";
            int sum = 0;
            int digit = 0;

            // Calculate the checksum digit here.
            for (int i = temp.Length; i >= 1; i--)
            {
                digit = Convert.ToInt32(temp.Substring(i - 1, 1));
                // This appears to be backwards but the 
                // EAN-13 checksum must be calculated
                // this way to be compatible with UPC-A.
                if (i % 2 == 0)
                { // odd  
                    sum += digit * 3;
                }
                else
                { // even
                    sum += digit * 1;
                }
            }
            int checkSum = (10 - (sum % 10)) % 10;
            return $"{temp}{checkSum}";
        }

        public Task<List<EanPrefix>?> GetEanPrefixes()
        {
            return this.eanManager.GetEanPrefixesAsync();
        }
    }
}
