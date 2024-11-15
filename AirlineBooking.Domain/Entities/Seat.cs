namespace AirlineBookingSystem.Domain.Entities;
public class Seat
{

    public int Id { get; set; }
    public bool IsOccuped { get; set; }
    public string? SeatNumber { get; set; }

    public Guid UserId { get; set; }    
    public int FlightId { get; set; }
    public required virtual Flight Flight { get; set; }

    public required virtual Passenger Passenger { get; set; }    
}
