using FrontSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Interfaces
{
    public interface IEventLogic
    {
        ListResultResponseBody<Event> List(EventSearchParameters filter = null,  int? limit = null);
        Event Get(string eventId);
    }
}
