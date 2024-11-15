using AirlineBookingSystem.Domain.Entities;
using AirlineBookingSystem.Domain.Repositories;
using AirlineBookingSystem.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Infrastructure.Repositories
{

    public sealed class FlightRepository : IFlightRepository
    {
        private readonly AirlineBookingDbContext _context;

        public FlightRepository(AirlineBookingDbContext context)
        {
            _context = context;
        }

        public IQueryable<Flight> Flights => _context.Flights;

        public void GetFlights(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }
    }
}
