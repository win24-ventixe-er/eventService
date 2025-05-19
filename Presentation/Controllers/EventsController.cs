using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Services;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController(IEventService eventService) : ControllerBase
{
    private readonly IEventService _eventService = eventService;

    [HttpGet]
    public async Task<IActionResult> GetAllEvents()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpGet("{eventId}")]
    public async Task<IActionResult> GetEventById(string eventId)
    {
        var eventEntity = await _eventService.GetEventByIdAsync(eventId);
        if (eventEntity == null)
        {
            return NotFound();
        }
        return Ok(eventEntity);
    }
}
