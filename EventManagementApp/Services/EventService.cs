using EventManagementApp.Data;
using EventManagementApp.Entities;
using EventManagementApp.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApp.Services
{
    public class EventService : IEventM
    {
        private readonly AppDbContext _context;
        public EventService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddEventAsync(Event newEvent)
        {
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            return "Event Added successfully";
        }

        public async Task<Event> GetEventByIdAsync(Guid id)
        {
            return await _context.Events.Where(x => x.EventId == id).FirstOrDefaultAsync();
        }
    }
}
