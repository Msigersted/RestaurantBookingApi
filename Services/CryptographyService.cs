using System.Linq;
using RestaurantBookingApi.Services;

namespace RestaurantBookingApi.Services
{
    public class CryptographyService
    {
        int key = 5;
        public static string Encrypt(string input)
        {
            char[] result = input.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                if (char.IsLetter(result[i]))
                {
                    char offset = char.IsUpper(result[i]) ? 'A' : 'a';
                    result[i] = (char)(((result[i] + key - offset) % 26) + offset);
                }
            }
            return new string(result);
        }

        public static string Decrypt(string input)
        {
            return Encrypt(input, 26 - key);
        }

    }
}
