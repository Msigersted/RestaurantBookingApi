using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RestaurantBookingApi;

namespace RestaurantBookingApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private static List<string> bookings = new List<string>();
        private readonly CryptographyService _cryptoService = new CryptographyService();

        [HttpPost]
        public ActionResult AddBooking(string customerName, string bookingDate)
        {
            var encryptedName = _cryptoService.Encrypt(customerName);
            bookings.Add($"{encryptedName}:{bookingDate}");
            return Ok("Booking added successfully.");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBooking(int id, string customerName, string bookingDate)
        {
            if (id >= 0 && id < bookings.Count)
            {
                var encryptedName = _cryptoService.Encrypt(customerName);
                bookings[id] = $"{encryptedName}:{bookingDate}";
                return Ok("Booking updated successfully.");
            }
            else
            {
                return NotFound($"Booking with ID {id} not found.");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetBookings()
        {
            var decryptedBookings = bookings.Select(b =>
            {
                var parts = b.Split(':');
                var decryptedName = _cryptoService.Decrypt(parts[0]);
                return $"{decryptedName}:{parts[1]}";
            }).ToList(); 
            return Ok(decryptedBookings);
        }
    }
}
