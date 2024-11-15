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
    public sealed class PassengerRepository : IPassengerRepository
    {
        private readonly AirlineBookingDbContext _context;

        public PassengerRepository(AirlineBookingDbContext context)
        {
            _context = context;
        }

        public IQueryable<Passenger> Passengers => _context.Passes;

        public void CreatePassneger(Passenger passenger)
        {
           _context.Passes.Add(passenger);  
            _context.SaveChanges();
        }
    }
}
