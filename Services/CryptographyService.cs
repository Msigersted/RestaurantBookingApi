using System.Linq;
using RestaurantBookingApi.Services;

namespace RestaurantBookingApi.Services
{
    public class CryptographyService
    {
        private const int Shift = 4; // Enkel skift för Caesar-chiffer

        public string Encrypt(string input)
        {
            // Caesar-chiffer logik för kryptering
            return string.IsNullOrEmpty(input) ? input : new string(input.Select(c => (char)(((c + Shift - 'a') % 26) + 'a')).ToArray());
        }

        public string Decrypt(string input)
        {
            // Caesar-chiffer logik för avkryptering
            return string.IsNullOrEmpty(input) ? input : new string(input.Select(c => (char)(((c - Shift - 'a' + 26) % 26) + 'a')).ToArray());
        }
    }
}
