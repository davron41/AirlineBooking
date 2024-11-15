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
    public sealed class SeatRepository : ISeatRepository
    {
        private readonly AirlineBookingDbContext _context;

        public SeatRepository(AirlineBookingDbContext context)
        {
            _context = context;
        }

        public IQueryable<Seat> Seats => _context.Seats;

        public async Task<ICollection<Seat>> GetSeatsByFlight(int flightId)
        {
            return await _context.Seats
                .Where(s => s.FlightId == flightId && !s.IsOccuped).ToListAsync();
        }

        public async Task ReserveSeat(int seatId)
        {
            var seat = await _context.Seats.FindAsync(seatId);
            if(seat != null && !seat.IsOccuped)
            {
                seat.IsOccuped = true;
                _context.Update(seat);
                await _context.SaveChangesAsync();  
            }
        }
    }
}
