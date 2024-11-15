using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.Application.Models
{
    public sealed record UserInfo(
        string Browser, 
        string OS);
}
