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
        public required IdentityUser<Guid> User { get; set; }   
        
        public virtual ICollection<Flight> Flights { get; set; }
     
   
    public Booking()
        {
            Flights = new HashSet<Flight>();
           
       }

    }

}
