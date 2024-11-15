using AirlineBooking.Application.ViewModels;
using AirlineBookingSystem.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AirlineBooking.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IBookingRepository _repository;

        public BookingsController(
            IBookingRepository commonRepository,
            IHttpContextAccessor contextAccessor)
        {
            _repository = commonRepository;
            _contextAccessor = contextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyBookings()
        {
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                // Kullanıcı giriş yapmamışsa veya ID claim'i bulunamıyorsa, hata döndür veya uygun bir sayfaya yönlendir
                return RedirectToAction("Index", "Flight"); // Örnek bir yönlendirme
            }

            var userId = Guid.Parse(userIdClaim.Value); // Claim'den alınan değeri int'e çevir

            // Kullanıcının rezervasyonlarını repository'den al ve ilişkili Flight ve Seat bilgilerini yükle
            var bookingsList = _repository.GetBookingsByUserId(userId)
                .Include(b => b.Flight)
                .Include(f => f.Seat)
                .Include(s => s.Passenger)
                .ToList();

            var viewModel = new MyBookingsViewModel
            {
                Bookings = bookingsList
            };

            return View(viewModel);
        }
    }
}
