using EventManagementApp.Entities;

namespace EventManagementApp.Services.IServices
{
    public interface IEventInterface
    {
        Task<string> AddEventAsync(Event eventItem);
        Task<string> UpdateEventAsync(Event eventItem);
        Task<string> DeleteEventAsync(Event eventItem);

        Task<IEnumerable<Event>> GetAllEventsAsync(string? name, int? price, string? location);
       
        Task<Event> GetEventByIdAsync(Guid id);
    }
}
