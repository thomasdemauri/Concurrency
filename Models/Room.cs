namespace CinemaWebApplication.Models;

public class Room
{
    public Guid id { get; set; }
    public string Number { get; set; }
    public IReadOnlyCollection<Seat> Seats => _seats.AsReadOnly();
    private IList<Seat> _seats;

}