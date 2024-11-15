using AirlineBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Domain.Repositories
{
    public interface IBookingRepository
    {
        IQueryable<Booking> Bookings { get; }
        IQueryable<Booking> GetBookingsByUserId(Guid UserId);
 
       void Add(Booking booking);  

        void SaveChanges();
        
    }
}
