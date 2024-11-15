using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; } 
        public Guid UserId { get; set; }
        public  IdentityUser<Guid> User { get; set; }   
        
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }

        public int SeatId { get; set; }
        public virtual Seat Seat { get; set; }

        public int PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }

    }

}
