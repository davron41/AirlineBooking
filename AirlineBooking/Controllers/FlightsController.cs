using AirlineBooking.Application.ViewModels;
using AirlineBookingSystem.Domain.Entities;
using AirlineBookingSystem.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Security.AccessControl;

namespace AirlineBooking.Controllers
{
    public class FlightsController : Controller
    {
        private readonly IFlightRepository _repository;
        

        public FlightsController(IFlightRepository flightRepository)
        {
            _repository = flightRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(FlightViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _repository.Flights
                    .FirstOrDefaultAsync(x => x.From == model.From && x.To == model.To);
                if (user is null)
                {
                    _repository.GetFlights(new Flight
                    {
                        From = model.From,
                        To = model.To,
                        Departure = model.Departure,
                        Arrival = model.Arrival,
                        Time = model.Time,
                        Price = model.Price
                    });

                    return RedirectToAction("SignIn");
                }


            }

            return View(model);

        }

        public async Task<IActionResult> SearchFlights(FlightViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["Error"] = "You must be logged in to view this page.";
                return RedirectToAction("Index");
            }
            if (!string.IsNullOrWhiteSpace(model.Departure))
            {
                ModelState.AddModelError("", "Departure location cannot be empty");
                TempData["Error"] = "Departure location cannot be empty";
                return RedirectToAction("Index");
            }

            if(ModelState.IsValid)
            {
                var query = _repository.Flights.AsQueryable();

                query = query.Where(
                    f => f.From == model.From && f.To == model.To);


                if (model.IsOneWay)
                {
                    query = query.Where(f => f.Departure == model.Departure);
                }

                else
                {
                     query = query.Where(f => f.Departure != model.Departure);
                    if (!string.IsNullOrWhiteSpace(model.Arrival))
                    {
                        query = query.Where(f => f.Arrival == model.Arrival);
                    }
                }


                var flights = await query.Select(flights => new CreateFlightViewModel

                {
                    Id = flights.Id,
                    From = model.From,
                    To = model.To,
                    Departure = model.Departure,
                    Arrival = model.Arrival,
                    Time = model.Time,
                    Price = model.Price
                }).ToListAsync();

                return View("SearchResults", flights);
            }

            if (!ModelState.IsValid)
            {
                var query = _repository.Flights.AsQueryable();

                // Ortak kriterler
                query = query.Where(f => f.From == model.From && f.To == model.To && f.Arrival == null);

                // One Way ise Return tarihini dikkate alma.
                if (model.IsOneWay)
                {
                    query = query.Where(f => f.Departure == model.Departure);
                }
                else
                {
                    // Return seçeneği varsa ve tarih belirtilmişse
                    query = query.Where(f => f.Departure == model.Departure);
                    if (!string.IsNullOrEmpty(model.Arrival))
                    {
                        query = query.Where(f => f.Arrival == model.Arrival);
                    }
                }

                var flights = await query.Select(flights => new CreateFlightViewModel
                {
                   Id = flights.Id,
                   From = flights.From,
                   To = flights.To,
                   Departure = flights.Departure,
                   Arrival = flights.Arrival,
                   Time = flights.Time,
                   Price = flights.Price

                }).ToListAsync();

                return View("SearchResults", flights);

            }

            return View("SearchResults", model);

        }
            

       
    }
}
