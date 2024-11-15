using AirlineBookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Domain.Entities
{
    public class Passenger
    {
        public int Id { get; set; } 
        public required string  FisrName  { get; set; }
        public required string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public required string Nationality { get; set; }
        public required string PassportNumber { get; set; }
        public required string PhoneNumber { get; set; }    
        public Gender Gender { get; set; }

        public int SeatId { get; set; }
        public virtual Seat Seat { get; set; }

    }
}
