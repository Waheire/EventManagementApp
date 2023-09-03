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

        private async Task<IEnumerable<Event>> GetAllEvents() 
        {
            return await _context.Events.ToListAsync();
        }
        public async Task<IEnumerable<Event>> GetAllEventsAsync(string? name,  int? price, string? location)
        {
            var allEvents = await GetAllEvents();

            if (string.IsNullOrWhiteSpace(name) && price == 0 && string.IsNullOrWhiteSpace(location)) 
            {
                //no search string or filter
                return allEvents;
            }

            //implement deferred execution
            var query = _context.Events.AsQueryable<Event>();
            if (!string.IsNullOrWhiteSpace(name)) 
            {
                query = query.Where(c => c.Name.ToLower().Contains(name.ToLower()) || c.Description.ToLower().Contains(name.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(location))
            {
                query = query.Where(c => c.Location.ToLower().Contains(location.ToLower()) || c.Description.ToLower().Contains(location.ToLower()));
            }
            if (price > 0)
            {
                query = query.Where(c => c.Price <= price);
            }

            //execute query
            return await query.ToListAsync();
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
