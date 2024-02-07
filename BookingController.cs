using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq; 
using RestaurantBookingApi.Services;

namespace RestaurantBookingApi{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private static List<string> bookings = new List<string>();
        private readonly CryptographyService _cryptoService = new CryptographyService();

        [HttpPost]
        public ActionResult AddBooking(string customerName, string bookingDate)
        {
            // Antag att customerName och bookingDate är giltiga och icke-nulla
            var encryptedName = _cryptoService.Encrypt(customerName);
            bookings.Add($"{encryptedName}:{bookingDate}");
            return Ok("Booking added successfully.");
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetBookings()
        {
            var decryptedBookings = bookings.Select(b =>
            {
                var parts = b.Split(':');
                var decryptedName = _cryptoService.Decrypt(parts[0]);
                return $"{decryptedName}:{parts[1]}";
            }).ToList(); // Omvandla till List för att undvika eventuella upprepade enumerationer
            return Ok(decryptedBookings);
    }
}
}
