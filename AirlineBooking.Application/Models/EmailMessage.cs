using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.Application.Models
{
    public record EmailMessage(
        string To,
        string Username,
        string Subject,
        string? FallbackUrl);
}
