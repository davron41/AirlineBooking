using AirlineBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Domain.Repositories
{
    public interface ISeatRepository
    {

        IQueryable<Seat> Seats { get; } 
        Task<ICollection<Seat>> GetSeatsByFlight(int flightId);
        Task ReserveSeat(int seatId);
    }
}
