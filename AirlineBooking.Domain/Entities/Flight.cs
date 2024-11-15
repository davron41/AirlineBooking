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
        public required string From { get; set; }
        public required string To { get; set; }  
        public required string Departure { get; set; }
        public string? Arrival { get; set; } 
        public required string Time { get; set; }
        public decimal Price {  get; set; }
      

        
    }
}
