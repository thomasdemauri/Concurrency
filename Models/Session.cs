using CinemaWebApplication.Models.Enums;

namespace CinemaWebApplication.Models;

public class Session
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid MovieId { get; set; }
    public Guid RoomId { get; set; }
    public Room room { get; set; }

    public Session(DateTime date, Guid movieId, Guid roomId)
    {
        
    }

    private void InitializeSeats()
    {
        foreach (var seat in room.Seats)
        {
            seat.Status = SeatStatus.AVAIABLE;
        }
    }
}