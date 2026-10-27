using Microsoft.AspNetCore.Mvc;

namespace CinemaWebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketsController : ControllerBase
{
    private static readonly object _lock = new object();
    private static bool _seatIsAvailable = true;
    private static int _counter = 0;
    
    [HttpPost]
    [Route("Seat")]
    public IActionResult ReserveSeat()
    {
        lock (_lock)
        {
            if (!_seatIsAvailable)
            {
                return Conflict();
            } 
            
            Task.Delay(10);   // Simulate processing time
            _seatIsAvailable = false;
            _counter++;
            
            return Ok();
        }
    }
    
    [HttpPost]
    [Route("Reset")]
    public IActionResult Reset()
    {
        _seatIsAvailable = true;
        _counter = 0;
        return Ok();
    }
    
    [HttpGet]
    [Route("Seat")]
    public IActionResult CheckSeat()
    {
        return Ok(_counter);
    }
    
    
}