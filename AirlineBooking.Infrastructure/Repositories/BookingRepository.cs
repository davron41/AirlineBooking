using AirlineBookingSystem.Domain.Entities;
using AirlineBookingSystem.Domain.Repositories;
using AirlineBookingSystem.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AirlineBookingDbContext _context;

        public BookingRepository(AirlineBookingDbContext context)
        {
            _context = context;
        }

        public IQueryable<Booking> Bookings => _context.Bookings;

        public void Add(Booking booking)
        {
            _context.Bookings.Add(booking);
        }

        public IQueryable<Booking> GetBookingsByUserId(Guid UserId)
        {
            return _context.Bookings
                .Where(b => b.UserId == UserId)
                .Include(b => b.Flight)
                .Include(f => f.Seat)
                .Include(s => s.Passenger)
                .AsNoTracking()
                .AsQueryable();
        }

        public void SaveChanges()
        {
          _context.SaveChanges();
        }
    }
}