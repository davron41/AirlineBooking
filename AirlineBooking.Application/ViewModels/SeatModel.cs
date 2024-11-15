using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.Application.ViewModels
{
    public class SeatModel
    {
        public int Id { get; set; } 
        public string SeatNumber { get; set; }
        public bool IsOccuped { get; set; }

    }
}
