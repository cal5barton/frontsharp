using FrontAppAPI.Models;
using FrontAppAPI.Requests;

namespace FrontAppAPI.Interfaces
{
    public interface IEventLogic
    {
        ListResultResponseBody<Event> List(EventSearchParameters filter = null, int? limit = null);

        Event Get(string eventId);
    }
}