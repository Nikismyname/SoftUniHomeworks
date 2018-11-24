using Eventures.Services.Models;

namespace Eventures.Services.Contracts
{
    public interface IEventsService
    {
        void Create(EventCreate model);

        EventAll[] All();
    }
}
