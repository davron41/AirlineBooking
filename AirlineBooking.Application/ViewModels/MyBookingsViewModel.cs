using AirlineBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.Application.ViewModels
{
    public class MyBookingsViewModel
    {

        public ICollection<Booking> Bookings { get; set; }
    }
}
