using EventManagementApp.Data;
using EventManagementApp.Entities;
using EventManagementApp.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApp.Services
{
    public class EventService : IEventInterface
    {
        private readonly AppDbContext _context;
        public EventService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddEventAsync(Event newItem)
        {
            _context.Events.Add(newItem);
            await _context.SaveChangesAsync();
            return "Event Added successfully";
        }

        public async Task<string> DeleteEventAsync(Event eventItem)
        {
            _context.Events.Remove(eventItem);
            await _context.SaveChangesAsync();
            return "Event Deleted successfully";
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(Guid id)
        {
           return await _context.Events.Where(x => x.EventId == id).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateEventAsync(Event eventItem)
        {
            _context.Events.Update(eventItem);
            await _context.SaveChangesAsync();
            return "Event Updated successfully";
        }
    }
}
