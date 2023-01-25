using System.Runtime.CompilerServices;

namespace TuraIntranet.Services
{
    public class EANGeneratorService
    {
        public string CalculateEan13(string manufacturer, string product)
        {
            string temp = $"{manufacturer}{product}";
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
    }
}
