using AirlineBooking.Application.ViewModels;
using AirlineBookingSystem.Domain.Entities;
using AirlineBookingSystem.Domain.Repositories;
using AirlineBookingSystem.Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Security.Claims;

namespace AirlineBooking.Controllers
{
    public class SeatsController : Controller
    {
        private readonly ISeatRepository _seatRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IBookingRepository _bookingRepository;

        private readonly AirlineBookingDbContext _context;

        public SeatsController(ISeatRepository seatRepository, IFlightRepository flightRepository, IBookingRepository bookingRepository, AirlineBookingDbContext context)
        {
            _seatRepository = seatRepository;
            _flightRepository = flightRepository;
            _bookingRepository = bookingRepository;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ChooseSeats(int FlightId)
        {
            var flightsExists = _context.Flights.Any(f => f.Id == FlightId);
            if (!flightsExists)
            {
                return NotFound(FlightId);
            }

            var seats = _context.Seats.Where(s =>s.FlightId == FlightId).ToList();
            if (!seats.Any())
            {
                for (int i = 1; i <= 20; i++)
                {
                    seats.Add(new Seat { FlightId = FlightId, SeatNumber = $"Seat {i}", IsOccuped = false });
                }
                _context.AddRange(seats);
                _context.SaveChanges();
            }

            var model = new ChooseSeatsViewModel
            {
                FlightId = FlightId,
                Seats = seats.Select(s => new SeatModel
                {
                    Id = s.Id,
                    SeatNumber = s.SeatNumber, 
                    IsOccuped = s.IsOccuped
                }).ToList()
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> ChooseSeats(ChooseSeatsViewModel model, int flightId ,int passengerId)
        {
            await _seatRepository.ReserveSeat(model.SelectedSeat);
            TempData["SuccessMessage"] = "Uçuşunuz başarılı bir şekilde oluşturuldu.";

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                var userNo = Guid.Parse(userIdClaim.Value);
                var booking = new Booking
                {
                    UserId = userNo,
                    FlightId = flightId,
                    SeatId = model.SelectedSeat,
                    PassengerId = passengerId
                };

                _bookingRepository.Add(booking);
                _bookingRepository.SaveChanges(); // Eğer kaydetme işlemi async ise

                return RedirectToAction("Index", "Flight");
            }
            else
            {
                return Json(new { success = false, message = "User not authenticated." });
            }
        }
    }
}
