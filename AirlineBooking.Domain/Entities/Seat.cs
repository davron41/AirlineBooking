namespace AirlineBookingSystem.Domain.Entities;
public class Seat
{

    public int Id { get; set; }
    public bool IsOccuped { get; set; }
    public string? SeatNumber { get; set; }

   
    public int FlightId { get; set; }
    public  virtual Flight Flight { get; set; }

    public  virtual Passenger Passenger { get; set; }    
}
