namespace EventManagementApp.Response
{
    public class EventResponse
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public string Ticket { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}
