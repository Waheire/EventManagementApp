using System.ComponentModel.DataAnnotations;

namespace EventManagementApp.Entities
{
    public class Event
    {
        [Key]
        public Guid EventId { get; set; }
        public string Name { get; set; } =  string.Empty;
        public string Description { get; set; } = string.Empty; 
        public string  Location { get; set; } = string.Empty;
        public int Capacity { get; set; } 
        public string Ticket { get; set; } = string.Empty;
        public int Price { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.AddDays(1);

        public List<User> users { get; set; } = new List<User>();
    }
}
