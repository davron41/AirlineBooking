using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Domain.Entities
{
    public class Flight
    {
        public int Id { get; set; } 
        public string? From { get; set; }
        public string? To { get; set; }  
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; } 
        public DateOnly? Time { get; set; }
        public decimal Price {  get; set; }

        public Guid UserId { get; set; }    
        public int BookingId { get; set; }
        public  virtual Booking Booking  { get; set; }   

        public virtual ICollection<Seat> Seats { get; set; }    
     
      

       
        public Flight()
        {
            Seats = new HashSet<Seat>();    
         
        }
    }
}
