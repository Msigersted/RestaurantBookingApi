using Xunit;
using RestaurantBookingApi.Services; 
namespace RestaurantBookingApi.Tests
{
    public class CryptographyServiceTests  
    {
        [Fact]
        public void Encrypt_Decrypt_ReturnsOriginalString()
        {
            // Arrange
            var service = new CryptographyService();
            var originalString = "teststring";

            // Act
            var encrypted = service.Encrypt(originalString);
            var decrypted = service.Decrypt(encrypted);

            // Assert
            Assert.Equal(originalString, decrypted);
        }
    }
}