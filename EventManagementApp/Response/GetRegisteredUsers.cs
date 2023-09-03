namespace EventManagementApp.Response
{
    public class GetRegisteredUsers
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public List<EventDto> Events { get; set; }
    }

    public class EventDto 
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Ticket { get; set; } = string.Empty;
        public int BookedEvents { get; set; }
    }

   
}
