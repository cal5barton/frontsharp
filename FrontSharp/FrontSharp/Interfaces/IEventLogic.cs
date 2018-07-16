using FrontSharp.Models;
using FrontSharp.Requests;

namespace FrontSharp.Interfaces
{
    public interface IEventLogic
    {
        ListResultResponseBody<Event> List(EventSearchParameters filter = null, int? limit = null);

        Event Get(string eventId);
    }
}