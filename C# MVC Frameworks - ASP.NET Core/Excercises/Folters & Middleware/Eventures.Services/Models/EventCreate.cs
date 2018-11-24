namespace Eventures.Services.Models
{
    using System;

    public class EventCreate
    {
        public string  Name { get; set; }
        public string Place { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TotalTickets { get; set; }
        public decimal PricePerTicket { get; set; }
    }
}
