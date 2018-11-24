using Eventures.Data;
using Eventures.Models;
using Eventures.Services.Contracts;
using Eventures.Services.Models;
using System.Linq;

namespace Eventures.Services.Implementations
{
    public class EventsService : IEventsService
    {
        private readonly EventuresDbContext context;

        public EventsService(EventuresDbContext context)
        {
            this.context = context;
        }

        public void Create(EventCreate model)
        {
            var @event = new Event
            {
                End = model.End,
                Start = model.Start,
                Name = model.Name,
                Place = model.Place,
                PricePerTicket = model.PricePerTicket,
                TotalTickets = model.TotalTickets,
            };

            context.Events.Add(@event);
            context.SaveChanges();
        }

        public EventAll[] All()
        {
            var events = context.Events
                .Select(x => new EventAll
                {
                    End = x.End,
                    Start = x.Start,
                    Name = x.Name,
                    Place = x.Place,
                })
                .ToArray();

            for (int i = 0; i < events.Length; i++)
            {
                events[i].Number = i + 1;
            }

            return events;
        }
    }
}
