using FrontSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontSharp.Models;
using RestSharp;
using FrontSharp.Helpers;

namespace FrontSharp.Logic
{
    public class EventLogic : BaseLogic, IEventLogic
    {
        public EventLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "events";
        }

        public Event Get(string eventId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{eventId}";
            request.AddParameter("eventId", eventId, ParameterType.UrlSegment);

            return _client.Execute<Event>(request);
        }

        public ListResultResponseBody<Event> List(EventSearchParameters filter = null,  int? limit = null)
        {
            var request = base.BuildRequest();

            if(filter != null)
            {
                if(filter.EventTypes != null && filter.EventTypes.Count() > 0)
                {
                    foreach(var typeFilter in filter.EventTypes)
                    {
                        request.AddParameter("q[types][]", typeFilter.ToString().ToLower(), ParameterType.QueryString);
                    }
                }

                if(filter.Before != null)
                {
                    request.AddParameter("q[before][]", filter.Before.ToTimestamp(), ParameterType.QueryString);
                }

                if(filter.After != null)
                {
                    request.AddParameter("q[after][]", filter.After.ToTimestamp(), ParameterType.QueryString);
                }
            }

            if (limit != null) request.AddParameter("limit", limit > 100 ? 100 : limit, ParameterType.QueryString);

            return _client.Execute<ListResultResponseBody<Event>>(request);
        }
    }
}
