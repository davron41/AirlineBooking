using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.Application.ViewModels
{
    public class ChooseSeatsViewModel
    {
        public int FlightId { get; set; }
        public List<SeatModel>Seats { get; set; }   
        public int SelectedSeat {  get; set; }
    }
}
