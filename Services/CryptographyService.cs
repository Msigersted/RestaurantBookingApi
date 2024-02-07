using System.Linq;
using RestaurantBookingApi.Services;

namespace RestaurantBookingApi.Services
{
    public class CryptographyService
    {
        private const int Shift = 4; 

        public string Encrypt(string input)
        {
            
            return string.IsNullOrEmpty(input) ? input : new string(input.Select(c => (char)(((c + Shift - 'a') % 26) + 'a')).ToArray());
        }

        public string Decrypt(string input)
        {
           
            return string.IsNullOrEmpty(input) ? input : new string(input.Select(c => (char)(((c - Shift - 'a' + 26) % 26) + 'a')).ToArray());
        }
    }
}
