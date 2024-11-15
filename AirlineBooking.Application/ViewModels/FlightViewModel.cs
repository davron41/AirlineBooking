using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.Application.ViewModels
{
    public class FlightViewModel
    {
        public bool IsOneWay { get; set; }

        public string? From { get; set; }
        public string? To { get; set; }
        public required DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public DateOnly Time { get; set; }
        public decimal Price { get; set; }
    }
}
