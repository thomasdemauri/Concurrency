using CinemaWebApplication.Models.Enums;

namespace CinemaWebApplication.Models;

public class Seat
{
    public int Number { get; set; }
    public SeatStatus Status { get; set; }
}