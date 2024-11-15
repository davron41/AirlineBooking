using AirlineBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Domain.Repositories
{
    public interface IPassengerRepository
    {
        IQueryable<Passenger> Passengers { get; }   
        void CreatePassneger(Passenger passenger);
    }
}
