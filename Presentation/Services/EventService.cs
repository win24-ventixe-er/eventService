using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Presentation.Data;

namespace Presentation.Services;

public interface IEventService
{
    Task<IEnumerable<EventEntity>> GetAllEventsAsync();
    Task<EventEntity?> GetEventByIdAsync(string eventId);
}

public class EventService(DataContext context) : IEventService
{
    private readonly DataContext _context = context;
    public async Task<IEnumerable<EventEntity>> GetAllEventsAsync()
    {
        var entities = await _context.Events.ToListAsync();
        return entities;
    }
    public async Task<EventEntity?> GetEventByIdAsync(string eventId)
    {
        var entity = await _context.Events.FirstOrDefaultAsync(x => x.Id == eventId);
        return entity;
    }
}
//public interface IEventService
//{

//}
//public class EventService : IEventService
//{
//}
