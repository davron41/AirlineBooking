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
            if(user is null)
                {
                    _repository.GetFlights(new Flight
                    {
                        From = model.From,
                        To = model.To,
                        Departure = model.Departure,
                        Arrival = model.Arrival,
                        Price = model.Price
                    });

                    return RedirectToAction("SignIn");
                }
            
            
            }   

            return View(model);
        }

        public async 
    }
}
