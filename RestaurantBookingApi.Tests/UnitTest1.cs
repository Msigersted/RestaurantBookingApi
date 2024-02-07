using Xunit;
using RestaurantBookingApi.Services; // Se till att denna namnrymd matchar platsen för din CryptographyService

public class CryptographyServiceTests // Detta namn reflekterar att klassen innehåller tester för CryptographyService
{
    [Fact]
    public void Encrypt_Decrypt_ReturnsOriginalString()
    {
        // Arrange
        var service = new CryptographyService(); // Antager att detta är din service-klass för kryptering/avkryptering
        var originalString = "TestString";

        // Act
        var encrypted = service.Encrypt(originalString);
        var decrypted = service.Decrypt(encrypted);

        // Assert
        Assert.Equal(originalString, decrypted);
    }
}
